namespace EntryRegistWebPr {
	partial class phpEntryFrm {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testMailBtn = new System.Windows.Forms.Button();
			this.allClearBtn = new System.Windows.Forms.Button();
			this.allCheckBtn = new System.Windows.Forms.Button();
			this.mailNumsLbl = new System.Windows.Forms.Label();
			this.sendBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.mailContentDefaultBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.mailContentTextBox = new System.Windows.Forms.TextBox();
			this.mailContentSaveBtn = new System.Windows.Forms.Button();
			this.mailContentCancelBtn = new System.Windows.Forms.Button();
			this.sendResultTextBox = new System.Windows.Forms.TextBox();
			this.aDGV = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dispAllRadioBtn = new System.Windows.Forms.RadioButton();
			this.dispWebEntryRadioBtn = new System.Windows.Forms.RadioButton();
			this.dispDefaultRadioBtn = new System.Windows.Forms.RadioButton();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1349, 31);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.閉じるToolStripMenuItem});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// 閉じるToolStripMenuItem
			// 
			this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
			this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(125, 28);
			this.閉じるToolStripMenuItem.Text = "閉じる";
			this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
			// 
			// testMailBtn
			// 
			this.testMailBtn.Location = new System.Drawing.Point(1173, 110);
			this.testMailBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.testMailBtn.Name = "testMailBtn";
			this.testMailBtn.Size = new System.Drawing.Size(137, 40);
			this.testMailBtn.TabIndex = 32;
			this.testMailBtn.Text = "テストメール送信";
			this.testMailBtn.UseVisualStyleBackColor = true;
			this.testMailBtn.Click += new System.EventHandler(this.testMailBtn_Click);
			// 
			// allClearBtn
			// 
			this.allClearBtn.Location = new System.Drawing.Point(193, 36);
			this.allClearBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.allClearBtn.Name = "allClearBtn";
			this.allClearBtn.Size = new System.Drawing.Size(137, 38);
			this.allClearBtn.TabIndex = 31;
			this.allClearBtn.Text = "全てをクリア";
			this.allClearBtn.UseVisualStyleBackColor = true;
			this.allClearBtn.Click += new System.EventHandler(this.allClearBtn_Click);
			// 
			// allCheckBtn
			// 
			this.allCheckBtn.Location = new System.Drawing.Point(16, 36);
			this.allCheckBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.allCheckBtn.Name = "allCheckBtn";
			this.allCheckBtn.Size = new System.Drawing.Size(137, 38);
			this.allCheckBtn.TabIndex = 30;
			this.allCheckBtn.Text = "全てをチェック";
			this.allCheckBtn.UseVisualStyleBackColor = true;
			this.allCheckBtn.Click += new System.EventHandler(this.allCheckBtn_Click);
			// 
			// mailNumsLbl
			// 
			this.mailNumsLbl.AutoSize = true;
			this.mailNumsLbl.Location = new System.Drawing.Point(585, 59);
			this.mailNumsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.mailNumsLbl.Name = "mailNumsLbl";
			this.mailNumsLbl.Size = new System.Drawing.Size(67, 15);
			this.mailNumsLbl.TabIndex = 29;
			this.mailNumsLbl.Text = "送付件数";
			// 
			// sendBtn
			// 
			this.sendBtn.Location = new System.Drawing.Point(955, 81);
			this.sendBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.sendBtn.Name = "sendBtn";
			this.sendBtn.Size = new System.Drawing.Size(137, 70);
			this.sendBtn.TabIndex = 28;
			this.sendBtn.Text = "メール送信";
			this.sendBtn.UseVisualStyleBackColor = true;
			this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.mailContentDefaultBtn);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.mailContentTextBox);
			this.groupBox1.Controls.Add(this.mailContentSaveBtn);
			this.groupBox1.Controls.Add(this.mailContentCancelBtn);
			this.groupBox1.Location = new System.Drawing.Point(757, 158);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(565, 674);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "送信メール内容";
			// 
			// mailContentDefaultBtn
			// 
			this.mailContentDefaultBtn.Location = new System.Drawing.Point(393, 449);
			this.mailContentDefaultBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mailContentDefaultBtn.Name = "mailContentDefaultBtn";
			this.mailContentDefaultBtn.Size = new System.Drawing.Size(137, 40);
			this.mailContentDefaultBtn.TabIndex = 28;
			this.mailContentDefaultBtn.Text = "デフォルト値に戻す";
			this.mailContentDefaultBtn.UseVisualStyleBackColor = true;
			this.mailContentDefaultBtn.Click += new System.EventHandler(this.mailContentDefaultBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.LemonChiffon;
			this.textBox1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox1.Location = new System.Drawing.Point(8, 511);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(548, 154);
			this.textBox1.TabIndex = 27;
			this.textBox1.Text = "送信されるメールの内容です。編集もできます。\r\n<name>はそこに姓名が入り、<entry>は受付番号が入ります。\r\n一度も作成していない場合は、競技会情報から" +
				"デフォルト文を表示します。\r\n編集した内容は保存しておくと、次回この競技会を選択した時、表示されます。\r\nキャンセルボタンは編集内容を起動時の状態に戻します。\r" +
				"\nデフォルト文に戻すこともできます。";
			// 
			// mailContentTextBox
			// 
			this.mailContentTextBox.Location = new System.Drawing.Point(9, 22);
			this.mailContentTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mailContentTextBox.Multiline = true;
			this.mailContentTextBox.Name = "mailContentTextBox";
			this.mailContentTextBox.Size = new System.Drawing.Size(547, 403);
			this.mailContentTextBox.TabIndex = 24;
			this.mailContentTextBox.TextChanged += new System.EventHandler(this.mailContentTextBox_TextChanged);
			// 
			// mailContentSaveBtn
			// 
			this.mailContentSaveBtn.Location = new System.Drawing.Point(49, 449);
			this.mailContentSaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mailContentSaveBtn.Name = "mailContentSaveBtn";
			this.mailContentSaveBtn.Size = new System.Drawing.Size(137, 40);
			this.mailContentSaveBtn.TabIndex = 25;
			this.mailContentSaveBtn.Text = "保存";
			this.mailContentSaveBtn.UseVisualStyleBackColor = true;
			this.mailContentSaveBtn.Click += new System.EventHandler(this.mailContentSaveBtn_Click);
			// 
			// mailContentCancelBtn
			// 
			this.mailContentCancelBtn.Location = new System.Drawing.Point(223, 449);
			this.mailContentCancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mailContentCancelBtn.Name = "mailContentCancelBtn";
			this.mailContentCancelBtn.Size = new System.Drawing.Size(137, 40);
			this.mailContentCancelBtn.TabIndex = 26;
			this.mailContentCancelBtn.Text = "キャンセル";
			this.mailContentCancelBtn.UseVisualStyleBackColor = true;
			this.mailContentCancelBtn.Click += new System.EventHandler(this.mailContentCancelBtn_Click);
			// 
			// sendResultTextBox
			// 
			this.sendResultTextBox.Location = new System.Drawing.Point(0, 846);
			this.sendResultTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.sendResultTextBox.Multiline = true;
			this.sendResultTextBox.Name = "sendResultTextBox";
			this.sendResultTextBox.Size = new System.Drawing.Size(1348, 234);
			this.sendResultTextBox.TabIndex = 34;
			// 
			// aDGV
			// 
			this.aDGV.AllowUserToAddRows = false;
			this.aDGV.AllowUserToDeleteRows = false;
			this.aDGV.AllowUserToResizeColumns = false;
			this.aDGV.AllowUserToResizeRows = false;
			this.aDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.aDGV.ContextMenuStrip = this.contextMenuStrip1;
			this.aDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.aDGV.Location = new System.Drawing.Point(0, 81);
			this.aDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.aDGV.Name = "aDGV";
			this.aDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.aDGV.RowTemplate.Height = 21;
			this.aDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.aDGV.Size = new System.Drawing.Size(695, 758);
			this.aDGV.TabIndex = 35;
			this.aDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellValueChanged);
			this.aDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.aDGV_RowPostPaint);
			this.aDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellContentDoubleClick);
			this.aDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.aDGV_CellValidating);
			this.aDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellContentClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(111, 32);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(110, 28);
			this.EditToolStripMenuItem.Text = "編集";
			this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dispAllRadioBtn);
			this.groupBox2.Controls.Add(this.dispWebEntryRadioBtn);
			this.groupBox2.Controls.Add(this.dispDefaultRadioBtn);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(701, 48);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(224, 100);
			this.groupBox2.TabIndex = 36;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "表示";
			// 
			// dispAllRadioBtn
			// 
			this.dispAllRadioBtn.AutoSize = true;
			this.dispAllRadioBtn.Location = new System.Drawing.Point(13, 75);
			this.dispAllRadioBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dispAllRadioBtn.Name = "dispAllRadioBtn";
			this.dispAllRadioBtn.Size = new System.Drawing.Size(55, 19);
			this.dispAllRadioBtn.TabIndex = 2;
			this.dispAllRadioBtn.TabStop = true;
			this.dispAllRadioBtn.Text = "全て";
			this.dispAllRadioBtn.UseVisualStyleBackColor = true;
			this.dispAllRadioBtn.CheckedChanged += new System.EventHandler(this.dispRadioBtn_CheckedChanged);
			// 
			// dispWebEntryRadioBtn
			// 
			this.dispWebEntryRadioBtn.AutoSize = true;
			this.dispWebEntryRadioBtn.Location = new System.Drawing.Point(13, 46);
			this.dispWebEntryRadioBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dispWebEntryRadioBtn.Name = "dispWebEntryRadioBtn";
			this.dispWebEntryRadioBtn.Size = new System.Drawing.Size(108, 19);
			this.dispWebEntryRadioBtn.TabIndex = 1;
			this.dispWebEntryRadioBtn.TabStop = true;
			this.dispWebEntryRadioBtn.Text = "web申込のみ";
			this.dispWebEntryRadioBtn.UseVisualStyleBackColor = true;
			this.dispWebEntryRadioBtn.CheckedChanged += new System.EventHandler(this.dispRadioBtn_CheckedChanged);
			// 
			// dispDefaultRadioBtn
			// 
			this.dispDefaultRadioBtn.AutoSize = true;
			this.dispDefaultRadioBtn.Location = new System.Drawing.Point(13, 21);
			this.dispDefaultRadioBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dispDefaultRadioBtn.Name = "dispDefaultRadioBtn";
			this.dispDefaultRadioBtn.Size = new System.Drawing.Size(186, 19);
			this.dispDefaultRadioBtn.TabIndex = 0;
			this.dispDefaultRadioBtn.TabStop = true;
			this.dispDefaultRadioBtn.Text = "Web申込+Mail Address有";
			this.dispDefaultRadioBtn.UseVisualStyleBackColor = true;
			this.dispDefaultRadioBtn.CheckedChanged += new System.EventHandler(this.dispRadioBtn_CheckedChanged);
			// 
			// phpEntryFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1349, 1057);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.aDGV);
			this.Controls.Add(this.sendResultTextBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.testMailBtn);
			this.Controls.Add(this.allClearBtn);
			this.Controls.Add(this.allCheckBtn);
			this.Controls.Add(this.mailNumsLbl);
			this.Controls.Add(this.sendBtn);
			this.Controls.Add(this.menuStrip1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "phpEntryFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "受付メール送信";
			this.Load += new System.EventHandler(this.phpEntryFrm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.aDGV)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
		private System.Windows.Forms.Button testMailBtn;
		private System.Windows.Forms.Button allClearBtn;
		private System.Windows.Forms.Button allCheckBtn;
		private System.Windows.Forms.Label mailNumsLbl;
		private System.Windows.Forms.Button sendBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button mailContentDefaultBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox mailContentTextBox;
		private System.Windows.Forms.Button mailContentSaveBtn;
		private System.Windows.Forms.Button mailContentCancelBtn;
		private System.Windows.Forms.TextBox sendResultTextBox;
		private System.Windows.Forms.DataGridView aDGV;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton dispDefaultRadioBtn;
		private System.Windows.Forms.RadioButton dispAllRadioBtn;
		private System.Windows.Forms.RadioButton dispWebEntryRadioBtn;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
	}
}