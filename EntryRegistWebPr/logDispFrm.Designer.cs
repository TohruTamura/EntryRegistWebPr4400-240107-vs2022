namespace EntryRegistWebPr {
	partial class logDispFrm {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.閉じるXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全行削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDGV = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 26);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.閉じるXToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // 閉じるXToolStripMenuItem
            // 
            this.閉じるXToolStripMenuItem.Name = "閉じるXToolStripMenuItem";
            this.閉じるXToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.閉じるXToolStripMenuItem.Text = "閉じる(&X)";
            this.閉じるXToolStripMenuItem.Click += new System.EventHandler(this.閉じるXToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.行削除ToolStripMenuItem,
            this.全行削除ToolStripMenuItem});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // 行削除ToolStripMenuItem
            // 
            this.行削除ToolStripMenuItem.Name = "行削除ToolStripMenuItem";
            this.行削除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.行削除ToolStripMenuItem.Text = "行削除";
            this.行削除ToolStripMenuItem.Click += new System.EventHandler(this.行削除ToolStripMenuItem_Click);
            // 
            // 全行削除ToolStripMenuItem
            // 
            this.全行削除ToolStripMenuItem.Name = "全行削除ToolStripMenuItem";
            this.全行削除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全行削除ToolStripMenuItem.Text = "全行削除";
            this.全行削除ToolStripMenuItem.Click += new System.EventHandler(this.全行削除ToolStripMenuItem_Click);
            // 
            // aDGV
            // 
            this.aDGV.AllowUserToAddRows = false;
            this.aDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.aDGV.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.aDGV.Location = new System.Drawing.Point(0, 29);
            this.aDGV.Name = "aDGV";
            this.aDGV.RowHeadersWidth = 35;
            this.aDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.aDGV.RowTemplate.Height = 21;
            this.aDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aDGV.Size = new System.Drawing.Size(1039, 578);
            this.aDGV.TabIndex = 105;
            this.aDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.aDGV_RowPostPaint);
            // 
            // logDispFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 609);
            this.Controls.Add(this.aDGV);
            this.Controls.Add(this.menuStrip1);
            this.Name = "logDispFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "logDispFrm";
            this.Load += new System.EventHandler(this.logDispFrm_Load);
            this.Shown += new System.EventHandler(this.logDispFrm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.MenuStrip menuStrip1;
		protected System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 閉じるXToolStripMenuItem;
		private System.Windows.Forms.DataGridView aDGV;
		private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 行削除ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 全行削除ToolStripMenuItem;
	}
}