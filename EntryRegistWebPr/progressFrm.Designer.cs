namespace EntryRegistWebPr {
	partial class progressFrm {
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.resultTextBox = new System.Windows.Forms.TextBox();
			this.numsTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(77, 72);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(458, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(160, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(266, 31);
			this.label1.TabIndex = 1;
			this.label1.Text = "ウェブエントリーを処理中";
			// 
			// resultTextBox
			// 
			this.resultTextBox.BackColor = System.Drawing.Color.White;
			this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.resultTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.resultTextBox.Location = new System.Drawing.Point(12, 135);
			this.resultTextBox.Name = "resultTextBox";
			this.resultTextBox.ReadOnly = true;
			this.resultTextBox.Size = new System.Drawing.Size(603, 13);
			this.resultTextBox.TabIndex = 3;
			this.resultTextBox.TabStop = false;
			this.resultTextBox.Text = "result";
			this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// numsTextBox
			// 
			this.numsTextBox.BackColor = System.Drawing.Color.White;
			this.numsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.numsTextBox.Location = new System.Drawing.Point(467, 101);
			this.numsTextBox.Name = "numsTextBox";
			this.numsTextBox.Size = new System.Drawing.Size(68, 12);
			this.numsTextBox.TabIndex = 4;
			this.numsTextBox.Text = "10件";
			this.numsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// progressFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(627, 166);
			this.Controls.Add(this.numsTextBox);
			this.Controls.Add(this.resultTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "progressFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "progressFrm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox resultTextBox;
		public System.Windows.Forms.TextBox numsTextBox;
	}
}