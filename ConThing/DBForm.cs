using System;
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
	/// Форма для выбора БД.
	/// </summary>
	public partial class DBForm : Form {
		public DBForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Происходит при загрузке формы.
		/// </summary>
		private void DBForm_Load(object sender, EventArgs e) {
			// получаем все файлы БД
			var thing = Directory.GetFiles(Directory.GetCurrentDirectory() + "/db", "*.db", SearchOption.TopDirectoryOnly);

			// добавляем в список
			for (int i = 0; i < thing.Length; i++)
				lstDBs.Items.Add(new FileInfo(thing[i]).Name);
		}

		/// <summary>
		/// Происходит при нажатии на кнопку Создать новую БД
		/// </summary>
		private void btnCreateNew_Click(object sender, EventArgs e) {
			// создаём диалог сохранения
			var sfd = new SaveFileDialog {
				Filter = "Файлы БД|*.db",
				InitialDirectory = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/db").FullName,
				Title = "Укажите название новой БД"
			};

			// если диалог не вернул ok, то выходим
			if (sfd.ShowDialog() != DialogResult.OK) return;

			// создаём файл
			File.Create(sfd.FileName);

			// выполняем обновление списка БД
			DBForm_Load(sender, e);
		}

		/// <summary>
		/// Происходит при нажатии на кноопку Открыть.
		/// </summary>
		private void btnOpen_Click(object sender, EventArgs e) {
			// если БД не выбрана
			if (lstDBs.SelectedIndex == -1) {
				MessageBox.Show("БД не выбрана!", "*_*", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// пытаемся открыть БД
			try {
				var con = new SQLiteConnection(string.Format("Data Source={0};Version=3;db=thing;", new FileInfo(Directory.GetCurrentDirectory() + "/db/" + lstDBs.SelectedItem)));
				con.Open();

				var com = new SQLiteCommand("create table if not exists items(id integer primary key autoincrement, name text not null, price double not null, quantity int not null, img_path text);" +
					"create table if not exists sells(id integer primary key autoincrement, item_id integer not null, quantity int not null);", con);
				com.ExecuteNonQuery();

				new MainForm(con).ShowDialog();
			} catch (Exception ex) {
				MessageBox.Show("Произошла ошибка. " + ex.Message, "*_*", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
