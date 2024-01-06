using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EntryRegistWebPr {
	public partial class simpleMailAddressRegistFrm : Form {
		
		mailTableClass mMailTableC;
		public phpEntryFrm mPhpEhtryFrm;
		private int mRowIndex;
		
		public simpleMailAddressRegistFrm(mailTableClass arg,int rIndex) {
			InitializeComponent();
			mMailTableC=arg;
			mRowIndex=rIndex;	
		}

		private void mailAddressRegistFrm_Load(object sender, EventArgs e) {
			dataInToolBox();
		}

		private void dataInToolBox() {
			jcblNumberTextBox.Text = mMailTableC.JcblNumber.ToString();
			personNameTextBox.Text = mMailTableC.PersonName;
			mailAddressTextBox.Text = mMailTableC.MailAddress;
			RegistBtn.Enabled = false;
		}

		private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private bool isDataChangeConfirm() {
			if (RegistBtn.Enabled) {
				string message = "データが変更されています。変更を破棄しますか?";
				return (etcClass.isYesNoDialogBox(message));
			}
			return true;
		}

		private bool isDataChange() {
			return !(mailAddressTextBox.Text==mMailTableC.MailAddress);
		}

		private mailTableClass getmailTableClassFromTextBox() {
			return new mailTableClass{
				JcblNumber = etcClass.objToInt(jcblNumberTextBox.Text),
				PersonName = personNameTextBox.Text.Trim(),
				MailAddress = mailAddressTextBox.Text.Trim(),
			};
		}

		private bool isDataAllIn() {
			string mailAddress = mailAddressTextBox.Text.Trim();
			return (mailAddress != "");
		}

		private void mailAddressTextBox_Leave(object sender, EventArgs e) {
			string mailAddress = mailAddressTextBox.Text.Trim();
			if (mailAddress != "") {
				Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
				Match m = regex.Match(mailAddress);
				if (!m.Success) {
					MessageBox.Show("E-Mailの書式が正しくありません。");
					mailAddressTextBox.Focus();
					mailAddressTextBox.SelectAll();
					return;
				}
				RegistBtn.Enabled = isDataChange() && isDataAllIn();
			}
		}

		private void RegistBtn_Click(object sender, EventArgs e) {
			mailTableClass aUserC = getmailTableClassFromTextBox();
			if (aUserC.isRegisted()){
				aUserC.doUserUpdate();
				MessageBox.Show("更新されました");
			}
			else{
				aUserC.doUserRegist();
				MessageBox.Show("登録されました");
			}
			PreviewFrmRefresh();
			this.Close();
		}

		private void PreviewFrmRefresh() {
			mPhpEhtryFrm.setMailContent(mRowIndex, mailAddressTextBox.Text.Trim());	
		}

		private void mailAddressRegistFrm_KeyDown(object sender, KeyEventArgs e) {
			RegistBtn.Enabled = true;
			if (e.KeyCode == Keys.Enter) {
				bool forward = e.Modifiers != Keys.Shift;
				this.SelectNextControl(this.ActiveControl, forward, true, true, true);
				e.Handled = true;
			}
		}
	}
}
