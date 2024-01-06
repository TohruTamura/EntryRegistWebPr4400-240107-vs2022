using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

//on 08/10/30
// FormTitle�Ƀ��[�Oname��ǉ�
// uploadFlag & closingFlag�̐ݒ肪�J�������ɂ���Ă��Ȃ�����
// on 14/01/16 ������tfield��ǉ�

namespace EntryRegistWebPr {

	public partial class HomePageFrm : Form {
		
        public enum ColT {
            ����۰��,
            ����,
            SP�\��,
            ������t,
            ������,
            ������,
            ���,
            �Q����
        }

        private List<EventInfoClass> mEventInfoList;
 
        public HomePageFrm() {
            InitializeComponent();
        }

        private void HomePageFrm_Load(object sender, EventArgs e) {
			bool webConnectFlag = isComfirmConnectionOfWeb();
			if (!webConnectFlag) {
				MessageBox.Show("�{�p�\�R���̓l�b�g�ɂȂ����Ă��܂���B�m�F���Ă��������B�I�����܂�",
					"�G���[",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Environment.Exit(0);
			}
			setTimer();
			bool isSettingFlag = isEntryAccessFileSet();
			if(!isSettingFlag){
				MessageBox.Show("��t�t�@�C�����ݒ肳��Ă��Ȃ����A��t�t�@�C��������܂���B�I�����܂��B", 
					"�G���[",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Environment.Exit(0);							
			}
			// on 22/09/02 �ʒu�����炷
			bool isNewVersion = isNewVersionProperAccessFile(new entryFileClass().FileFullPath);
			if (!isNewVersion) {
				MessageBox.Show("��t�t�@�C�����K���ł͂���܂���B�����N��ؒf���܂��̂ŁA�ċN����A�Đݒ肵�Ă�������",
					"�G���[",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				entryFileClass aFileC = new entryFileClass("");
				aFileC.writeProperties();
				Environment.Exit(0);
			}
			toolStripStatusLabel2.Text = new entryFileClass().FileFullPath;
			drawDGVFrame();
            installClass aInstallC = new installClass();
            if (!aInstallC.InstallFlag){
                //on 22/09/11 �T�[�o�[�ݒ�ToolStripMenuItem_Click(sender, e);
                aInstallC.InstallFlag = true;
                aInstallC.writeProperties();
            }
			aDGV.Refresh();
			if (webConnectFlag) {
				webEntryAutoSaveClass aClass = new webEntryAutoSaveClass();
				if (aClass.WebEntryAutoSaveFlag) {
					if (isSaveOfWebEntry()) {
						saveWebEntry();   //Web�\���̓o�^
					}
				}
				else {
					saveWebEntry();   //Web�\���̓o�^
				}
				
			}
			DrawData();
		}

		private bool isSaveOfWebEntry() {
			List<WebEntryClass> aList = WebEntryClass.getWebEntryList();
			if (aList != null) {
				string s = string.Format(
					"�l�b�g����̐\�����{0}������܂��B��荞�݂܂���?",
					aList.Count
				);
				return etcClass.isYesNoDialogBox(s);
			}
			else {
				return false;
			}
		}

		private void setTimer() {
			timer2.Enabled = true;
			timer2.Interval = 1000 *  new webWatchIntervalClass().WatchInterval;
		}

		private void timer2_Tick(object sender, EventArgs e) {
			setNotSaveDataNumsMessage();
		}	
		
		private void setNotSaveDataNumsMessage() {
			List<WebEntryClass> aList = WebEntryClass.getWebEntryList();
			int count = (aList == null) ? 0 : aList.Count;
			tempWebEntryNumsLbl.ForeColor = (count != 0) ? Color.Red : Color.Black;
			tempWebEntryNumsLbl.Text = string.Format("���ۑ�Web�G���g���[��={0}", count);
		}

		private bool isEntryAccessFileSet() {
			bool isSettingFlag = false;
			//string acFile=new entryFileClass().FileFullPath;
			if (!File.Exists(new entryFileClass().FileFullPath )) {
				string s = "��t�t�@�C�����ݒ肳��Ă��Ȃ����A��t�t�@�C��������܂���̂Őݒ肷��K�v������܂��B"+Environment.NewLine;
				s += "�m�F�̂��߂ɁA�ŏ��ɃT�[�o�[�ݒ�_�C�A���O���J���܂����A�ʏ�̓L�����Z���{�^���������āA���̃t�@�C���ݒ�ɐi�݂܂��B";
				MessageBox.Show(s,
					"����",
					MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk
				);

				// on 22/09/02 server setting Dialog Open
				new ftpServerFrm().ShowDialog();
				//MessageBox.Show("��t�t�@�C�����ݒ肳��Ă��Ȃ����A��t�t�@�C��������܂���B�ݒ肵�Ă��������B",
				//	"�G���[",
				//	MessageBoxButtons.OK,
				//	MessageBoxIcon.Error
				//);
				isSettingFlag = isEntryAccessFileSetSub();
			}
			else {
				isSettingFlag = true;
			}
			return isSettingFlag;
		}

		// selectFlag��true�̏ꍇ�͐������Z�b�g���ꂽ���Ƃ�����
		private bool isEntryAccessFileSetSub() {
			bool selectFlag = false;
			string fileFullPath = "";
			do {
				fileFullPath = EntryMdbClass.SelectOfSourceMDB();
				if (fileFullPath != "") {
					if (!isProperAccessFile(fileFullPath)) {
						MessageBox.Show("��������t�t�@�C���łȂ��\��������܂��B�m�F���Ă��������B",
						"",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation
					);
						continue;
					}
					else {
						isExistTableClass aTableC=new isExistTableClass(fileFullPath);
						if (!aTableC.isAllExist()) {
							string mes = aTableC.getExistMessage();
							mes += "�쐬���܂���?";
							if (etcClass.isYesNoDialogBox(mes)) {
								MessageBox.Show(aTableC.makeTableAndField());
								selectFlag = true;
							}
							else {
								fileFullPath = "";
							}
						}
						else {
							selectFlag = true;
						}
					}
				}
			} while (!selectFlag && fileFullPath != "");
			if (selectFlag) {
				entryFileClass aFileC = new entryFileClass(fileFullPath);
				aFileC.writeProperties();
			}
			return selectFlag;
		}
		
		/// <summary>
		/// ��tDB File��(Event��Team��Table�����邩)
		/// </summary>
		/// <param name="fileFullPath"></param>
		/// <returns></returns>
		private bool isProperAccessFile(string fileFullPath){
			List<string> tableList=MicrosoftAccessClass.getTableNamesList(MicrosoftAccessClass.ACCESS_BASE_CONNECTION+fileFullPath);
			bool flag = tableList.Any(aTableName => aTableName == "Event");
			if (flag){
				return tableList.Any(aTableName => aTableName == "Team");	
			}
			else{
				return false;
			}
		}

		private bool isNewVersionProperAccessFile(string fileFullPath) {
			return MicrosoftAccessClass.isExistFieldOnTable(MicrosoftAccessClass.ACCESS_BASE_CONNECTION + fileFullPath, "Event", "playDateEntryFlag");
		}
		
		private void saveWebEntry() { //������߂�
			Cursor.Current = Cursors.WaitCursor;
			if (WebEntryClass.getWebEntryList() != null) {
				convMessageTextBox.Text += registToDbOfWebDataClass.RegistToDbOfWebEntryList();
			}
			Cursor.Current = Cursors.Default;
		}

        private void webDataSaveBeforeUpload() { //������߂�
			List<WebEntryClass> aList = WebEntryClass.getWebEntryList();
			if (aList != null) {
				string mes = string.Format("�v���O�����N����A�\�����܂ꂽ�f�[�^��{0}������܂��B�f�[�^�x�[�X�ɕۑ���A�A�b�v���[�h���܂��B", aList.Count);
				MessageBox.Show(mes);
				convMessageTextBox.Text += registToDbOfWebDataClass.RegistToDbOfWebEntryList();
			}
		}
		
		private bool isComfirmConnectionOfWeb() {
			modelessDlg dlg = new modelessDlg("�T�[�o�[�ڑ����m�F���ł�");
			dlg.Owner = this;
			dlg.Show();
			dlg.Update();
			string mes = ftpUploadClass.isConfirmOfWeb();
			dlg.Close();
			if (mes != "") {
				etcClass.DispErrorMessageDlg("�T�[�o�[�ɐڑ��ł��܂���B�I�v�V�������j���[����T�[�o�ݒ���m�F���Ă��������B");
				return false;
			}
			return true;
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			bool isSettingFlag = isEntryAccessFileSetSub();
			if (!isSettingFlag) {
				MessageBox.Show("�V������t�t�@�C���͐ݒ肳��܂���ł����B");
				
			}	
			else{
				MessageBox.Show("��t�t�@�C����ݒ肵�����܂���");
				toolStripStatusLabel2.Text = new entryFileClass().FileFullPath;					
				aDGV.Refresh();
				DrawData();
				MenuItemSet(true);
			}
		}
		
        private void ����XToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
        }

        private void MenuItemSet(bool flag) {
			uploadBtn.Enabled = flag;
            HtmlFileOutputToolStripMenuItem.Enabled = flag;
            ����J�o�^ToolStripMenuItem.Enabled = flag;
            checkBoxToolStripMenuItem.Enabled=flag;
        }
        //----------------�@�\��--------------------------------------------------------
        private void drawDGVFrame() {
            int[] colW = new int[] { 55,55,55,60, 100, 200, 140,80 };
            aDGV.RowHeadersVisible = true;
            aDGV.RowCount = 0;
            aDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			for(ColT j=ColT.����۰��;j<=ColT.������t;j++){
				aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j]));
			}
			for (ColT j = ColT.������; j <= ColT.�Q����; j++) {
                DataGridViewContentAlignment aAlign = (j == ColT.�Q����) ? 
													  DataGridViewContentAlignment.MiddleRight : 
													  DataGridViewContentAlignment.MiddleLeft;
                aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j], aAlign));
            }
            aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            aDGV.Columns[(int)ColT.������].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            aDGV.Columns[(int)ColT.�Q����].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DrawData() {
            aDGV.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            mEventInfoList = EventInfoManageClass.getEventInfoList(false,new entryFileClass().FileFullPath);
            aDGV.Visible = true;
            mEventInfoList.ForEach(delegate(EventInfoClass aEventInfo){
				aDGV.Rows.Add( getDispDataGridViewArStr(aEventInfo));
				setRowColor(aDGV.Rows[aDGV.Rows.Count - 1]);
			});
            //aDGV.CurrentCell = null;
            Cursor.Current = Cursors.Default;
            aDGV.Columns[(int)ColT.����].ReadOnly=false;
			aDGV.Columns[(int)ColT.����۰��].ReadOnly = false;
			uploadBtn.Enabled = isCheckOfUplaod();     
        }

		private static string[] getDispDataGridViewArStr(EventInfoClass aEventInfo) {
            //upload Flag��clonsingFlag���擾
			string[] aRow = new string[20];
			aRow[(int)ColT.����۰��] = aEventInfo.UploadFlag.ToString(); //�J�������S�ĂɃ`�F�b�N
			aRow[(int)ColT.����] = aEventInfo.ClosingFlag.ToString(); //�J�������S�ĂɃ`�F�b�N
            aRow[(int)ColT.SP�\��] = aEventInfo.SpDispFlag.ToString();
			aRow[(int)ColT.������t] =aEventInfo.PlayDateEntryFlag.ToString();            
			aRow[(int)ColT.������] = aEventInfo.EventName;
			aRow[(int)ColT.������] = aEventInfo.EventDate.ToShortDateString();
			aRow[(int)ColT.���] = aEventInfo.EventType;
			aRow[(int)ColT.�Q����] = aEventInfo.EntryNums.ToString();
			return aRow;
		}

        private void aDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            etcClass.RowNumsDraw(aDGV, e, e.RowIndex + 1);
        }

        private void HomePageFrm_Shown(object sender, EventArgs e) {
            aDGV.CurrentCell = null;
        }

		//************ button Event

        private void setAllUploadCheckBoxItem(bool flag){
			setAllCheckBox((int)ColT.����۰��,flag);
            MenuItemSet(flag);
			uploadBtn.Enabled = flag;
        }

        private void aDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == (int)ColT.����۰��) {
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.����۰��));
				uploadBtn.Enabled = isCheckOfUplaod();
			}
			else if (e.ColumnIndex==(int)ColT.����){
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.����));	
			}
            else if (e.ColumnIndex == (int)ColT.SP�\��) {
                aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.SP�\��));
            }
			else if (e.ColumnIndex == (int)ColT.������t) {
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.������t));
			}
        }

		private bool getCheckButtonCellFlag(int row,int colIndex) {
			return (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[row].Cells[colIndex])); 
		}

        private bool isCheckOfUplaod() {
			return  (getCheckedRowsList((int)ColT.����۰��).Count!=0);
        }
		
		private void uploadBtn_Click(object sender, EventArgs e) {
			HtmlFileOutputToolStripMenuItem_Click(sender,e);
		}
		
		//*********** menu Event
        private void �t�@�C��FToolStripMenuItem_Click(object sender, EventArgs e) {
			HtmlFileOutputToolStripMenuItem.Enabled = uploadBtn.Enabled;
        }

		private void �����J�o�^ToolStripMenuItem_Click(object sender, EventArgs e) {
			new noExhibitionFrm(new entryFileClass().FileFullPath).ShowDialog();
		}

		private void �T�[�o�[�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
			new ftpServerFrm().ShowDialog();
		}

		delegate string uploadDataAction();
		
		private void HtmlFileOutputToolStripMenuItem_Click(object sender, EventArgs e) {
			webDataSaveBeforeUpload();
			Cursor.Current = Cursors.WaitCursor;
			aDGV.Focus();
			aDGV.Refresh();
			updateMessageTextBox("�T�[�o�[�Ƃ̐ڑ����`�F�b�N��");
			string errMes = ftpUploadClass.isConfirmOfWeb();
			if (errMes != "") {
				etcClass.DispErrorMessageDlg(errMes);
				MessageBox.Show("�A�b�v���[�h�𒆎~���܂�");
				return;
			}
			updateMessageTextBox("�f�[�^��ǂݍ���ł��܂�");
			List<EventInfoClass> updateEventList = gethtmlOutputEventList();
			//
			List<string> mesList=new List<string>();
			List<uploadDataAction> aUploadAction = new List<uploadDataAction>(){
				getActionOfUpdateTournamentInfo(mesList, updateEventList), 
				getActionOfUpdateEntryInfo(mesList,updateEventList)
			};
			//
			for (int j = 0; j < mesList.Count; j++) {
				updateMessageTextBox(mesList[j]);
				updateMessageTextBox(aUploadAction[j]());
			}									
			//
			webServerDbRegist();
			Cursor.Current = Cursors.Default;
			if (etcClass.isYesNoDialogBox("�A�b�v���[�h�I�����܂����B�A�b�v���[�h���m�F���܂���?")) {
				System.Diagnostics.Process.Start(new newFtpServerClass().getEventListHtml());
			}
		}

		private uploadDataAction getActionOfUpdateEntryInfo(List<string> mesList, List<EventInfoClass> updateEventList ) {
			mesList.Add("�G���g���[����������");
			return delegate() {
				string s= EntryListJsonConvertClass.EntryListJsonConverting(updateEventList, new entryFileClass().FileFullPath);
				return ftpUploadClass.uploadDispDataString(EntryListJsonConvertClass.ENTRY_LIST_FILE_NAME,s);
			};
		}
		
		private uploadDataAction getActionOfUpdateTournamentInfo(List<string> mesList, List<EventInfoClass> updateEventList) {
			mesList.Add("�g�[�i�����g����������");
			return delegate {
				string s=EventListJsonConvertClass.EventListJsonConverting(updateEventList);
				return ftpUploadClass.uploadDispDataString(EventListJsonConvertClass.EVENT_LIST_FILE_NAME,s);
			};		
		}

        private void webServerDbRegist() { //������߂�
			Cursor.Current = Cursors.WaitCursor;
			updateMessageTextBox("�g�[�i�����g�����f�[�^�x�[�X�ɕۑ���");
			string dummy = postOFHttpClass.getPhpResultWithoutWebPassword("eventInfoRegist.php"); ////�Ԓl�͕K�v�Ȃ�

			updateMessageTextBox("�G���g���[�����f�[�^�x�[�X�ɕۑ���");
			dummy = postOFHttpClass.getPhpResultWithoutWebPassword("entryInfoRegist.php"); ////�Ԓl�͕K�v�Ȃ�	
		}
		
		private void updateMessageTextBox(string mes){
			convMessageTextBox.Text += mes + Environment.NewLine;
			etcClass.goEndOfTextOfConvertInfoText(convMessageTextBox);		
		}
		
		private void saveToolStripButton_Click(object sender, EventArgs e) {
			HtmlFileOutputToolStripMenuItem_Click(sender, e);
		}
		
		private List<int> getCheckedRowsList(int colIndex){
			List<int> aList=new List<int>();
			for (int j = 0; j < aDGV.Rows.Count; j++) {
				if (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[j].Cells[colIndex])) {
					aList.Add(j);
				}
			}
			return aList;		
		}
		
        private void aDGV_CellValidated(object sender, DataGridViewCellEventArgs e) {
            setRowColor(aDGV.Rows[e.RowIndex]);
        }

        private void setRowColor(DataGridViewRow aRow) {
            Color bColor = (etcClass.isCheckOfCheckBoxOnDataGridView(aRow.Cells[(int)ColT.����])) ? Color.Pink : Color.White;
            etcClass.getDataGridViewCellsList(aRow).ForEach( delegate(DataGridViewCell aCell){
				aCell.Style.BackColor = bColor;								
            });
        }

        private List<EventInfoClass> gethtmlOutputEventList() {
			List<EventInfoClass> aList = new List<EventInfoClass>();
			getCheckedRowsList((int)ColT.����۰��).ForEach(delegate(int n) {
				mEventInfoList[n].ClosingFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.����])); //�����Őݒ�    
                mEventInfoList[n].SpDispFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.SP�\��])); //�����Őݒ�                  
				mEventInfoList[n].PlayDateEntryFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.������t])); //�����Őݒ�                  
				aList.Add(mEventInfoList[n]);
			});
			return aList;
        }

		private void �o�[�W�������ToolStripMenuItem_Click(object sender, EventArgs e) {
			new AboutBox().ShowDialog();
		}

		private void help1ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("help.pdf");
		}

		private void help2ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("help2.pdf");
		}

		private void taskHelpMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("task.pdf");
		}

		private void installToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("install.pdf");
		}	
		
		private void openHelpPdf(string fileName){
			System.Diagnostics.Process.Start(Application.StartupPath + "\\" + fileName);		
		}
		
		private void setAllCheckBox(int colIndex,bool flag) {
			etcClass.getDataGridViewRowsList(aDGV).ForEach( delegate(DataGridViewRow r) {
				r.Cells[colIndex].Value = flag;
			});
		}
		
		private void uploadAllCheckToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllUploadCheckBoxItem(true);
			checkBoxToolStripMenuItem.Enabled = true;
		}

		private void uploadAllClearToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllUploadCheckBoxItem(false);
			checkBoxToolStripMenuItem.Enabled = true;
		}

		private void ���؂�S�ă`�F�b�NToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllCheckBox((int)ColT.����, true);
			setColorOfAllRows();
		}

		private void ���؂�S�ăN���AToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllCheckBox((int)ColT.����, false);
			setColorOfAllRows();
		}

        private void sP�\����S�ă`�F�b�NToolStripMenuItem_Click(object sender, EventArgs e) {
            setAllCheckBox((int)ColT.SP�\��, true);
        }

        private void sP�\����S�ăN���AToolStripMenuItem_Click(object sender, EventArgs e) {
            setAllCheckBox((int)ColT.SP�\��, false);
        }	

		private void setColorOfAllRows() {
			etcClass.getDataGridViewRowsList(aDGV).ForEach(delegate(DataGridViewRow aRow) {
				setRowColor(aRow);
			});
		}
		
		private void checkBoxMenuSet(bool flag){
			 checkBoxToolStripMenuItem.Enabled=flag;
		}


		private void jCBL���A�b�v���[�hToolStripMenuItem_Click_1(object sender, EventArgs e) {
			// DB version
			new jcblInfoToDbUploadFrm().ShowDialog();
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e) {
			new logDispFrm().ShowDialog();
		}

		private void HomePageFrm_FormClosing(object sender, FormClosingEventArgs e) {
			//������upload����ۑ�����
			//upload����ۑ�
			var aList = etcClass.getDataGridViewRowsList(aDGV);
			for (int j = 0; j < aList.Count; j++) {
				bool uploadFlag = aList[j].Cells[(int)ColT.����۰��].Value.ToString() == "True";
				bool closingFlag = aList[j].Cells[(int)ColT.����].Value.ToString() == "True";
                bool spDispFlag = aList[j].Cells[(int)ColT.SP�\��].Value.ToString() == "True";
                bool PlayDateEntryFlag=aList[j].Cells[(int)ColT.������t].Value.ToString()=="True";
                EventInfoManageClass.updateOfUploadFlagAndClosingFlag(uploadFlag, closingFlag, spDispFlag,PlayDateEntryFlag, mEventInfoList[j].EventID);
			}
		}

		private void webFormatToolStripMenuItem_Click(object sender, EventArgs e) {
			new webFormatFrm().ShowDialog();
		}

		private void aDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			goMailSendFrm();
		}

		private void ���[�����MToolStripMenuItem_Click(object sender, EventArgs e) {
			goMailSendFrm();
		}
		
		private void goMailSendFrm(){
			Cursor.Current=Cursors.WaitCursor;
			EventInfoClass aEventInfo = mEventInfoList[aDGV.CurrentRow.Index];
			new phpEntryFrm(aEventInfo).ShowDialog();
			Cursor.Current=Cursors.Default;
		}

		private void �o�^���[�����X�gToolStripMenuItem1_Click(object sender, EventArgs e) {
			new mailListPreviewFrm().ShowDialog();
		}

		private void ���M�t�H�[��ToolStripMenuItem_Click(object sender, EventArgs e) {
			if(aDGV.CurrentCell!=null){
				goMailSendFrm();
			}
			else{
				MessageBox.Show("���M���鋣�Z���I�����Ă�������");
			}
		}

		private void web�Ď��Ԋu�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
			new webWatchIntervalFrm().ShowDialog();
			setTimer();
		}

        private void webDB�ւ̃A�N�Z�XToolStripMenuItem_Click(object sender, EventArgs e){
            System.Diagnostics.Process.Start("https://www.hosting-kit.com/Z7xGD/");
        }

		private void help3ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("help3.pdf");
		}

		private void help4ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("tCBWebEntry3�ɂ���220912.pdf");
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e) {
			openHelpPdf("setPlayDateEntry.pdf");

		}
		private void �E�F�u�G���g���[�ۑ��ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
			new webEntryAutoSaveSettingFrm().ShowDialog();
		}
	}
}