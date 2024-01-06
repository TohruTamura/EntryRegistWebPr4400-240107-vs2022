using System;
using System.Windows.Forms;
using System.IO;

namespace EntryRegistWebPr {
    public partial class ftpServerFrm : Form {
		//private string UPLOAD_TEST_FILE_NAME = "connect.xml";
        public ftpServerFrm() {
            InitializeComponent();
        }

        private void ftpServerFrm_Load(object sender, EventArgs e) {
			newFtpServerClass fsc = new newFtpServerClass();
			setTextBox(fsc);
            OkBtn.Enabled = false;
        }

		private void setTextBox(newFtpServerClass fsc) {
			ftpServerTextBox.Text = fsc.FptServerName;
			ftpDefaultFolderTextBox.Text=fsc.FtpDefaultFolder;
			homePageURLTextBox.Text = fsc.HomePageUrl;
			ftpAccountTextBox.Text = fsc.FtpAccount;
			passwordTextBox.Text = fsc.FtpUserPassword;
            entryFolderNameTextBox.Text = fsc.EntryFolderName;
			webDbPasswordtextBox.Text = fsc.WebDbPassword;
		}

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e) {
            saveFtpServerClass();
            MessageBox.Show("更新されました");
            this.Close();
        }

        private void saveFtpServerClass() {
			newFtpServerClass fsc = new newFtpServerClass();
            fsc.FptServerName = ftpServerTextBox.Text.Trim();
			fsc.FtpDefaultFolder=ftpDefaultFolderTextBox.Text.Trim();
            fsc.HomePageUrl = homePageURLTextBox.Text.Trim();
            fsc.FtpAccount = ftpAccountTextBox.Text.Trim();
            fsc.FtpUserPassword = passwordTextBox.Text.Trim();
            fsc.EntryFolderName = entryFolderNameTextBox.Text.Trim();
			fsc.WebDbPassword = webDbPasswordtextBox.Text.Trim();
            fsc.writeProperties();        
        }

        private void ftpServerTextBox_TextChanged(object sender, EventArgs e) {
            OkBtn.Enabled = true;
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e) {
            OkBtn.Enabled = true;
        }

        private void passwordMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {
            OkBtn.Enabled = true;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e){
            OkBtn.Enabled = true;
        }

        private void webFolderNameTextBox_TextChanged(object sender, EventArgs e) {
            OkBtn.Enabled = true;
        }

		private void ftpDefaultFolderTextBox_TextChanged(object sender, EventArgs e) {
			OkBtn.Enabled=true;
		}
		
		private void homePageURLTextBox_TextChanged(object sender, EventArgs e) {
			OkBtn.Enabled = true;
		}

		private void webDbPasswordtextBox_TextChanged(object sender, EventArgs e) {
			OkBtn.Enabled = true;
		}
			
        private void ftpServerTextBox_Enter(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();
        }

        private void userNameTextBox_Enter(object sender, EventArgs e) {
            ((TextBox)sender).SelectAll();
        }


		private void ftpDefaultFolderTextBox_Enter(object sender, EventArgs e) {
			((TextBox)sender).SelectAll();
		}
		
        private void exportBtn_Click(object sender, EventArgs e){
			//SaveFileDialogクラスのインスタンスを作成
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = "EntryWebServer.txt"; //はじめのファイル名を指定する
			sfd.InitialDirectory = @"C:\"; 			//はじめに表示されるフォルダを指定する
			//[ファイルの種類]に表示される選択肢を指定する
			sfd.Filter ="xmlファイル(*.txt;*.txt)|*.txt;*.txt|すべてのファイル(*.*)|*.*";
			sfd.FilterIndex = 1;
			//タイトルを設定する
			sfd.Title = "保存先のファイルを選択してください";
			//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
			sfd.RestoreDirectory = true;
			//既に存在するファイル名を指定したとき警告する.デフォルトでTrueなので指定する必要はない
			sfd.OverwritePrompt = true;
			//存在しないパスが指定されたとき警告を表示する.デフォルトでTrueなので指定する必要はない
			sfd.CheckPathExists = true;

			//ダイアログを表示する
			if (sfd.ShowDialog() == DialogResult.OK){
                saveFtpServerClass();
				jsonFileSave(sfd.FileName, new newFtpServerClass());
				MessageBox.Show("エクスポートされました");
			}
        }

		private void importBtn_Click(object sender, EventArgs e) {
			string fileName=SelectOfSource();
			if (fileName != null) {
				System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
				string str = File.ReadAllText(fileName, enc);
				newFtpServerClass fsc=newFtpServerClass.jsonToConvert(str);

				// 新たに表示
				setTextBox(fsc);
				OkBtn.Enabled = true;
				MessageBox.Show("インポートされました");
			}
		}

		private static void jsonFileSave(string fileName, newFtpServerClass fsc) {
			string s=fsc.convertToJson();
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
			File.WriteAllText(fileName, s, enc);
        }

		private static string SelectOfSource() { //Selectされなかったらnullを返す
			OpenFileDialog oFileDialog = new OpenFileDialog();
			oFileDialog.Filter = "xmlファイル(*.txt;*.txt)|*.txt;*.txt|すべてのファイル(*.*)|*.*";
			oFileDialog.FilterIndex = 1;
			oFileDialog.FileName = "impWebServer.txt";
			if (oFileDialog.ShowDialog() == DialogResult.OK) {
				return oFileDialog.FileName;
			}
			else {
				return null;
			}
		}

		private void ConnectTestBtn_Click(object sender, EventArgs e) {
			Cursor.Current = Cursors.WaitCursor;
            string errorMes = ftpUploadClass.isConfirmOfWeb();
            Cursor.Current = Cursors.Default;
            if (errorMes == "") {
                MessageBox.Show("接続に成功しました");
            }
            else {
                MessageBox.Show(errorMes,"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
		}
    }
}