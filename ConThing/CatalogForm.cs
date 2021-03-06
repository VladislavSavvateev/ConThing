﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
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

		private ItemPreviewForm previewForm;

		public CatalogForm(SQLiteConnection connection) {
			this.connection = connection;
			InitializeComponent();

			previewForm = new ItemPreviewForm();
		}

		/// <summary>
		/// Происходит при загрузке формы.
		/// </summary>
		private void CatalogForm_Load(object sender, EventArgs e) {
			// получим все элементы

			// создаём команду
			var com = new SQLiteCommand("select *,items.quantity - ifnull((select sum(quantity) from sells where sells.item_id=items.id),0) from items;", connection);

			// инициализируем считыватель
			var reader = com.ExecuteReader();

			// пока есть записи...
			while (reader.Read()) {
				// добавляем записи в лист
				lstCatalog.Items.Add(new ListViewItem(new string[] {
					((long)reader[0]).ToString(),
					(string)reader[1],
					string.Format("{0:F2} ₽", (double)reader[2]),
					((int)reader[3]).ToString(),
					reader.IsDBNull(4) ? "" : (string)reader[4],
					((long)reader[5]).ToString()
				}));
			}

			// закрываем считыватель
			reader.Close();

			// пересчитываем ширину столбцов
			UpdateColumnWidth();

			previewForm.Show();
		}

		/// <summary>
		/// Происходит при нажатии на кнопку добавления нового элемента.
		/// </summary>
		private void menuAdd_Click(object sender, EventArgs e) {
			// создаём форму
			var form = new AddToCatalogForm();

			// если при вызове формы не вернули ok, то уходим
			if (form.ShowDialog() != DialogResult.OK) return;

			var dir = Directory.CreateDirectory("imgs");

			var path = "";
			if (form.ImagePath != null) {
				var fi = new FileInfo(form.ImagePath);
				if (fi.Exists) {
					path = dir.FullName + "\\" + RandomName() + fi.Extension;
					fi.CopyTo(path);
				}
			}

			// вставим элемент в БД

			// открываем соединение
			var com = new SQLiteCommand("insert into items(name, price, quantity, img_path) values(@Name, @Price, @Quantity, @ImgPath); select last_insert_rowid();", connection);

			// указываем параметры
			com.Parameters.Add("@Name", DbType.String).Value = form.ItemName;
			com.Parameters.Add("@Price", DbType.Double).Value = form.Price;
			com.Parameters.Add("@Quantity", DbType.Int32).Value = form.Quantity;
			com.Parameters.Add("@ImgPath", DbType.String).Value = path;
			
			// получаем id
			var id = (long)com.ExecuteScalar();

			// закидываем новый элемент в каталог
			lstCatalog.Items.Add(new ListViewItem(new string[] {
				id.ToString(),
				form.ItemName,
				string.Format("{0:F2} ₽", form.Price),
				form.Quantity.ToString(),
				path,
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
			if (e.KeyCode == Keys.Enter)
				lstCatalog_DoubleClick(sender, e);
		}

		/// <summary>
		/// Удаляет выбранные строки.
		/// </summary>
		private void DeleteSelectedRows() {
			if (MessageBox.Show("Действительно хотите удалить эти элементы?", "*_*", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

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
				if (i != 4) lstCatalog.Columns[i].Width = -2;
		}

		private string RandomName() {
			var rand = new Random();
			var res = "";
			for (int i = 0; i < 16; i++)
				res += rand.Next(16).ToString("x");
			return res;
		}

		private void CatalogForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!previewForm.IsDisposed)
				previewForm.Close();
		}

		private void lstCatalog_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
			previewForm.SetImagePath(e.Item.SubItems[4].Text);
		}

		private void lstCatalog_DoubleClick(object sender, EventArgs e) {
			var row = lstCatalog.SelectedItems[0];
			var oldQuantity = int.Parse(row.SubItems[3].Text);
			var form = new EditCatalogItemForm(row);
			if (form.ShowDialog() != DialogResult.OK) return;

			var dir = Directory.CreateDirectory("imgs");

			var path = "";
			if (form.ImagePath != null && form.ImagePath != "") {
				var fi = new FileInfo(form.ImagePath);
				if (fi.Exists) {
					path = dir.FullName + "\\" + RandomName() + fi.Extension;
					fi.CopyTo(path);
				}
			}

			var com = new SQLiteCommand("update items set name=@Name,price=@Price,quantity=@Quantity,img_path=@ImgPath where id=@Id;", connection);

			com.Parameters.Add("@Name", DbType.String).Value = form.ItemName;
			com.Parameters.Add("@Price", DbType.Double).Value = form.Price;
			com.Parameters.Add("@Quantity", DbType.Int32).Value = form.Quantity;
			com.Parameters.Add("@ImgPath", DbType.String).Value = path;
			com.Parameters.Add("@Id", DbType.Int64).Value = long.Parse(row.SubItems[0].Text);

			com.ExecuteNonQuery();

			row.SubItems[1].Text = form.ItemName;
			row.SubItems[2].Text = string.Format("{0:F2} ₽", form.Price);
			row.SubItems[3].Text = form.Quantity.ToString();
			row.SubItems[4].Text = path;
			row.SubItems[5].Text = (long.Parse(row.SubItems[5].Text) + (form.Quantity - oldQuantity)).ToString();

			previewForm.SetImagePath(path);
		}

		private void menuHowMuch_Click(object sender, EventArgs e) {
			var com = new SQLiteCommand("select ifnull(sum(price*quantity),0.0) from items;", connection);

			MessageBox.Show(string.Format("Всё это добро стоит {0:F2} ₽", (double)com.ExecuteScalar()), "*_*", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void lstCatalog_ColumnClick(object sender, ColumnClickEventArgs e) {
			lstCatalog.ListViewItemSorter = new ColumnSorter(e.Column, lstCatalog.Sorting);
			lstCatalog.Sort();

			lstCatalog.Sorting = lstCatalog.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
		}

		private void menuRefresh_Click(object sender, EventArgs e) {
			lstCatalog.Items.Clear();
			CatalogForm_Load(sender, e);
		}

		private void menuInvent_Click(object sender, EventArgs e) {
			var sfd = new SaveFileDialog {
				Filter = "Файлы БД|*.db",
				InitialDirectory = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/db").FullName,
				Title = "Укажите название новой БД"
			};

			// если диалог не вернул ok, то выходим
			if (sfd.ShowDialog() != DialogResult.OK) return;

			// создаём файл
			File.Create(sfd.FileName).Close();

			var con = DBForm.CreateDB(new FileInfo(sfd.FileName).Name);

			for (int i = 0; i < lstCatalog.Items.Count; i++) {
				var row = lstCatalog.Items[i];

				var com = new SQLiteCommand("insert into items(name, price, quantity, img_path) values(@Name, @Price, @Quantity, @ImgPath);", con);
				com.Parameters.Add("@Name", DbType.String).Value = row.SubItems[1].Text;
				com.Parameters.Add("@Price", DbType.Double).Value = double.Parse(row.SubItems[2].Text.Substring(0, row.SubItems[2].Text.IndexOf(' ')));
				com.Parameters.Add("@Quantity", DbType.Int32).Value = int.Parse(row.SubItems[5].Text);
				com.Parameters.Add("@ImgPath", DbType.String).Value = row.SubItems[4].Text;

				com.ExecuteNonQuery();
			}

			DBForm.ReloadList();
			MessageBox.Show("Новая БД успешно создана!", "*_*",	MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
