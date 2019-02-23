using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConThing {
	public partial class EditCatalogItemForm : Form {
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

		public EditCatalogItemForm(ListViewItem item) {
			InitializeComponent();

			txtName.Text = item.SubItems[1].Text;
			numPrice.Value = decimal.Parse(item.SubItems[2].Text.Substring(0, item.SubItems[2].Text.IndexOf(' ')));
			numQuantity.Value = int.Parse(item.SubItems[3].Text);
			pbImage.ImageLocation = item.SubItems[4].Text;
		}

		private void btnEdit_Click(object sender, EventArgs e) {
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
