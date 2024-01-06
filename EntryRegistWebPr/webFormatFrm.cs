using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	public partial class webFormatFrm : Form {
	
		private bool mFirstFlag=true;
		
		public webFormatFrm() {
			InitializeComponent();
		}

		private void webFormatFrm_Load(object sender, EventArgs e) {
			setDbDataToTextBox(1);
			okBtn.Enabled=false;
			mFirstFlag=false;
		}
		
		private void setDbDataToTextBox(int id){
			webFormatClass aWebFormatC=webFormatClass.getWebFormatFromDB(id);
			shortCenterNameTextBox.Text=aWebFormatC.ShortCenterName;
			mailAddressTextBox.Text=aWebFormatC.MailAddress;
			telNumberTextBox.Text=aWebFormatC.TelNumber;
            longCenterNameTextBox.Text = aWebFormatC.LongCenterName;
            webUrlTextBox.Text = aWebFormatC.UrlAndFolderName;					
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void initBtn_Click(object sender, EventArgs e) {
			setDbDataToTextBox(0);
		}
		
		private void okBtn_Click(object sender, EventArgs e) {
			//textBoxから取得
			webFormatClass aClass=new webFormatClass(){
				ShortCenterName=shortCenterNameTextBox.Text,
				MailAddress=mailAddressTextBox.Text,
				TelNumber=telNumberTextBox.Text,
	            LongCenterName=longCenterNameTextBox.Text,
                UrlAndFolderName=webUrlTextBox.Text					
			};
			List<webFormatClass> aList=new List<webFormatClass>();
			aList.Add(aClass);
			//保存
			Cursor.Current=Cursors.WaitCursor;
			string s = new JavaScriptSerializer().Serialize(aList);
			string result = ftpUploadClass.uploadDispDataString(webFormatClass.WEB_FORMAT_FILE_NAME, s);
            string dummy = postOFHttpClass.getPhpResultWithoutWebPassword("webFormatRegist.php");
			Cursor.Current = Cursors.Default;
			MessageBox.Show("Webサーバーのデータベースに保存されました");
			this.Close();
		}
		
		private void textBox_TextChanged(object sender, EventArgs e) {
			if (!mFirstFlag) {
				okBtn.Enabled = true;
			}	
		}
		
	}
}
