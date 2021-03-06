﻿using System;
using System.Windows.Forms;

namespace ConThing {
	/// <summary>
	/// Форма для заполнения каталога.
	/// </summary>
	public partial class AddToCatalogForm : Form {
		/// <summary>
		/// Имя элемента.
		/// </summary>
		public string ItemName { get { return txtName.Text; } }
		/// <summary>
		/// Цена элемента.
		/// </summary>
		public decimal Price { get { return numPrice.Value; } }
		/// <summary>
		/// Количество элемента.
		/// </summary>
		public decimal Quantity { get { return numQuantity.Value; } }
		public string ImagePath { get { return pbImage.ImageLocation; } }

		public AddToCatalogForm() {
			InitializeComponent();

			DialogResult = DialogResult.Cancel;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOpenImage_Click(object sender, EventArgs e) {
			var ofd = new OpenFileDialog() {
				Title = "Где лежит изображение?",
				Filter = "Изображения|*.png;*.jpg;*.bmp"
			};

			if (ofd.ShowDialog() != DialogResult.OK) return;

			pbImage.ImageLocation = ofd.FileName;
		}
	}
}
