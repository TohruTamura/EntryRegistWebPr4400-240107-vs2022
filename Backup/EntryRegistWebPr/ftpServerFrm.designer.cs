namespace EntryRegistWebPr {
    partial class ftpServerFrm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.ftpServerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ftpAccountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.ConnectTestBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.homePageURLTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ftpDefaultFolderTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.entryFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.webDbPasswordtextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTPサーバー名";
            // 
            // ftpServerTextBox
            // 
            this.ftpServerTextBox.AcceptsReturn = true;
            this.ftpServerTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ftpServerTextBox.Location = new System.Drawing.Point(119, 14);
            this.ftpServerTextBox.Name = "ftpServerTextBox";
            this.ftpServerTextBox.Size = new System.Drawing.Size(284, 20);
            this.ftpServerTextBox.TabIndex = 0;
            this.ftpServerTextBox.TextChanged += new System.EventHandler(this.ftpServerTextBox_TextChanged);
            this.ftpServerTextBox.Enter += new System.EventHandler(this.ftpServerTextBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "FTPアカウント名";
            // 
            // ftpAccountTextBox
            // 
            this.ftpAccountTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ftpAccountTextBox.Location = new System.Drawing.Point(119, 105);
            this.ftpAccountTextBox.Name = "ftpAccountTextBox";
            this.ftpAccountTextBox.Size = new System.Drawing.Size(284, 20);
            this.ftpAccountTextBox.TabIndex = 2;
            this.ftpAccountTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            this.ftpAccountTextBox.Enter += new System.EventHandler(this.userNameTextBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(246, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "例 tamura@yokohamabc.or.jp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "FTPパスワード";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(305, 410);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(109, 33);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "キャンセル";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(110, 410);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(109, 33);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "保存";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.passwordTextBox.Location = new System.Drawing.Point(112, 143);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '●';
            this.passwordTextBox.Size = new System.Drawing.Size(284, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(16, 21);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(109, 33);
            this.exportBtn.TabIndex = 0;
            this.exportBtn.Text = "設定のエクスポート";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(16, 69);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(109, 33);
            this.importBtn.TabIndex = 1;
            this.importBtn.Text = "設定のインポート";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // ConnectTestBtn
            // 
            this.ConnectTestBtn.Location = new System.Drawing.Point(16, 118);
            this.ConnectTestBtn.Name = "ConnectTestBtn";
            this.ConnectTestBtn.Size = new System.Drawing.Size(109, 33);
            this.ConnectTestBtn.TabIndex = 2;
            this.ConnectTestBtn.Text = "接続テスト";
            this.ConnectTestBtn.UseVisualStyleBackColor = true;
            this.ConnectTestBtn.Click += new System.EventHandler(this.ConnectTestBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(246, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "例 ftp.yokohamabc.or.jp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(244, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "例 www.ofunabc.or.jp";
            // 
            // homePageURLTextBox
            // 
            this.homePageURLTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.homePageURLTextBox.Location = new System.Drawing.Point(117, 14);
            this.homePageURLTextBox.Name = "homePageURLTextBox";
            this.homePageURLTextBox.Size = new System.Drawing.Size(284, 20);
            this.homePageURLTextBox.TabIndex = 0;
            this.homePageURLTextBox.TextChanged += new System.EventHandler(this.homePageURLTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "ホームページ URL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exportBtn);
            this.panel1.Controls.Add(this.importBtn);
            this.panel1.Controls.Add(this.ConnectTestBtn);
            this.panel1.Location = new System.Drawing.Point(433, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 175);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ftpDefaultFolderTextBox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ftpServerTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ftpAccountTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.passwordTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 175);
            this.panel2.TabIndex = 40;
            // 
            // ftpDefaultFolderTextBox
            // 
            this.ftpDefaultFolderTextBox.AcceptsReturn = true;
            this.ftpDefaultFolderTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ftpDefaultFolderTextBox.Location = new System.Drawing.Point(119, 65);
            this.ftpDefaultFolderTextBox.Name = "ftpDefaultFolderTextBox";
            this.ftpDefaultFolderTextBox.Size = new System.Drawing.Size(284, 20);
            this.ftpDefaultFolderTextBox.TabIndex = 1;
            this.ftpDefaultFolderTextBox.TextChanged += new System.EventHandler(this.ftpDefaultFolderTextBox_TextChanged);
            this.ftpDefaultFolderTextBox.Enter += new System.EventHandler(this.ftpDefaultFolderTextBox_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "FTP初期フォルダ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.homePageURLTextBox);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 55);
            this.panel3.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.entryFolderNameTextBox);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(12, 261);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(412, 55);
            this.panel4.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(246, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "例 entrySystemOfuna";
            // 
            // entryFolderNameTextBox
            // 
            this.entryFolderNameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.entryFolderNameTextBox.Location = new System.Drawing.Point(119, 16);
            this.entryFolderNameTextBox.Name = "entryFolderNameTextBox";
            this.entryFolderNameTextBox.Size = new System.Drawing.Size(284, 20);
            this.entryFolderNameTextBox.TabIndex = 0;
            this.entryFolderNameTextBox.TextChanged += new System.EventHandler(this.webFolderNameTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "Webエントリーフォルダ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.webDbPasswordtextBox);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(12, 322);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(412, 55);
            this.panel5.TabIndex = 44;
            // 
            // webDbPasswordtextBox
            // 
            this.webDbPasswordtextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.webDbPasswordtextBox.Location = new System.Drawing.Point(119, 16);
            this.webDbPasswordtextBox.Name = "webDbPasswordtextBox";
            this.webDbPasswordtextBox.Size = new System.Drawing.Size(284, 20);
            this.webDbPasswordtextBox.TabIndex = 0;
            this.webDbPasswordtextBox.TextChanged += new System.EventHandler(this.webDbPasswordtextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 12);
            this.label11.TabIndex = 39;
            this.label11.Text = "Web DB パスワード";
            // 
            // ftpServerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 480);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Name = "ftpServerFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ftpServerの設定";
            this.Load += new System.EventHandler(this.ftpServerFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ftpServerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ftpAccountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button CancelBtn;
        internal System.Windows.Forms.Button OkBtn;
		private System.Windows.Forms.TextBox passwordTextBox;
        internal System.Windows.Forms.Button exportBtn;
		internal System.Windows.Forms.Button importBtn;
		internal System.Windows.Forms.Button ConnectTestBtn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox homePageURLTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox entryFolderNameTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox webDbPasswordtextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox ftpDefaultFolderTextBox;
		private System.Windows.Forms.Label label10;
    }
}