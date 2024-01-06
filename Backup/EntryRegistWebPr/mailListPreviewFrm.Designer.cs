namespace EntryRegistWebPr {
	partial class mailListPreviewFrm {
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
			this.components = new System.ComponentModel.Container();
			this.aDGV = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.検索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.registedNumsLbl = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.削除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.registFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// aDGV
			// 
			this.aDGV.AllowUserToAddRows = false;
			this.aDGV.AllowUserToDeleteRows = false;
			this.aDGV.AllowUserToResizeColumns = false;
			this.aDGV.AllowUserToResizeRows = false;
			this.aDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.aDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.aDGV.Location = new System.Drawing.Point(0, 29);
			this.aDGV.Name = "aDGV";
			this.aDGV.RowHeadersWidth = 35;
			this.aDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.aDGV.RowTemplate.Height = 21;
			this.aDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.aDGV.Size = new System.Drawing.Size(535, 556);
			this.aDGV.TabIndex = 36;
			this.aDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellDoubleClick);
			this.aDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.aDGV_RowPostPaint);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(533, 26);
			this.menuStrip1.TabIndex = 37;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registFormToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.閉じるToolStripMenuItem});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// 閉じるToolStripMenuItem
			// 
			this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
			this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.閉じるToolStripMenuItem.Text = "閉じる";
			this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
			// 
			// 編集ToolStripMenuItem
			// 
			this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.検索ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.削除ToolStripMenuItem});
			this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
			this.編集ToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
			this.編集ToolStripMenuItem.Text = "編集(&E)";
			// 
			// 削除ToolStripMenuItem
			// 
			this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
			this.削除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.削除ToolStripMenuItem.Text = "削除";
			this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// 検索ToolStripMenuItem
			// 
			this.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem";
			this.検索ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.検索ToolStripMenuItem.Text = "検索";
			this.検索ToolStripMenuItem.Click += new System.EventHandler(this.検索ToolStripMenuItem_Click);
			// 
			// registedNumsLbl
			// 
			this.registedNumsLbl.AutoSize = true;
			this.registedNumsLbl.Location = new System.Drawing.Point(452, 9);
			this.registedNumsLbl.Name = "registedNumsLbl";
			this.registedNumsLbl.Size = new System.Drawing.Size(53, 12);
			this.registedNumsLbl.TabIndex = 38;
			this.registedNumsLbl.Text = "登録件数";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem,
            this.削除ToolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.EditToolStripMenuItem.Text = "編集";
			this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// 削除ToolStripMenuItem1
			// 
			this.削除ToolStripMenuItem1.Name = "削除ToolStripMenuItem1";
			this.削除ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
			this.削除ToolStripMenuItem1.Text = "削除";
			this.削除ToolStripMenuItem1.Click += new System.EventHandler(this.削除ToolStripMenuItem1_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exportToolStripMenuItem.Text = "エクスポート";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
			// 
			// registFormToolStripMenuItem
			// 
			this.registFormToolStripMenuItem.Name = "registFormToolStripMenuItem";
			this.registFormToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.registFormToolStripMenuItem.Text = "登録フォームを開く";
			this.registFormToolStripMenuItem.Click += new System.EventHandler(this.registFormToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 588);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(533, 23);
			this.statusStrip1.TabIndex = 39;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 18);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(134, 18);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// mailListPreviewFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 611);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.aDGV);
			this.Controls.Add(this.registedNumsLbl);
			this.Controls.Add(this.menuStrip1);
			this.Name = "mailListPreviewFrm";
			this.Text = "mailListPreviewFrm";
			this.Load += new System.EventHandler(this.mailListPreviewFrm_Load);
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
		public System.Windows.Forms.DataGridView aDGV;
		private System.Windows.Forms.Label registedNumsLbl;
		private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 検索ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem registFormToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
	}
}