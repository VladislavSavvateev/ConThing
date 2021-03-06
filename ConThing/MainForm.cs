﻿using System;
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
	/// Форма для показа покупок.
	/// </summary>
	public partial class MainForm : Form {
		/// <summary>
		/// Соединение с БД.
		/// </summary>
		private SQLiteConnection connection;

		public MainForm(SQLiteConnection connection) {
			InitializeComponent();

			this.connection = connection;
		}

		/// <summary>
		/// Происходит при нажатии на кнопку каталога.
		/// </summary
		private void menuCatalog_Click(object sender, EventArgs e) {
			new CatalogForm(connection).Show();
		}

		/// <summary>
		/// Происходит при закрытии формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			connection.Close();
		}

		/// <summary>
		/// Происходит при нажатии на кнопку добавления новой покупки.
		/// </summary>
		private void menuAdd_Click(object sender, EventArgs e) {
			// создаём форму
			var form = new AddToSellsForm(connection);

			// если форма не вернула ok, то выходим
			if (form.ShowDialog() != DialogResult.OK) return;

			if (form.Quantity == 0) return;

			// добавим покупку в БД

			// создаём соединение
			var com = new SQLiteCommand("insert into sells(item_id, quantity) values(@ItemId, @Quantity); select last_insert_rowid();", connection);

			// указываем параметры
			com.Parameters.Add("@ItemId", DbType.Int64).Value = form.SelectedItem.Id;
			com.Parameters.Add("@Quantity", DbType.Int32).Value = form.Quantity;

			// получаем id
			var id = (long)com.ExecuteScalar();

			// добавляем покупку в список
			lstSells.Items.Add(new ListViewItem(new string[] {
				id.ToString(),
				form.SelectedItem.Name,
				string.Format("{0:F2} ₽", form.SelectedItem.Price),
				form.Quantity.ToString(),
				string.Format("{0:F2} ₽", form.Quantity * form.SelectedItem.Price)
			}));

			// обновляем ширину столбцов
			UpdateColumnWidth();
		}

		/// <summary>
		/// Происходит при нажатии на клавишу.
		/// </summary>
		private void lstSells_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.A)
				menuAdd_Click(sender, e);
			if (e.Control && e.KeyCode == Keys.K)
				menuCatalog_Click(sender, e);
			if (e.KeyCode == Keys.Delete)
				DeleteSelectedSells();
		}

		/// <summary>
		/// Происходит при загрузке формы.
		/// </summary>
		private void MainForm_Load(object sender, EventArgs e) {
			// получим все покупки
			
			// создаём соединение
			var com = new SQLiteCommand("select s.id,i.name,i.price,s.quantity,(i.price*s.quantity) from sells as s join items as i on (s.item_id=i.id);", connection);

			// инициализируем считыватель
			var reader = com.ExecuteReader();

			// пока есть записи...
			while (reader.Read()) {
				// добавляем их в лист
				lstSells.Items.Add(new ListViewItem(new string[] {
					((long)reader[0]).ToString(),
					(string)reader[1],
					string.Format("{0:F2} ₽", (double)reader[2]),
					((int)reader[3]).ToString(),
					string.Format("{0:F2} ₽", (double)reader[4])
				}));
			}

			// закрываем считыватель
			reader.Close();

			// обновляем ширину столбцов
			UpdateColumnWidth();
		}

		/// <summary>
		/// Происходит при нажатии на кнопку Доход.
		/// </summary>
		private void menuIncoming_Click(object sender, EventArgs e) {
			// создаём соединение
			var com = new SQLiteCommand("select ifnull(sum(i.price*s.quantity),0.0) from sells as s join items as i on (s.item_id=i.id);", connection);

			// выводим результат
			var thing = (double)com.ExecuteScalar();
			MessageBox.Show(string.Format("Прибыль: {0:F2} ₽. Доход: {1:F2} ₽. Отдал ебаному правительству: {2:F2} ₽.", thing, thing * 0.82, thing * 0.15), "*_*", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Обновляет ширину столбцов.
		/// </summary>
		private void UpdateColumnWidth() {
			for (int i = 0; i < lstSells.Columns.Count; i++)
				lstSells.Columns[i].Width = -2;
		}

		/// <summary>
		/// Удаляет выделенные записи.
		/// </summary>
		private void DeleteSelectedSells() {
			// если выделенных записей нет, выходим
			if (lstSells.SelectedItems.Count == 0) return;

			// спрашиваем подтверждение
			if (MessageBox.Show("Вы действительно хотите удалить выделенные записи?", "*_*", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

			// для каждой выделенной линии...
			for (int i = lstSells.SelectedItems.Count - 1; i >= 0; i--) {
				var row = lstSells.SelectedItems[i];
				DeleteSellById(long.Parse(row.SubItems[0].Text));
				lstSells.Items.Remove(row);
			}

			// обновим ширину столбцов
			UpdateColumnWidth();
		}
		
		/// <summary>
		/// Удаляет покупку по id.
		/// </summary>
		/// <param name="id">Id покупки.</param>
		private void DeleteSellById(long id) {
			var com = new SQLiteCommand("delete from sells where id=@Id;", connection);
			com.Parameters.Add("@Id", DbType.Int64).Value = id;
			com.ExecuteNonQuery();
		}
	}
}
