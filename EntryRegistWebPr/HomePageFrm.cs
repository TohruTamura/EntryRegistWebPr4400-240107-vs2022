using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

//on 08/10/30
// FormTitleにリーグnameを追加
// uploadFlag & closingFlagの設定が開いた時にされていなかった
// on 14/01/16 当日受付fieldを追加

namespace EntryRegistWebPr {

	public partial class HomePageFrm : Form {
		
        public enum ColT {
            ｱｯﾌﾟﾛｰﾄﾞ,
            締切,
            SP表示,
            当日受付,
            試合日,
            試合名,
            種類,
            参加数
        }

        private List<EventInfoClass> mEventInfoList;
 
        public HomePageFrm() {
            InitializeComponent();
        }

        private void HomePageFrm_Load(object sender, EventArgs e) {
			bool webConnectFlag = isComfirmConnectionOfWeb();
			if (!webConnectFlag) {
				MessageBox.Show("本パソコンはネットにつながっていません。確認してください。終了します",
					"エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Environment.Exit(0);
			}
			setTimer();
			bool isSettingFlag = isEntryAccessFileSet();
			if(!isSettingFlag){
				MessageBox.Show("受付ファイルが設定されていないか、受付ファイルがありません。終了します。", 
					"エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Environment.Exit(0);							
			}
			// on 22/09/02 位置をずらす
			bool isNewVersion = isNewVersionProperAccessFile(new entryFileClass().FileFullPath);
			if (!isNewVersion) {
				MessageBox.Show("受付ファイルが適正ではありません。リンクを切断しますので、再起動後、再設定してください",
					"エラー",
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
                //on 22/09/11 サーバー設定ToolStripMenuItem_Click(sender, e);
                aInstallC.InstallFlag = true;
                aInstallC.writeProperties();
            }
			aDGV.Refresh();
			if (webConnectFlag) {
				webEntryAutoSaveClass aClass = new webEntryAutoSaveClass();
				if (aClass.WebEntryAutoSaveFlag) {
					if (isSaveOfWebEntry()) {
						saveWebEntry();   //Web申込の登録
					}
				}
				else {
					saveWebEntry();   //Web申込の登録
				}
				
			}
			DrawData();
		}

		private bool isSaveOfWebEntry() {
			List<WebEntryClass> aList = WebEntryClass.getWebEntryList();
			if (aList != null) {
				string s = string.Format(
					"ネットからの申込情報が{0}件あります。取り込みますか?",
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
			tempWebEntryNumsLbl.Text = string.Format("未保存Webエントリー数={0}", count);
		}

		private bool isEntryAccessFileSet() {
			bool isSettingFlag = false;
			//string acFile=new entryFileClass().FileFullPath;
			if (!File.Exists(new entryFileClass().FileFullPath )) {
				string s = "受付ファイルが設定されていないか、受付ファイルがありませんので設定する必要があります。"+Environment.NewLine;
				s += "確認のために、最初にサーバー設定ダイアログが開きますが、通常はキャンセルボタンを押して、次のファイル設定に進みます。";
				MessageBox.Show(s,
					"説明",
					MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk
				);

				// on 22/09/02 server setting Dialog Open
				new ftpServerFrm().ShowDialog();
				//MessageBox.Show("受付ファイルが設定されていないか、受付ファイルがありません。設定してください。",
				//	"エラー",
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

		// selectFlagがtrueの場合は正しくセットされたことを示す
		private bool isEntryAccessFileSetSub() {
			bool selectFlag = false;
			string fileFullPath = "";
			do {
				fileFullPath = EntryMdbClass.SelectOfSourceMDB();
				if (fileFullPath != "") {
					if (!isProperAccessFile(fileFullPath)) {
						MessageBox.Show("正しい受付ファイルでない可能性があります。確認してください。",
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
							mes += "作成しますか?";
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
		/// 受付DB Fileか(EventとTeamのTableがあるか)
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
		
		private void saveWebEntry() { //ここを戻す
			Cursor.Current = Cursors.WaitCursor;
			if (WebEntryClass.getWebEntryList() != null) {
				convMessageTextBox.Text += registToDbOfWebDataClass.RegistToDbOfWebEntryList();
			}
			Cursor.Current = Cursors.Default;
		}

        private void webDataSaveBeforeUpload() { //ここを戻す
			List<WebEntryClass> aList = WebEntryClass.getWebEntryList();
			if (aList != null) {
				string mes = string.Format("プログラム起動後、申し込まれたデータが{0}件あります。データベースに保存後、アップロードします。", aList.Count);
				MessageBox.Show(mes);
				convMessageTextBox.Text += registToDbOfWebDataClass.RegistToDbOfWebEntryList();
			}
		}
		
		private bool isComfirmConnectionOfWeb() {
			modelessDlg dlg = new modelessDlg("サーバー接続を確認中です");
			dlg.Owner = this;
			dlg.Show();
			dlg.Update();
			string mes = ftpUploadClass.isConfirmOfWeb();
			dlg.Close();
			if (mes != "") {
				etcClass.DispErrorMessageDlg("サーバーに接続できません。オプションメニューからサーバ設定を確認してください。");
				return false;
			}
			return true;
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			bool isSettingFlag = isEntryAccessFileSetSub();
			if (!isSettingFlag) {
				MessageBox.Show("新しい受付ファイルは設定されませんでした。");
				
			}	
			else{
				MessageBox.Show("受付ファイルを設定し直しました");
				toolStripStatusLabel2.Text = new entryFileClass().FileFullPath;					
				aDGV.Refresh();
				DrawData();
				MenuItemSet(true);
			}
		}
		
        private void 閉じるXToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
        }

        private void MenuItemSet(bool flag) {
			uploadBtn.Enabled = flag;
            HtmlFileOutputToolStripMenuItem.Enabled = flag;
            非公開登録ToolStripMenuItem.Enabled = flag;
            checkBoxToolStripMenuItem.Enabled=flag;
        }
        //----------------　表示--------------------------------------------------------
        private void drawDGVFrame() {
            int[] colW = new int[] { 55,55,55,60, 100, 200, 140,80 };
            aDGV.RowHeadersVisible = true;
            aDGV.RowCount = 0;
            aDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			for(ColT j=ColT.ｱｯﾌﾟﾛｰﾄﾞ;j<=ColT.当日受付;j++){
				aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j]));
			}
			for (ColT j = ColT.試合日; j <= ColT.参加数; j++) {
                DataGridViewContentAlignment aAlign = (j == ColT.参加数) ? 
													  DataGridViewContentAlignment.MiddleRight : 
													  DataGridViewContentAlignment.MiddleLeft;
                aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j], aAlign));
            }
            aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            aDGV.Columns[(int)ColT.試合日].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            aDGV.Columns[(int)ColT.参加数].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            aDGV.Columns[(int)ColT.締切].ReadOnly=false;
			aDGV.Columns[(int)ColT.ｱｯﾌﾟﾛｰﾄﾞ].ReadOnly = false;
			uploadBtn.Enabled = isCheckOfUplaod();     
        }

		private static string[] getDispDataGridViewArStr(EventInfoClass aEventInfo) {
            //upload FlagとclonsingFlagを取得
			string[] aRow = new string[20];
			aRow[(int)ColT.ｱｯﾌﾟﾛｰﾄﾞ] = aEventInfo.UploadFlag.ToString(); //開いた時全てにチェック
			aRow[(int)ColT.締切] = aEventInfo.ClosingFlag.ToString(); //開いた時全てにチェック
            aRow[(int)ColT.SP表示] = aEventInfo.SpDispFlag.ToString();
			aRow[(int)ColT.当日受付] =aEventInfo.PlayDateEntryFlag.ToString();            
			aRow[(int)ColT.試合名] = aEventInfo.EventName;
			aRow[(int)ColT.試合日] = aEventInfo.EventDate.ToShortDateString();
			aRow[(int)ColT.種類] = aEventInfo.EventType;
			aRow[(int)ColT.参加数] = aEventInfo.EntryNums.ToString();
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
			setAllCheckBox((int)ColT.ｱｯﾌﾟﾛｰﾄﾞ,flag);
            MenuItemSet(flag);
			uploadBtn.Enabled = flag;
        }

        private void aDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == (int)ColT.ｱｯﾌﾟﾛｰﾄﾞ) {
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.ｱｯﾌﾟﾛｰﾄﾞ));
				uploadBtn.Enabled = isCheckOfUplaod();
			}
			else if (e.ColumnIndex==(int)ColT.締切){
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.締切));	
			}
            else if (e.ColumnIndex == (int)ColT.SP表示) {
                aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.SP表示));
            }
			else if (e.ColumnIndex == (int)ColT.当日受付) {
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)ColT.当日受付));
			}
        }

		private bool getCheckButtonCellFlag(int row,int colIndex) {
			return (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[row].Cells[colIndex])); 
		}

        private bool isCheckOfUplaod() {
			return  (getCheckedRowsList((int)ColT.ｱｯﾌﾟﾛｰﾄﾞ).Count!=0);
        }
		
		private void uploadBtn_Click(object sender, EventArgs e) {
			HtmlFileOutputToolStripMenuItem_Click(sender,e);
		}
		
		//*********** menu Event
        private void ファイルFToolStripMenuItem_Click(object sender, EventArgs e) {
			HtmlFileOutputToolStripMenuItem.Enabled = uploadBtn.Enabled;
        }

		private void 未公開登録ToolStripMenuItem_Click(object sender, EventArgs e) {
			new noExhibitionFrm(new entryFileClass().FileFullPath).ShowDialog();
		}

		private void サーバー設定ToolStripMenuItem_Click(object sender, EventArgs e) {
			new ftpServerFrm().ShowDialog();
		}

		delegate string uploadDataAction();
		
		private void HtmlFileOutputToolStripMenuItem_Click(object sender, EventArgs e) {
			webDataSaveBeforeUpload();
			Cursor.Current = Cursors.WaitCursor;
			aDGV.Focus();
			aDGV.Refresh();
			updateMessageTextBox("サーバーとの接続をチェック中");
			string errMes = ftpUploadClass.isConfirmOfWeb();
			if (errMes != "") {
				etcClass.DispErrorMessageDlg(errMes);
				MessageBox.Show("アップロードを中止します");
				return;
			}
			updateMessageTextBox("データを読み込んでいます");
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
			if (etcClass.isYesNoDialogBox("アップロード終了しました。アップロードを確認しますか?")) {
				System.Diagnostics.Process.Start(new newFtpServerClass().getEventListHtml());
			}
		}

		private uploadDataAction getActionOfUpdateEntryInfo(List<string> mesList, List<EventInfoClass> updateEventList ) {
			mesList.Add("エントリー情報を処理中");
			return delegate() {
				string s= EntryListJsonConvertClass.EntryListJsonConverting(updateEventList, new entryFileClass().FileFullPath);
				return ftpUploadClass.uploadDispDataString(EntryListJsonConvertClass.ENTRY_LIST_FILE_NAME,s);
			};
		}
		
		private uploadDataAction getActionOfUpdateTournamentInfo(List<string> mesList, List<EventInfoClass> updateEventList) {
			mesList.Add("トーナメント情報を処理中");
			return delegate {
				string s=EventListJsonConvertClass.EventListJsonConverting(updateEventList);
				return ftpUploadClass.uploadDispDataString(EventListJsonConvertClass.EVENT_LIST_FILE_NAME,s);
			};		
		}

        private void webServerDbRegist() { //ここを戻す
			Cursor.Current = Cursors.WaitCursor;
			updateMessageTextBox("トーナメント情報をデータベースに保存中");
			string dummy = postOFHttpClass.getPhpResultWithoutWebPassword("eventInfoRegist.php"); ////返値は必要ない

			updateMessageTextBox("エントリー情報をデータベースに保存中");
			dummy = postOFHttpClass.getPhpResultWithoutWebPassword("entryInfoRegist.php"); ////返値は必要ない	
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
            Color bColor = (etcClass.isCheckOfCheckBoxOnDataGridView(aRow.Cells[(int)ColT.締切])) ? Color.Pink : Color.White;
            etcClass.getDataGridViewCellsList(aRow).ForEach( delegate(DataGridViewCell aCell){
				aCell.Style.BackColor = bColor;								
            });
        }

        private List<EventInfoClass> gethtmlOutputEventList() {
			List<EventInfoClass> aList = new List<EventInfoClass>();
			getCheckedRowsList((int)ColT.ｱｯﾌﾟﾛｰﾄﾞ).ForEach(delegate(int n) {
				mEventInfoList[n].ClosingFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.締切])); //ここで設定    
                mEventInfoList[n].SpDispFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.SP表示])); //ここで設定                  
				mEventInfoList[n].PlayDateEntryFlag = (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[n].Cells[(int)ColT.当日受付])); //ここで設定                  
				aList.Add(mEventInfoList[n]);
			});
			return aList;
        }

		private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
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

		private void 締切を全てチェックToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllCheckBox((int)ColT.締切, true);
			setColorOfAllRows();
		}

		private void 締切を全てクリアToolStripMenuItem_Click(object sender, EventArgs e) {
			setAllCheckBox((int)ColT.締切, false);
			setColorOfAllRows();
		}

        private void sP表示を全てチェックToolStripMenuItem_Click(object sender, EventArgs e) {
            setAllCheckBox((int)ColT.SP表示, true);
        }

        private void sP表示を全てクリアToolStripMenuItem_Click(object sender, EventArgs e) {
            setAllCheckBox((int)ColT.SP表示, false);
        }	

		private void setColorOfAllRows() {
			etcClass.getDataGridViewRowsList(aDGV).ForEach(delegate(DataGridViewRow aRow) {
				setRowColor(aRow);
			});
		}
		
		private void checkBoxMenuSet(bool flag){
			 checkBoxToolStripMenuItem.Enabled=flag;
		}


		private void jCBL情報アップロードToolStripMenuItem_Click_1(object sender, EventArgs e) {
			// DB version
			new jcblInfoToDbUploadFrm().ShowDialog();
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e) {
			new logDispFrm().ShowDialog();
		}

		private void HomePageFrm_FormClosing(object sender, FormClosingEventArgs e) {
			//ここでupload情報を保存する
			//upload情報を保存
			var aList = etcClass.getDataGridViewRowsList(aDGV);
			for (int j = 0; j < aList.Count; j++) {
				bool uploadFlag = aList[j].Cells[(int)ColT.ｱｯﾌﾟﾛｰﾄﾞ].Value.ToString() == "True";
				bool closingFlag = aList[j].Cells[(int)ColT.締切].Value.ToString() == "True";
                bool spDispFlag = aList[j].Cells[(int)ColT.SP表示].Value.ToString() == "True";
                bool PlayDateEntryFlag=aList[j].Cells[(int)ColT.当日受付].Value.ToString()=="True";
                EventInfoManageClass.updateOfUploadFlagAndClosingFlag(uploadFlag, closingFlag, spDispFlag,PlayDateEntryFlag, mEventInfoList[j].EventID);
			}
		}

		private void webFormatToolStripMenuItem_Click(object sender, EventArgs e) {
			new webFormatFrm().ShowDialog();
		}

		private void aDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			goMailSendFrm();
		}

		private void メール送信ToolStripMenuItem_Click(object sender, EventArgs e) {
			goMailSendFrm();
		}
		
		private void goMailSendFrm(){
			Cursor.Current=Cursors.WaitCursor;
			EventInfoClass aEventInfo = mEventInfoList[aDGV.CurrentRow.Index];
			new phpEntryFrm(aEventInfo).ShowDialog();
			Cursor.Current=Cursors.Default;
		}

		private void 登録メールリストToolStripMenuItem1_Click(object sender, EventArgs e) {
			new mailListPreviewFrm().ShowDialog();
		}

		private void 送信フォームToolStripMenuItem_Click(object sender, EventArgs e) {
			if(aDGV.CurrentCell!=null){
				goMailSendFrm();
			}
			else{
				MessageBox.Show("送信する競技会を選択してください");
			}
		}

		private void web監視間隔設定ToolStripMenuItem_Click(object sender, EventArgs e) {
			new webWatchIntervalFrm().ShowDialog();
			setTimer();
		}

        private void webDBへのアクセスToolStripMenuItem_Click(object sender, EventArgs e){
            System.Diagnostics.Process.Start("https://www.hosting-kit.com/Z7xGD/");
        }

		private void help3ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("help3.pdf");
		}

		private void help4ToolStripMenuItem_Click(object sender, EventArgs e) {
			openHelpPdf("tCBWebEntry3について220912.pdf");
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e) {
			openHelpPdf("setPlayDateEntry.pdf");

		}
		private void ウェブエントリー保存設定ToolStripMenuItem_Click(object sender, EventArgs e) {
			new webEntryAutoSaveSettingFrm().ShowDialog();
		}
	}
}