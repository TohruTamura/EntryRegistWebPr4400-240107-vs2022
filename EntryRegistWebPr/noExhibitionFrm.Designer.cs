namespace EntryRegistWebPr
{
    partial class noExhibitionFrm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.aDGV = new System.Windows.Forms.DataGridView();
			this.deleteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.JCBLNumberTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.searchBtn = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.閉じるXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).BeginInit();
			this.deleteContextMenuStrip.SuspendLayout();
			this.panel2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// aDGV
			// 
			this.aDGV.AllowUserToAddRows = false;
			this.aDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.aDGV.ContextMenuStrip = this.deleteContextMenuStrip;
			this.aDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.aDGV.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.aDGV.Location = new System.Drawing.Point(25, 74);
			this.aDGV.Name = "aDGV";
			this.aDGV.RowTemplate.Height = 21;
			this.aDGV.Size = new System.Drawing.Size(400, 500);
			this.aDGV.TabIndex = 0;
			this.aDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellValueChanged);
			this.aDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.aDGV_RowPostPaint);
			this.aDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.aDGV_CellValidating);
			// 
			// deleteContextMenuStrip
			// 
			this.deleteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除ToolStripMenuItem});
			this.deleteContextMenuStrip.Name = "deleteContextMenuStrip";
			this.deleteContextMenuStrip.Size = new System.Drawing.Size(101, 26);
			this.deleteContextMenuStrip.Text = "削除";
			// 
			// 削除ToolStripMenuItem
			// 
			this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
			this.削除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.削除ToolStripMenuItem.Text = "削除";
			this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.JCBLNumberTextBox);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.searchBtn);
			this.panel2.Location = new System.Drawing.Point(25, 26);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(402, 41);
			this.panel2.TabIndex = 102;
			// 
			// JCBLNumberTextBox
			// 
			this.JCBLNumberTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.JCBLNumberTextBox.Location = new System.Drawing.Point(97, 11);
			this.JCBLNumberTextBox.Name = "JCBLNumberTextBox";
			this.JCBLNumberTextBox.Size = new System.Drawing.Size(164, 19);
			this.JCBLNumberTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "会員番号";
			// 
			// searchBtn
			// 
			this.searchBtn.Location = new System.Drawing.Point(277, 9);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(75, 23);
			this.searchBtn.TabIndex = 2;
			this.searchBtn.Text = "検索";
			this.searchBtn.UseVisualStyleBackColor = true;
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.EditToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(461, 26);
			this.menuStrip1.TabIndex = 103;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.importStripMenuItem,
            this.toolStripSeparator1,
            this.閉じるXToolStripMenuItem});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// saveStripMenuItem
			// 
			this.saveStripMenuItem.Name = "saveStripMenuItem";
			this.saveStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.saveStripMenuItem.Text = "保存";
			this.saveStripMenuItem.Click += new System.EventHandler(this.saveStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.exportToolStripMenuItem.Text = "エクスポート";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// importStripMenuItem
			// 
			this.importStripMenuItem.Name = "importStripMenuItem";
			this.importStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.importStripMenuItem.Text = "インポート";
			this.importStripMenuItem.Click += new System.EventHandler(this.importStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			// 
			// 閉じるXToolStripMenuItem
			// 
			this.閉じるXToolStripMenuItem.Name = "閉じるXToolStripMenuItem";
			this.閉じるXToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.閉じるXToolStripMenuItem.Text = "閉じる(&X)";
			this.閉じるXToolStripMenuItem.Click += new System.EventHandler(this.閉じるXToolStripMenuItem_Click);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.allDeleteToolStripMenuItem});
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
			this.EditToolStripMenuItem.Text = "編集";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.deleteToolStripMenuItem.Text = "削除";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// allDeleteToolStripMenuItem
			// 
			this.allDeleteToolStripMenuItem.Name = "allDeleteToolStripMenuItem";
			this.allDeleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.allDeleteToolStripMenuItem.Text = "全てを削除";
			this.allDeleteToolStripMenuItem.Click += new System.EventHandler(this.allDeleteToolStripMenuItem_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// noExhibitionFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 584);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.aDGV);
			this.Name = "noExhibitionFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "非公開メンバー登録";
			this.Load += new System.EventHandler(this.noExhibitionFrm_Load);
			this.Shown += new System.EventHandler(this.HomePageFrm_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.noExhibitionFrm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).EndInit();
			this.deleteContextMenuStrip.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.DataGridView aDGV;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox JCBLNumberTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button searchBtn;
		protected System.Windows.Forms.MenuStrip menuStrip1;
		protected System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 閉じるXToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allDeleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ContextMenuStrip deleteContextMenuStrip;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
    }
}