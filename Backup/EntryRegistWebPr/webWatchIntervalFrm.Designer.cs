namespace EntryRegistWebPr {
	partial class webWatchIntervalFrm {
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
			this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OkBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(111, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 12);
			this.label1.TabIndex = 13;
			this.label1.Text = "監視間隔(秒)";
			// 
			// intervalNumericUpDown
			// 
			this.intervalNumericUpDown.Location = new System.Drawing.Point(198, 37);
			this.intervalNumericUpDown.Name = "intervalNumericUpDown";
			this.intervalNumericUpDown.Size = new System.Drawing.Size(78, 19);
			this.intervalNumericUpDown.TabIndex = 12;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(228, 99);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// OkBtn
			// 
			this.OkBtn.Location = new System.Drawing.Point(113, 99);
			this.OkBtn.Name = "OkBtn";
			this.OkBtn.Size = new System.Drawing.Size(75, 23);
			this.OkBtn.TabIndex = 10;
			this.OkBtn.Text = "OK";
			this.OkBtn.UseVisualStyleBackColor = true;
			this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
			// 
			// webWatchIntervalFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 159);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.intervalNumericUpDown);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OkBtn);
			this.Name = "webWatchIntervalFrm";
			this.Text = "wWebエントリー監視間隔設定";
			this.Load += new System.EventHandler(this.webWatchIntervalFrm_Load);
			((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		protected System.Windows.Forms.NumericUpDown intervalNumericUpDown;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OkBtn;
	}
}