using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

namespace EntryRegistWebPr {
	public partial class jcblInfoToDbUploadFrm : Form {
		private const int UPDATE_TIMES = 100;  // on 17/08/17
		private const int EACH_UPDATE_NUMS = 3000; // on 17/08/17

		public enum ColT {
			年,
			月,
			データ数
		}
		
		private int mMonth=0;
		private int mYear=0;
		
		public jcblInfoToDbUploadFrm() {
			InitializeComponent();
			initOfJcblInfoUploadFrm();
		}

		public void initOfJcblInfoUploadFrm() {
			delBtn.Enabled = false;
			uploadBtn.Enabled = true;
			memberRegistCheckBox.Checked = true;
			drawDGVFrame();
			DrawData();
			aDGV.CurrentCell=null;
			setTempDataMonth();
		}

        private void jcblInfoToDbUploadFrm_Shown(object sender, EventArgs e){
            aDGV.CurrentCell = null;
        }

		private void drawDGVFrame() {
			int[] colW = new int[] { 60, 50, 70 };
			aDGV.RowHeadersVisible = true;
			aDGV.RowCount = 0;
			aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			for (ColT j = ColT.年; j <= ColT.データ数; j++) {
				aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j], DataGridViewContentAlignment.MiddleRight));
			}
			aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}

		private void DrawData() {
			aDGV.Rows.Clear();
			Cursor.Current = Cursors.WaitCursor;
			string response = getYearAndMonthOfMpInfoOnWebDb();
			List<mpInfoDbDataExistClass> aList = new JavaScriptSerializer().Deserialize<List<mpInfoDbDataExistClass>>(response);
			aList.Reverse();
			aDGV.Visible = true;
			aList.ForEach(aInfoC =>{
				string[] aRow = new string[3];
				aRow[(int)ColT.年] = aInfoC.y.ToString();
				aRow[(int)ColT.月] = aInfoC.m.ToString();
				aRow[(int)ColT.データ数] = aInfoC.dataNums.ToString();
				aDGV.Rows.Add(aRow);
			});
			aDGV.CurrentCell = null;
			Cursor.Current = Cursors.Default;
			aDGV.Refresh();
		}

		private static string getYearAndMonthOfMpInfoOnWebDb() {
            return postOFHttpClass.getPhpResultWithoutWebPassword("getMpInfoYearAndMonth.php");
		}

		private void setTempDataMonth() {
			DateTime d = getUpdateDateFromRegistFile();
			mYear=d.Year;
			mMonth=d.Month;
			monthOfAccessData.Text = string.Format("Accessの最新データ月={0}年{1}月", mYear, mMonth);
		}

		private static DateTime getUpdateDateFromRegistFile() {
			DateTime updateDate = etcClass.objToDateTime("2009/12/31");
			DataTable dt = EntryMdbClass.getDataTable("SELECT 最終締切日 FROM Member", new entryFileClass().FileFullPath);
			etcClass.getDataTableRowsList(dt).ForEach(delegate(DataRow dr) {
				if (etcClass.objToStr(dr[0]) != "") {
					DateTime d = etcClass.objToDateTime(dr[0]);
					if (d > updateDate) {
						updateDate = d;
					}
				}
			});
			return updateDate;
		}

		private void CanceｌBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void uploadBtn_Click(object sender, EventArgs e) {
			uploadBtn.Enabled = false;
			CanceｌBtn.Enabled = false;
			delBtn.Enabled = false; 
			Cursor.Current = Cursors.WaitCursor;
			if (memberRegistCheckBox.Checked) {
				doRegistJcblInfoToWebServerMain();	 
			}
			// mp情報
			doRegistMpInfoToWebServer();
			uploadBtn.Enabled = true;
			CanceｌBtn.Enabled = true;
			delBtn.Enabled = true; 
			DrawData();
			Cursor.Current = Cursors.Default;
		}

		private void doRegistMpInfoToWebServer() {
			deleteMonthMpInfo(mMonth, mYear);
			messageTextBox.ForeColor = System.Drawing.Color.Blue;

			showMessageTextBox("マスターポイント情報を登録しています。");
			initOfProgressBar();
			for (int j = 0; j < UPDATE_TIMES; j++) {
				Cursor.Current = Cursors.WaitCursor;  //念押し
				int startNum = j * EACH_UPDATE_NUMS;
				int endNum = (j + 1) * EACH_UPDATE_NUMS - 1;
				doRegistOfEachMpInfoToWebServer(startNum, endNum);
				progressBar1.Value++;
				progressBar1.Refresh();
			}
			showMessageTextBox(string.Format("{0}年{1}月のマスターポイント情報の登録を終了しました。", mYear, mMonth));
		}
		
		private void doRegistOfEachMpInfoToWebServer(int startNum, int endNum) {
			var aList = etcClass.getDataTableRowsList(dMpInfoClass.getJcblMemDataTable(startNum, endNum));
			if (aList.Count != 0) {
				List<dMpInfoClass> dMpInfoCList = aList.Select(dr => new dMpInfoClass(mMonth, etcClass.objToInt(dr[0]), etcClass.objToInt(dr[1]), etcClass.objToInt(dr[2]), etcClass.objToInt(dr[3]))).ToList();
				doMpInfoStrUpload(new JavaScriptSerializer().Serialize(dMpInfoCList)); //文字列を書き込む。直接内に書き込むようにしておく
				//dbに書き込む
				registMpInfoOfMonthToWebDb(mYear);

				showMessageTextBox(string.Format("{0}年{1}月の{2}から{3}番までのマスターポイント情報を登録しました。", mYear, mMonth, startNum, endNum));
			}
		}
		
		private static void registMpInfoOfMonthToWebDb(int aYear) {
			NameValueCollection post = new NameValueCollection();
			post.Add("y", aYear.ToString());
            string result = postOFHttpClass.getPhpResultMultiParamWithoutPasswordParam(post, "mpInfoSave.php");
		}

		private static void deleteMonthMpInfo(int aMonth, int aYear) {
			NameValueCollection post = new NameValueCollection();
			post.Add("y", aYear.ToString());
			post.Add("m", aMonth.ToString());
            string dummy = postOFHttpClass.getPhpResultMultiParamWithoutPasswordParam(post, "deleteMonthOfMpInfo.php");	//返値は必要ない	
		}

		private void doMpInfoStrUpload(string s) {
			newFtpServerClass fsc = new newFtpServerClass();
			string path = string.Format("ftp://{0}", fsc.getWebTempFolder()); 
			ftpUploadClass.uploadString("tempMpInfo.txt", s, path);
		}
		
		private void doRegistJcblInfoToWebServerMain() {
			deleteAllJcblInfo();

			showMessageTextBox("会員情報を更新しています。");
			initOfProgressBar();
			for (int j = 0; j < UPDATE_TIMES; j++) {
				Cursor.Current = Cursors.WaitCursor;  //念押し
				int startNum = j * EACH_UPDATE_NUMS;
				int endNum = (j + 1) * EACH_UPDATE_NUMS - 1;
				eachRegistJcblInfoToWebServer(startNum, endNum);
				progressBar1.Value++;
				progressBar1.Refresh();
			}
			showMessageTextBox("会員情報を更新を終了しました。");
		}

		private void eachRegistJcblInfoToWebServer(int startNum, int endNum) {
			var aList = etcClass.getDataTableRowsList(dJcblInfoClass.getMPTable(startNum, endNum));
			if (aList.Count != 0) {
				List<dJcblInfoClass> dJcblInfoCList = aList.Select(dr => new dJcblInfoClass(etcClass.objToInt(dr[0]), etcClass.objToStr(dr[1]), etcClass.objToBool(dr[2]), etcClass.objToStr(dr[3]), etcClass.objToStr(dr[4]))).ToList();
				doJcblInfoStrUpload(new JavaScriptSerializer().Serialize(dJcblInfoCList));
				jcblInfoRegistToWebDb(); //dbに書き込む
				showMessageTextBox(string.Format("{0}から{1}番までの会員情報を更新しました。", startNum, endNum));
			}
		}

		private static void jcblInfoRegistToWebDb() {
            string result = postOFHttpClass.getPhpResultWithoutWebPassword("jcblInfoSave.php");
		}
		
		private void doJcblInfoStrUpload(string s) {
			newFtpServerClass fsc = new newFtpServerClass();
			string path=string.Format("ftp://{0}", fsc.getWebTempFolder());
			ftpUploadClass.uploadString("tempJcblInfo.txt", s, path);
		}
			
		private static void deleteAllJcblInfo() {
            string result = postOFHttpClass.getPhpResultWithoutWebPassword("deleteJcblInfo.php");
		}

		private void aDGV_CellClick(object sender, DataGridViewCellEventArgs e) {
			DataGridViewSelectedRowCollection aRows = aDGV.SelectedRows;
			if (aRows.Count != 0) {
				delBtn.Enabled = true;
				uploadBtn.Enabled = true;
			}
		}

		private void delBtn_Click(object sender, EventArgs e) {
			if (etcClass.isNoYesDialogBox("削除していいですか？")) {
				DataGridViewSelectedRowCollection aRows = aDGV.SelectedRows;
				for (int j = 0; j < aRows.Count; j++) {
					int aYear = etcClass.objToInt(aRows[j].Cells[0].Value.ToString());
					int aMonth = etcClass.objToInt(aRows[j].Cells[1].Value.ToString());
					deleteMonthMpInfo(aMonth, aYear);
					showMessageTextBox(string.Format("{0}年{1}月のマスターポイント情報を削除しました。", aYear, aMonth));
				}
				DrawData();
			}
		}
					
		private void initOfProgressBar() {
			progressBar1.Minimum = 0;
			progressBar1.Maximum = UPDATE_TIMES;
			progressBar1.Value = 0;
			progressBar1.Refresh();
		}

		private void showMessageTextBox(string mes) {
			messageTextBox.Text += mes + Environment.NewLine;
			etcClass.goEndOfTextOfConvertInfoText(messageTextBox);
		}
	}
}
