using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EntryRegistWebPr {
	public partial class mailAddressRegistFrm : Form {
		enum modeT {
			editT,
			newT
		}

		List<mailTableClass> mUserList = new List<mailTableClass>();
		modeT mMode = modeT.editT;
		private int mPosition;
		public mailListPreviewFrm mPreviewFrm;

		public mailAddressRegistFrm(int arg) {
			InitializeComponent();
			mPosition = arg;		
		}

		private void mailAddressRegistFrm_Load(object sender, EventArgs e) {
			dispInit();
		}

		private void dispInit() {
			mUserList =mailTableClass.getMailList();
			bindingNavigatorPositionItem.Text = (mPosition).ToString();
			bindingNavigatorCountItem.Text = mUserList.Count.ToString();
			RegistBtn.Enabled = false;
			mMode = modeT.editT;
			if (mUserList.Count == 0) {
				doNew();
			}
		}

		private void dataInToolBox() {
			if (mUserList.Count!=0 && mMode!=modeT.newT){
				int dataPos = getDataPosFrombindingNavigatorPositionItem() - 1;
				mailTableClass aData = mUserList[dataPos];
				jcblNumberTextBox.Text = aData.JcblNumber.ToString();
				personNameTextBox.Text = aData.PersonName;
				mailAddressTextBox.Text = aData.MailAddress;
			}
			else{
				textBoxInit();				
			}
			RegistBtn.Enabled = false;
		}

		private void textBoxInit() {
			jcblNumberTextBox.Text = "";
			personNameTextBox.Text = "";
			mailAddressTextBox.Text = "";
		}

		private void doNew() {
			mMode = modeT.newT;
			RegistBtn.Enabled = true;
			jcblNumberTextBox.Enabled = true;
			textBoxInit();
			jcblNumberTextBox.Focus();
			bindingNavigatorPositionItem.Text = (mUserList.Count + 1).ToString();
			bindingNavigatorCountItem.Text=bindingNavigatorPositionItem.Text;
		}
				
		private int getDataPosFrombindingNavigatorPositionItem() {  //1から始まる
			return etcClass.objToInt(bindingNavigatorPositionItem.Text);
		}
					
		private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e) {
			if (isDataChangeConfirm()) {
				int dataPos = getDataPosFrombindingNavigatorPositionItem();
				if (dataPos < mUserList.Count) {
					bindingNavigatorPositionItem.Text = (dataPos + 1).ToString();
				}
			}
		}

		private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e) {
			if (isDataChangeConfirm()) {
				bindingNavigatorPositionItem.Text = mUserList.Count.ToString();
			}
		}

		private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e) {
			if (isDataChangeConfirm()) {
				int dataPos = getDataPosFrombindingNavigatorPositionItem();
				if (dataPos > 1) {
					bindingNavigatorPositionItem.Text = (dataPos - 1).ToString();
				}
			}
		}

		private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e) {
			if (isDataChangeConfirm()) {
				bindingNavigatorPositionItem.Text = (1).ToString();
			}
		}
		
		private bool isDataChangeConfirm() {
			if (RegistBtn.Enabled) {
				string message = "データが変更されています。変更を破棄しますか?";
				return (etcClass.isYesNoDialogBox(message));
			}
			return true;
		}

		private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e) {
			//buttonの制御
			int dataPos = getDataPosFrombindingNavigatorPositionItem();
			bindingNavigatorMovePreviousItem.Enabled = true;
			bindingNavigatorMoveFirstItem.Enabled = true;
			bindingNavigatorMoveLastItem.Enabled = true;
			bindingNavigatorMoveNextItem.Enabled = true;
			if (dataPos == 1) {
				bindingNavigatorMovePreviousItem.Enabled = false;
				bindingNavigatorMoveFirstItem.Enabled = false;
			}
			else if (dataPos == mUserList.Count) {
				bindingNavigatorMoveLastItem.Enabled = false;
				bindingNavigatorMoveNextItem.Enabled = false;
			}
			dataInToolBox();
		}

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
			int index=etcClass.objToInt(getDataPosFrombindingNavigatorPositionItem())-1;
			if(mUserList[index].deleteEachUser()){
				PreviewFrmRefresh();
				mPosition=1;
				bindingNavigatorPositionItem.Text=mPosition.ToString();
				dispInit();		
			}
		}

		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) {
			doNew();
		}
		
		private bool isDataChange() {
			mailTableClass aUserC = getmailTableClassFromTextBox();
			return !aUserC.isSame(mUserList[getDataPosFrombindingNavigatorPositionItem() - 1]);
		}

		private mailTableClass getmailTableClassFromTextBox() {
			return new mailTableClass{
				JcblNumber = etcClass.objToInt(jcblNumberTextBox.Text),
				PersonName = personNameTextBox.Text.Trim(),
				MailAddress = mailAddressTextBox.Text.Trim(),
			};
		}

		private bool isDataAllIn() {
			string JcblNumberStr = jcblNumberTextBox.Text;
			string mailAddress = mailAddressTextBox.Text.Trim();
			return (JcblNumberStr != "" && mailAddress != "");
		}

		private void jcblNumberTextBox_Leave(object sender, EventArgs e) {
			string jcblNumberStr = ((TextBox)sender).Text.Trim();
			if (jcblNumberStr==""){
				personNameTextBox.Text ="";
				mailAddressTextBox.Text = "";
				return;			
			}
			int jcblNumber = etcClass.objToInt(((TextBox)sender).Text.Trim());
			if (isRegisted(jcblNumber)){
				MessageBox.Show("既に登録されています");
				jcblNumberTextBox.Focus();
				jcblNumberTextBox.SelectAll();
			}
			else{
				if (!JCBLCalcClass.isProperJCBLNumber(jcblNumber)){
					MessageBox.Show("不当な会員番号です");
					jcblNumberTextBox.Focus();
					jcblNumberTextBox.SelectAll();
					return;
				}
				else{
					//会員情報からpersonNameを取得
					string personName=JcblMembersInfoClass.getPersonNameInfoFromDataBase(jcblNumber,new entryFileClass().FileFullPath);
					personNameTextBox.Text = personName;
				}
				RegistBtn.Enabled = isDataAllIn();
			}
		}

		private bool isRegisted(int jcblNumber) {
			return mUserList.Count(aClass => aClass.JcblNumber == jcblNumber) != 0;
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
				if (mMode == modeT.editT) {
					RegistBtn.Enabled = isDataChange() && isDataAllIn();
				}
				else {
					RegistBtn.Enabled = isDataAllIn();
				}
			}
		}

		private void RegistBtn_Click(object sender, EventArgs e) {
			if (mMode == modeT.editT) {
				mailTableClass aUserC= getmailTableClassFromTextBox();
				aUserC.doUserUpdate();
				int dataPos = getDataPosFrombindingNavigatorPositionItem();
				mUserList[dataPos - 1] = aUserC;
				MessageBox.Show("更新されました");
				PreviewFrmRefresh();
				RegistBtn.Enabled = false;
			}
			else {
				mailTableClass aUserC = getmailTableClassFromTextBox();
				aUserC.doUserRegist();
				mUserList.Add(aUserC);
				bindingNavigatorCountItem.Text = mUserList.Count.ToString();
				PreviewFrmRefresh();
				doNew();
			}
		}
		
		private void PreviewFrmRefresh(){
			mPreviewFrm.drawContent();
			mPreviewFrm.aDGV.Refresh();
		}

		private void mailAddressRegistFrm_KeyDown(object sender, KeyEventArgs e) {
			RegistBtn.Enabled=true;
			if (e.KeyCode == Keys.Enter){
				bool forward = e.Modifiers != Keys.Shift;
				this.SelectNextControl(this.ActiveControl, forward, true, true, true);
				e.Handled = true;
			} 
		}
	}
}
