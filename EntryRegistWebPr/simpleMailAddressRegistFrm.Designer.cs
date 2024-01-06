namespace EntryRegistWebPr {
	partial class simpleMailAddressRegistFrm {
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
			this.cancelBtn = new System.Windows.Forms.Button();
			this.RegistBtn = new System.Windows.Forms.Button();
			this.mailAddressTextBox = new System.Windows.Forms.TextBox();
			this.personNameTextBox = new System.Windows.Forms.TextBox();
			this.jcblNumberTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(279, 194);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(85, 23);
			this.cancelBtn.TabIndex = 112;
			this.cancelBtn.Text = "キャンセル";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// RegistBtn
			// 
			this.RegistBtn.Location = new System.Drawing.Point(108, 194);
			this.RegistBtn.Name = "RegistBtn";
			this.RegistBtn.Size = new System.Drawing.Size(85, 23);
			this.RegistBtn.TabIndex = 111;
			this.RegistBtn.Text = "登録";
			this.RegistBtn.UseVisualStyleBackColor = true;
			this.RegistBtn.Click += new System.EventHandler(this.RegistBtn_Click);
			// 
			// mailAddressTextBox
			// 
			this.mailAddressTextBox.Location = new System.Drawing.Point(130, 106);
			this.mailAddressTextBox.Name = "mailAddressTextBox";
			this.mailAddressTextBox.Size = new System.Drawing.Size(323, 19);
			this.mailAddressTextBox.TabIndex = 110;
			this.mailAddressTextBox.Leave += new System.EventHandler(this.mailAddressTextBox_Leave);
			// 
			// personNameTextBox
			// 
			this.personNameTextBox.Location = new System.Drawing.Point(130, 75);
			this.personNameTextBox.Name = "personNameTextBox";
			this.personNameTextBox.ReadOnly = true;
			this.personNameTextBox.Size = new System.Drawing.Size(141, 19);
			this.personNameTextBox.TabIndex = 109;
			this.personNameTextBox.TabStop = false;
			// 
			// jcblNumberTextBox
			// 
			this.jcblNumberTextBox.Enabled = false;
			this.jcblNumberTextBox.Location = new System.Drawing.Point(130, 46);
			this.jcblNumberTextBox.Name = "jcblNumberTextBox";
			this.jcblNumberTextBox.ReadOnly = true;
			this.jcblNumberTextBox.Size = new System.Drawing.Size(141, 19);
			this.jcblNumberTextBox.TabIndex = 108;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 12);
			this.label3.TabIndex = 107;
			this.label3.Text = "メールアドレス";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 106;
			this.label2.Text = "姓名";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 12);
			this.label1.TabIndex = 105;
			this.label1.Text = "JCBL会員番号";
			// 
			// simpleMailAddressRegistFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 262);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.RegistBtn);
			this.Controls.Add(this.mailAddressTextBox);
			this.Controls.Add(this.personNameTextBox);
			this.Controls.Add(this.jcblNumberTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "simpleMailAddressRegistFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "simpleMailAddressRegistFrm";
			this.Load += new System.EventHandler(this.mailAddressRegistFrm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mailAddressRegistFrm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button RegistBtn;
		private System.Windows.Forms.TextBox mailAddressTextBox;
		private System.Windows.Forms.TextBox personNameTextBox;
		private System.Windows.Forms.TextBox jcblNumberTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}