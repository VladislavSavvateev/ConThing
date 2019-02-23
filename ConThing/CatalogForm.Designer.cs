namespace ConThing {
	partial class CatalogForm {
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
			this.lstCatalog = new System.Windows.Forms.ListView();
			this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstCatalog
			// 
			this.lstCatalog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colPrice,
            this.colQuantity,
            this.columnHeader1});
			this.lstCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCatalog.FullRowSelect = true;
			this.lstCatalog.Location = new System.Drawing.Point(0, 24);
			this.lstCatalog.Name = "lstCatalog";
			this.lstCatalog.Size = new System.Drawing.Size(467, 349);
			this.lstCatalog.TabIndex = 0;
			this.lstCatalog.UseCompatibleStateImageBehavior = false;
			this.lstCatalog.View = System.Windows.Forms.View.Details;
			this.lstCatalog.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstCatalog_ItemSelectionChanged);
			this.lstCatalog.DoubleClick += new System.EventHandler(this.lstCatalog_DoubleClick);
			this.lstCatalog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatalogForm_KeyDown);
			// 
			// colId
			// 
			this.colId.Text = "ID";
			// 
			// colName
			// 
			this.colName.Text = "Имя";
			// 
			// colPrice
			// 
			this.colPrice.Text = "Цена";
			// 
			// colQuantity
			// 
			this.colQuantity.Text = "Количество";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(467, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuAdd
			// 
			this.menuAdd.Name = "menuAdd";
			this.menuAdd.Size = new System.Drawing.Size(80, 20);
			this.menuAdd.Text = "Добавить...";
			this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Путь до изображения";
			// 
			// CatalogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 373);
			this.Controls.Add(this.lstCatalog);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "CatalogForm";
			this.Text = "Каталог";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CatalogForm_FormClosing);
			this.Load += new System.EventHandler(this.CatalogForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatalogForm_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lstCatalog;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ColumnHeader colId;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colPrice;
		private System.Windows.Forms.ColumnHeader colQuantity;
		private System.Windows.Forms.ToolStripMenuItem menuAdd;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}