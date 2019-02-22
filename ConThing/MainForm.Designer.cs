namespace ConThing {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lstSells = new System.Windows.Forms.ListView();
			this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCatalog = new System.Windows.Forms.ToolStripMenuItem();
			this.menuIncoming = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstSells
			// 
			this.lstSells.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colPrice,
            this.colQuantity,
            this.colTotal});
			this.lstSells.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstSells.FullRowSelect = true;
			this.lstSells.Location = new System.Drawing.Point(0, 24);
			this.lstSells.Name = "lstSells";
			this.lstSells.Size = new System.Drawing.Size(446, 350);
			this.lstSells.TabIndex = 0;
			this.lstSells.UseCompatibleStateImageBehavior = false;
			this.lstSells.View = System.Windows.Forms.View.Details;
			this.lstSells.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSells_KeyDown);
			// 
			// colId
			// 
			this.colId.Text = "ID";
			this.colId.Width = 25;
			// 
			// colName
			// 
			this.colName.Text = "Название";
			this.colName.Width = 62;
			// 
			// colPrice
			// 
			this.colPrice.Text = "Стоимость";
			this.colPrice.Width = 67;
			// 
			// colQuantity
			// 
			this.colQuantity.Text = "Кол-во";
			this.colQuantity.Width = 46;
			// 
			// colTotal
			// 
			this.colTotal.Text = "Итог";
			this.colTotal.Width = 242;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuCatalog,
            this.menuIncoming});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(446, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSells_KeyDown);
			// 
			// menuAdd
			// 
			this.menuAdd.Name = "menuAdd";
			this.menuAdd.Size = new System.Drawing.Size(159, 20);
			this.menuAdd.Text = "Добавить новую запись...";
			this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
			// 
			// menuCatalog
			// 
			this.menuCatalog.Name = "menuCatalog";
			this.menuCatalog.Size = new System.Drawing.Size(62, 20);
			this.menuCatalog.Text = "Каталог";
			this.menuCatalog.Click += new System.EventHandler(this.menuCatalog_Click);
			// 
			// menuIncoming
			// 
			this.menuIncoming.Name = "menuIncoming";
			this.menuIncoming.Size = new System.Drawing.Size(61, 20);
			this.menuIncoming.Text = "Доход...";
			this.menuIncoming.Click += new System.EventHandler(this.menuIncoming_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 374);
			this.Controls.Add(this.lstSells);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "ConThing";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSells_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lstSells;
		private System.Windows.Forms.ColumnHeader colId;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colPrice;
		private System.Windows.Forms.ColumnHeader colQuantity;
		private System.Windows.Forms.ColumnHeader colTotal;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuAdd;
		private System.Windows.Forms.ToolStripMenuItem menuCatalog;
		private System.Windows.Forms.ToolStripMenuItem menuIncoming;
	}
}