namespace EntryRegistWebPr {
	partial class jcblInfoToDbUploadFrm {
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
            this.aDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.memberRegistCheckBox = new System.Windows.Forms.CheckBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.CanceｌBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.monthOfAccessData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aDGV)).BeginInit();
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
            this.aDGV.Location = new System.Drawing.Point(21, 24);
            this.aDGV.Name = "aDGV";
            this.aDGV.RowHeadersWidth = 20;
            this.aDGV.RowTemplate.Height = 21;
            this.aDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.aDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aDGV.Size = new System.Drawing.Size(220, 328);
            this.aDGV.TabIndex = 38;
            this.aDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.aDGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "既存DataOnWebDb";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 358);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 23);
            this.progressBar1.TabIndex = 47;
            // 
            // memberRegistCheckBox
            // 
            this.memberRegistCheckBox.AutoSize = true;
            this.memberRegistCheckBox.Location = new System.Drawing.Point(303, 288);
            this.memberRegistCheckBox.Name = "memberRegistCheckBox";
            this.memberRegistCheckBox.Size = new System.Drawing.Size(105, 16);
            this.memberRegistCheckBox.TabIndex = 46;
            this.memberRegistCheckBox.Text = "会員情報を更新";
            this.memberRegistCheckBox.UseVisualStyleBackColor = true;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(303, 88);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 30);
            this.delBtn.TabIndex = 45;
            this.delBtn.Text = "削除";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTextBox.Location = new System.Drawing.Point(1, 398);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(494, 203);
            this.messageTextBox.TabIndex = 44;
            // 
            // CanceｌBtn
            // 
            this.CanceｌBtn.Location = new System.Drawing.Point(303, 152);
            this.CanceｌBtn.Name = "CanceｌBtn";
            this.CanceｌBtn.Size = new System.Drawing.Size(75, 30);
            this.CanceｌBtn.TabIndex = 41;
            this.CanceｌBtn.Text = "キャンセル";
            this.CanceｌBtn.UseVisualStyleBackColor = true;
            this.CanceｌBtn.Click += new System.EventHandler(this.CanceｌBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(303, 212);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(75, 30);
            this.uploadBtn.TabIndex = 40;
            this.uploadBtn.Text = "アップロード";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // monthOfAccessData
            // 
            this.monthOfAccessData.AutoSize = true;
            this.monthOfAccessData.Location = new System.Drawing.Point(280, 24);
            this.monthOfAccessData.Name = "monthOfAccessData";
            this.monthOfAccessData.Size = new System.Drawing.Size(117, 12);
            this.monthOfAccessData.TabIndex = 48;
            this.monthOfAccessData.Text = "Accessの最新データ月";
            // 
            // jcblInfoToDbUploadFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 606);
            this.Controls.Add(this.monthOfAccessData);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.memberRegistCheckBox);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.CanceｌBtn);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aDGV);
            this.Name = "jcblInfoToDbUploadFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "jcblInfoToDbUploadFrm";
            this.Shown += new System.EventHandler(this.jcblInfoToDbUploadFrm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.aDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView aDGV;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.CheckBox memberRegistCheckBox;
		private System.Windows.Forms.Button delBtn;
		private System.Windows.Forms.TextBox messageTextBox;
		private System.Windows.Forms.Button CanceｌBtn;
		private System.Windows.Forms.Button uploadBtn;
		private System.Windows.Forms.Label monthOfAccessData;
	}
}