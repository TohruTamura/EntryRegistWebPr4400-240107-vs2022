namespace EntryRegistWebPr {
	partial class webFormatFrm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.shortCenterNameTextBox = new System.Windows.Forms.TextBox();
            this.mailAddressTextBox = new System.Windows.Forms.TextBox();
            this.telNumberTextBox = new System.Windows.Forms.TextBox();
            this.webUrlTextBox = new System.Windows.Forms.TextBox();
            this.initBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.longCenterNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shortセンター名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(21, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "メールアドレス";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(21, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "電話番号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(21, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "URL+フォルダー名";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(134, 323);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "保存";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(324, 323);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "キャンセル";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // shortCenterNameTextBox
            // 
            this.shortCenterNameTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shortCenterNameTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.shortCenterNameTextBox.Location = new System.Drawing.Point(144, 24);
            this.shortCenterNameTextBox.Name = "shortCenterNameTextBox";
            this.shortCenterNameTextBox.Size = new System.Drawing.Size(553, 25);
            this.shortCenterNameTextBox.TabIndex = 0;
            this.shortCenterNameTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // mailAddressTextBox
            // 
            this.mailAddressTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mailAddressTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.mailAddressTextBox.Location = new System.Drawing.Point(144, 143);
            this.mailAddressTextBox.Name = "mailAddressTextBox";
            this.mailAddressTextBox.Size = new System.Drawing.Size(553, 25);
            this.mailAddressTextBox.TabIndex = 2;
            this.mailAddressTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // telNumberTextBox
            // 
            this.telNumberTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.telNumberTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.telNumberTextBox.Location = new System.Drawing.Point(144, 188);
            this.telNumberTextBox.Name = "telNumberTextBox";
            this.telNumberTextBox.Size = new System.Drawing.Size(553, 25);
            this.telNumberTextBox.TabIndex = 3;
            this.telNumberTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // webUrlTextBox
            // 
            this.webUrlTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.webUrlTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.webUrlTextBox.Location = new System.Drawing.Point(144, 229);
            this.webUrlTextBox.Name = "webUrlTextBox";
            this.webUrlTextBox.Size = new System.Drawing.Size(553, 25);
            this.webUrlTextBox.TabIndex = 4;
            this.webUrlTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // initBtn
            // 
            this.initBtn.Location = new System.Drawing.Point(504, 323);
            this.initBtn.Name = "initBtn";
            this.initBtn.Size = new System.Drawing.Size(75, 23);
            this.initBtn.TabIndex = 7;
            this.initBtn.Text = "初期値";
            this.initBtn.UseVisualStyleBackColor = true;
            this.initBtn.Click += new System.EventHandler(this.initBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(25, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Longセンター名";
            // 
            // longCenterNameTextBox
            // 
            this.longCenterNameTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.longCenterNameTextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.longCenterNameTextBox.Location = new System.Drawing.Point(144, 85);
            this.longCenterNameTextBox.Name = "longCenterNameTextBox";
            this.longCenterNameTextBox.Size = new System.Drawing.Size(553, 25);
            this.longCenterNameTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(537, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "(ex. 大船ブリッジセンター)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(425, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "(ex. 特定非営利活動法人 大船ブリッジセンター)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(431, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(266, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "(ex. www.ofunabc.jp/entrySystemOfunaDB)";
            // 
            // webFormatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 383);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.longCenterNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.initBtn);
            this.Controls.Add(this.webUrlTextBox);
            this.Controls.Add(this.telNumberTextBox);
            this.Controls.Add(this.mailAddressTextBox);
            this.Controls.Add(this.shortCenterNameTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "webFormatFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "webFormatFrm";
            this.Load += new System.EventHandler(this.webFormatFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox shortCenterNameTextBox;
		private System.Windows.Forms.TextBox mailAddressTextBox;
		private System.Windows.Forms.TextBox telNumberTextBox;
		private System.Windows.Forms.TextBox webUrlTextBox;
		private System.Windows.Forms.Button initBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox longCenterNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
	}
}