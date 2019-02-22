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
	/// Форма для добавления в покупки.
	/// </summary>
	public partial class AddToSellsForm : Form {
		/// <summary>
		/// Выбранный элемент.
		/// </summary>
		public Item SelectedItem { get { return (Item)cmbItems.SelectedItem; } }
		/// <summary>
		/// Количество покупаемого товара.
		/// </summary>
		public int Quantity { get { return (int)numQuantity.Value; } }

		/// <summary>
		/// Соединение с БД.
		/// </summary>
		private SQLiteConnection connection;

		public AddToSellsForm(SQLiteConnection connection) {
			InitializeComponent();

			this.connection = connection;
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Происходит при загрузке формы.
		/// </summary>
		private void AddToSellsForm_Load(object sender, EventArgs e) {
			// получим все элементы

			// создаём команду
			var com = new SQLiteCommand("select * from items;", connection);

			// инициализируем считыватель
			var reader = com.ExecuteReader();

			// пока в считывателе есть записи...
			while (reader.Read()) {
				// добавляем их в комбо
				cmbItems.Items.Add(new Item(reader));
			}

			// закрываем считыватель
			reader.Close();
		}

		/// <summary>
		/// Происходит при изменении выбранного элемента.
		/// </summary>
		private void cmbItems_SelectedValueChanged(object sender, EventArgs e) {
			Recalculate();
			numQuantity.Focus();
		}

		/// <summary>
		/// Происходит при изменении количества.
		/// </summary>
		private void numQuantity_ValueChanged(object sender, EventArgs e) {
			Recalculate();
		}

		/// <summary>
		/// Пересчитывает общую стоимость.
		/// </summary>
		private void Recalculate() {
			// если элемент не выбран, уходим
			if (cmbItems.SelectedItem == null) return;
			
			// пересчитываем стоимость
			txtTotal.Text = string.Format("{0:F2} ₽", SelectedItem.Price * (double)numQuantity.Value);
		}

		/// <summary>
		/// Происходит при нажатии на кнопку ОК.
		/// </summary>
		private void btnOk_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Происходит при нажатии на кнопку Отмена.
		/// </summary>
		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// Класс для хранения элементов.
		/// </summary>
		public class Item {
			public long Id { get; }
			public string Name { get; }
			public double Price { get; }
			public int Quantity { get; }

			public Item(SQLiteDataReader reader) {
				Id = (long)reader[0];
				Name = (string)reader[1];
				Price = (double)reader[2];
				Quantity = (int)reader[3];
			}

			public override string ToString() {
				return Name;
			}
		}
	}
}
