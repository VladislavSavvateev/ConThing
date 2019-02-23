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
	public partial class ItemPreviewForm : Form {
		public ItemPreviewForm() {
			InitializeComponent();
		}

		public void SetImagePath(string path) {
			pbPreview.ImageLocation = path;
		}
	}
}
