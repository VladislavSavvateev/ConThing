namespace ConThing {
	partial class DBForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstDBs = new System.Windows.Forms.ListBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnCreateNew = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lstDBs);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 199);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Файл с БД";
			// 
			// lstDBs
			// 
			this.lstDBs.FormattingEnabled = true;
			this.lstDBs.Location = new System.Drawing.Point(6, 19);
			this.lstDBs.Name = "lstDBs";
			this.lstDBs.Size = new System.Drawing.Size(356, 173);
			this.lstDBs.TabIndex = 0;
			this.lstDBs.DoubleClick += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(305, 217);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Открыть";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnCreateNew
			// 
			this.btnCreateNew.Location = new System.Drawing.Point(12, 217);
			this.btnCreateNew.Name = "btnCreateNew";
			this.btnCreateNew.Size = new System.Drawing.Size(109, 23);
			this.btnCreateNew.TabIndex = 2;
			this.btnCreateNew.Text = "Добавить новую...";
			this.btnCreateNew.UseVisualStyleBackColor = true;
			this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
			// 
			// DBForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 252);
			this.Controls.Add(this.btnCreateNew);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "DBForm";
			this.Text = "Выберите файл с БД";
			this.Load += new System.EventHandler(this.DBForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lstDBs;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCreateNew;
	}
}

