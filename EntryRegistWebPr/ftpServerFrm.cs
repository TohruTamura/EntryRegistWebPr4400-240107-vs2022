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
            MessageBox.Show("�X�V����܂���");
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
			//SaveFileDialog�N���X�̃C���X�^���X���쐬
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = "EntryWebServer.txt"; //�͂��߂̃t�@�C�������w�肷��
			sfd.InitialDirectory = @"C:\"; 			//�͂��߂ɕ\�������t�H���_���w�肷��
			//[�t�@�C���̎��]�ɕ\�������I�������w�肷��
			sfd.Filter ="xml�t�@�C��(*.txt;*.txt)|*.txt;*.txt|���ׂẴt�@�C��(*.*)|*.*";
			sfd.FilterIndex = 1;
			//�^�C�g����ݒ肷��
			sfd.Title = "�ۑ���̃t�@�C����I�����Ă�������";
			//�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
			sfd.RestoreDirectory = true;
			//���ɑ��݂���t�@�C�������w�肵���Ƃ��x������.�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
			sfd.OverwritePrompt = true;
			//���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������.�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
			sfd.CheckPathExists = true;

			//�_�C�A���O��\������
			if (sfd.ShowDialog() == DialogResult.OK){
                saveFtpServerClass();
				jsonFileSave(sfd.FileName, new newFtpServerClass());
				MessageBox.Show("�G�N�X�|�[�g����܂���");
			}
        }

		private void importBtn_Click(object sender, EventArgs e) {
			string fileName=SelectOfSource();
			if (fileName != null) {
				System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
				string str = File.ReadAllText(fileName, enc);
				newFtpServerClass fsc=newFtpServerClass.jsonToConvert(str);

				// �V���ɕ\��
				setTextBox(fsc);
				OkBtn.Enabled = true;
				MessageBox.Show("�C���|�[�g����܂���");
			}
		}

		private static void jsonFileSave(string fileName, newFtpServerClass fsc) {
			string s=fsc.convertToJson();
			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
			File.WriteAllText(fileName, s, enc);
        }

		private static string SelectOfSource() { //Select����Ȃ�������null��Ԃ�
			OpenFileDialog oFileDialog = new OpenFileDialog();
			oFileDialog.Filter = "xml�t�@�C��(*.txt;*.txt)|*.txt;*.txt|���ׂẴt�@�C��(*.*)|*.*";
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
                MessageBox.Show("�ڑ��ɐ������܂���");
            }
            else {
                MessageBox.Show(errorMes,"�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
		}
    }
}