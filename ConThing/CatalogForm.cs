using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConThing {
	/// <summary>
	/// Форма для показа каталога.
	/// </summary>
	public partial class CatalogForm : Form {
		/// <summary>
		/// Соединение с БД.
		/// </summary>
		private SQLiteConnection connection;

		public CatalogForm(SQLiteConnection connection) {
			this.connection = connection;
			InitializeComponent();
		}

		/// <summary>
		/// Происходит при загрузке формы.
		/// </summary>
		private void CatalogForm_Load(object sender, EventArgs e) {
			// получим все элементы

			// создаём команду
			var com = new SQLiteCommand("select * from items;", connection);

			// инициализируем считыватель
			var reader = com.ExecuteReader();

			// пока есть записи...
			while (reader.Read()) {
				// добавляем записи в лист
				lstCatalog.Items.Add(new ListViewItem(new string[] {
					((long)reader[0]).ToString(),
					(string)reader[1],
					string.Format("{0:F2} ₽", (double)reader[2]),
					((int)reader[3]).ToString()
				}));
			}

			// закрываем считыватель
			reader.Close();

			// пересчитываем ширину столбцов
			UpdateColumnWidth();
		}

		/// <summary>
		/// Происходит при нажатии на кнопку добавления нового элемента.
		/// </summary>
		private void menuAdd_Click(object sender, EventArgs e) {
			// создаём форму
			var form = new AddToCatalogForm();

			// если при вызове формы не вернули ok, то уходим
			if (form.ShowDialog() != DialogResult.OK) return;

			// вставим элемент в БД

			// открываем соединение
			var com = new SQLiteCommand("insert into items(name, price, quantity) values(@Name, @Price, @Quantity); select last_insert_rowid();", connection);

			// указываем параметры
			com.Parameters.Add("@Name", DbType.String).Value = form.ItemName;
			com.Parameters.Add("@Price", DbType.Double).Value = form.Price;
			com.Parameters.Add("@Quantity", DbType.Int32).Value = form.Quantity;
			
			// получаем id
			var id = (long)com.ExecuteScalar();

			// закидываем новый элемент в каталог
			lstCatalog.Items.Add(new ListViewItem(new string[] {
				id.ToString(),
				form.ItemName,
				string.Format("{0:F2} ₽", form.Price),
				form.Quantity.ToString()
			}));

			// обновляем ширину столбцов
			UpdateColumnWidth();
		}

		/// <summary>
		/// Происходит при нажатии на клавиши.
		/// </summary>
		private void CatalogForm_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.A)
				menuAdd_Click(sender, e);
			if (e.KeyCode == Keys.Delete)
				DeleteSelectedRows();
			if (e.KeyCode == Keys.Escape)
				Close();
		}

		/// <summary>
		/// Удаляет выбранные строки.
		/// </summary>
		private void DeleteSelectedRows() {
			for (int i = lstCatalog.SelectedItems.Count - 1; i >= 0; i--) {
				var row = lstCatalog.SelectedItems[i];
				DeleteById(long.Parse(row.SubItems[0].Text));
				lstCatalog.Items.Remove(row);
			}

			UpdateColumnWidth();
		}

		/// <summary>
		/// Удаляет элемент с указанным id.
		/// </summary>
		/// <param name="id">Id элемента.</param>
		private void DeleteById(long id) {
			var com = new SQLiteCommand("delete from items where id=@Id;", connection);
			com.Parameters.Add("@Id", DbType.Int64).Value = id;
			com.ExecuteNonQuery();
		}

		/// <summary>
		/// Обновляет ширину столбцов.
		/// </summary>
		private void UpdateColumnWidth() {
			for (int i = 0; i < lstCatalog.Columns.Count; i++)
				lstCatalog.Columns[i].Width = -2;
		}
	}
}
