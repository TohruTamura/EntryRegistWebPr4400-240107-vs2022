using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
//大船のサーバーでは改行文字がエスケープされてrnになってしまうので\\を付加した

namespace EntryRegistWebPr {
	public partial class phpEntryFrm : Form {
		//public const string WEB_ENTRY_SEND_MAIL_PHP = "http://www.ofunabc.jp/entrySystemOfunaDB/entrySendMailphp/newEntrySendMail.php";

		enum colT {
			受付,
			連絡担当者,
			メールアドレス,
			送信
		}

		private EventInfoClass mEventInfo;
		private List<teamForMailClass> mTeamList;
		private ToolTip ToolTip1;
		private webFormatClass mWebFormatC;

		
		public phpEntryFrm(EventInfoClass arg) {
			InitializeComponent();
			mEventInfo=arg;
			mWebFormatC = webFormatClass.getWebFormatFromDB(1);
		}

		private void phpEntryFrm_Load(object sender, EventArgs e) {
			//dataの抽出
			sendBtn.Enabled = false;
			drawFrameOfDGV();
			dispDefaultRadioBtn.Checked = true;
			sendResultTextBox.ScrollBars = ScrollBars.Vertical;
			setMailContentTextBox();
			mailContentSaveBtn.Enabled = false;
			setToolTip();
		}

		private List<teamForMailClass> getDispList(){
			if (dispDefaultRadioBtn.Checked){
				return getTeamListWithMailAddress();
			}
			else if (dispAllRadioBtn.Checked){
				return getAllTeamListWithMailAddress();
			}
			else{
				return getTeamListWithWebEntry();
			}
		}
		
		private List<teamForMailClass> getAllTeamList(){
			string sql = "SELECT Team.受付番号, Team.[1Number], Team.[1Name],Team.mailAddress FROM Team";
			sql += string.Format(" WHERE Team.Event={0} AND Team.Cancel=False ORDER BY Team.受付番号", mEventInfo.EventID);
			DataTable dt = MicrosoftAccessClass.getDataTable(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
			var aList = etcClass.getDataTableRowsList(dt);
			return aList.Select(aRow => { return getTeamForMailClassFromDB(aRow); }).ToList();
		}
		
		
		private List<teamForMailClass> getAllTeamListWithMailAddress(){
			List<teamForMailClass> aList = getAllTeamList();
			aList.ForEach(aClass =>{
				if (string.IsNullOrEmpty(aClass.Leader.MailAddress)) {
					aClass.Leader.MailAddress = getMailAddressFromMailTable(aClass.Leader.JcblNumber);
				}
			});
			return aList;
		}
		
		private List<teamForMailClass> getTeamListWithWebEntry(){
			List<teamForMailClass> aList=getAllTeamList();
			return aList.Where(aObj => (aObj.Leader.MailAddress != "")).ToList();		
		}

		private List<teamForMailClass> getTeamListWithMailAddress(){
			List<teamForMailClass> aList = getAllTeamListWithMailAddress();
			return aList.Where(aObj => (aObj.Leader.MailAddress != "")).ToList();		
		}
		
		//なければ空を返す
		private string getMailAddressFromMailTable(int jcblNumber){
			string sql = string.Format("SELECT COUNT(*) FROM mailTable WHERE jcblNumber={0}", jcblNumber);
			int n=MicrosoftAccessClass.getTableDataNums(sql,EntryMdbClass.getIMP_SumConnectStr(new entryFileClass().FileFullPath));
			string s="";
			if (n!=0){			
				sql = string.Format("SELECT mailAddress FROM mailTable WHERE jcblNumber={0}", jcblNumber);
				DataTable dt = MicrosoftAccessClass.getDataTable(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
				var aList = etcClass.getDataTableRowsList(dt);
				s=aList[0][0].ToString();
			}
			return s;
		}
		
		private static teamForMailClass getTeamForMailClassFromDB(DataRow aRow) {
			teamForMailClass aTeamC = new teamForMailClass();
			aTeamC.EntrantNumber = etcClass.objToInt(aRow[0]);
			personClass aPersonC = new personClass();
			aPersonC.JcblNumber = etcClass.objToInt(aRow[1]);
			aPersonC.PersonName = etcClass.objToStr(aRow[2]);
			aPersonC.MailAddress = etcClass.objToStr(aRow[3]);
			aTeamC.Leader = aPersonC;
			return aTeamC;
		}
		
		private void setToolTip() {
			ToolTip1 = new ToolTip();	   //フォームにcomponentsがない場合
			ToolTip1.InitialDelay = 2000;  //ToolTipが表示されるまでの時間
			ToolTip1.ReshowDelay = 1000;  //ToolTipが表示されている時に、別のToolTipを表示するまでの時間
			ToolTip1.AutoPopDelay = 10000;	//ToolTipを表示する時間
			ToolTip1.ShowAlways = true;	   //フォームがアクティブでない時でもToolTipを表示する
			//ButtonにToolTipが表示されるようにする
			ToolTip1.SetToolTip(mailContentSaveBtn, "メール内容を保存し、次回この競技会を選択した時に表示");
		}

		private void setMailNumsLbl() {
			mailNumsLbl.Text = string.Format("送付件数:{0}", getCheckmailNums());
		}

		private int getCheckmailNums() {
			return etcClass.getDataGridViewRowsList(aDGV).Count(aRow => isSendOfRow(aRow));
		}

		private bool isSendOfRow(DataGridViewRow aRow) {
			return etcClass.objToBool(aRow.Cells[(int)colT.送信].Value);
		}

		private void drawFrameOfDGV() {
			int[] colW = new int[] { 55, 120, 230, 50 };
			DataGridViewTextBoxColumn[] textCol = new DataGridViewTextBoxColumn[4];
			aDGV.Columns.Clear();
			for (int j = 0; j < 3; j++) {
				textCol[j] = new DataGridViewTextBoxColumn();
				textCol[j].HeaderText = ((colT)j).ToString();
				textCol[j].Width = colW[j];
				aDGV.Columns.Add(textCol[j]);
			}
			DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
			checkCol.HeaderText = colT.送信.ToString();
			checkCol.Width = colW[(int)colT.送信];
			aDGV.Columns.Add(checkCol);
			aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			aDGV.Columns[(int)colT.受付].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		private void drawContent() {
			Cursor.Current=Cursors.WaitCursor;
			mTeamList = getDispList();
			aDGV.Rows.Clear();
			mTeamList.ForEach(aTeamC => rowInsertOfData(aTeamC));
			sendBtn.Enabled = isEnableOfSendBtn();
			setMailNumsLbl();
			Cursor.Current = Cursors.Default;
		}

		private void rowInsertOfData(teamForMailClass aTeamClass) {
			string[] aCol=new string[4];
			aCol[0]=aTeamClass.EntrantNumber.ToString();
			aCol[1] = aTeamClass.Leader.PersonName;
			aCol[2] = aTeamClass.Leader.MailAddress;
			aCol[3]=(!string.IsNullOrEmpty(aCol[2])).ToString();
			aDGV.Rows.Add(aCol);
		}

		private bool isEnableOfSendBtn() {
			return (getCheckmailNums() != 0);
		}

		private void setMailContentTextBox() {
			string s = getMailContent(mEventInfo.EventID);
			if (string.IsNullOrEmpty(s)) {
				s = getDefaultMailContent(mEventInfo);
				updateOfMailContent(s, mEventInfo.EventID);
			}
			mailContentTextBox.Text = s;
		}

		private string getDefaultMailContent(EventInfoClass aEventInfo) {
			string s = "<name> 様" + Environment.NewLine;
			s += "下記のとおり、お申し込みの競技会についてご連絡いたします。" + Environment.NewLine;
			s += Environment.NewLine;
			s +=string.Format("開催日　：{0}"+Environment.NewLine, getDispEventDate(aEventInfo) );
			s +=string.Format("試合名　：{0}" +Environment.NewLine, aEventInfo.EventName );
			s +=string.Format("開始時間：{0}"+Environment.NewLine,"10:30" );
			s +=string.Format("参加料　：{0}" + Environment.NewLine, getEntryFeeStr(aEventInfo) );
			s += "会場　　：大船ブリッジセンター" + Environment.NewLine;
			s += Environment.NewLine;
			s += "1.参加を受け付けました" + Environment.NewLine;
			s += Environment.NewLine;
			s += "受付番号  <entry>" + Environment.NewLine;
			s += Environment.NewLine;
			s += "取消期限：該当競技会前最終平日午後5時迄"+Environment.NewLine;
			s +="キャンセル期限を過ぎますと参加料の20％を頂きます。無断棄権の場合は参加料の全額を頂きます。" + Environment.NewLine;
			s += Environment.NewLine;
			s += Environment.NewLine;
			s += "==========================================" + Environment.NewLine;
			s += "〒247-0056 鎌倉市大船1－7－5" + Environment.NewLine;
			s += "　大船末広神尾ビル3階" + Environment.NewLine;
			s += "　特定非営利活動法人 大船ブリッジセンター" + Environment.NewLine;
			s += string.Format("　　TEL.{0}",mWebFormatC.TelNumber) + Environment.NewLine;
			s += string.Format("　　{0}",mWebFormatC.MailAddress) + Environment.NewLine;
			s += "==========================================" + Environment.NewLine;
			return s;
		}
		
		private string getCancelDateAndTime(EventInfoClass aEventInfo){
			string yohbi = aEventInfo.EventDate.ToString("ddd");
			DateTime cancelDate = (yohbi == "日") ? aEventInfo.EventDate.AddDays(-2) : aEventInfo.EventDate.AddDays(-1);
			string cancelTime = "17:00";
			return string.Format("{0}  {1}", cancelDate.ToShortDateString(), cancelTime);		
		}
		
		private string getEntryFeeStr(EventInfoClass aEventC){
			return aEventC.isTeamEvent() ? "12000円/チーム" : "6,000円/ペア";
		}
		
		private string getDispEventDate(EventInfoClass aEventC){
			string yohbi = aEventC.EventDate.ToString("ddd");
			return string.Format("{0}({1})", aEventC.EventDate.ToLongDateString(), yohbi);		
		}
			
		public static string getMailContent(int eventId) {
			string sql = string.Format("SELECT mailContent FROM Event WHERE Event={0}", eventId);
			DataTable dt = MicrosoftAccessClass.getDataTable(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
			List<DataRow> aRows = etcClass.getDataTableRowsList(dt);
			return aRows[0][0].ToString();
		}

		public static void updateOfMailContent(string aContent, int eventId) {
			string sql = string.Format("UPDATE Event SET mailContent='{0}' WHERE Event={1}", aContent, eventId);
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
		}

		private List<teamForMailClass> getTeamListOfCheckedRows() {
			var checkedList = etcClass.getDataGridViewRowsList(aDGV).Select((val, index) => new { val, index });
			checkedList = checkedList.Where(aRow => isSendOfRow(aRow.val));
			List<teamForMailClass> aList = new List<teamForMailClass>();
			checkedList.ToList().ForEach(aRow => aList.Add(mTeamList[aRow.index]));
			return aList;
		}

		private void sendBtn_Click(object sender, EventArgs e) {
			if (etcClass.isNoYesDialogBox("送信しますか?")) {
				doSend();
			}
		}

		private void doSend() {
			Cursor.Current = Cursors.WaitCursor;
			List<teamForMailClass> aTeamList = getTeamListOfCheckedRows();
			aTeamList.ForEach(aTeamC =>{
				sendMail(aTeamC, mailContentTextBox.Text);
			});
			Cursor.Current = Cursors.Default;
		}


		private void sendMail(teamForMailClass aTeamC, string mailContentStr) {
			string s = replaceOfMailContent(aTeamC.EntrantNumber, aTeamC.Leader.PersonName, mailContentStr);
			List<mailEntryContentClass> aMailEntryList = new List<mailEntryContentClass> { 
																	(new mailEntryContentClass(	aTeamC.EntrantNumber, 
																								aTeamC.Leader.PersonName, 
																								aTeamC.Leader.MailAddress,
																								mEventInfo.EventID,
																								s)) };
			string result = doSemdMail(aMailEntryList);
			string mes = string.Format("受付{0} {1}の送信に", aTeamC.EntrantNumber, aTeamC.Leader.PersonName);
			sendResultTextBox.Text += mes + ((result == "success") ? "成功" : "失敗") + Environment.NewLine;
			etcClass.goEndOfTextOfConvertInfoText(sendResultTextBox);
		}

		//返値はsuccess or failure
		private static string doSemdMail(List<mailEntryContentClass> aMailEntryList) {
			NameValueCollection post = new NameValueCollection();
			string sendStr = new JavaScriptSerializer().Serialize(aMailEntryList);
			sendStr = sendStr.Replace("\\n", "\\\\n");	  //ofuna version
			sendStr = sendStr.Replace("\\r", "\\\\r");   //ofuna version
			post.Add("entry", sendStr);
			return postOFHttpClass.SendPost(new newFtpServerClass().getWebEntrySendMailPhpUrl(), post);	
		}

		private void testMailBtn_Click(object sender, EventArgs e) {
			Cursor.Current = Cursors.WaitCursor;
			sendMail(getTestTeamClass(), mailContentTextBox.Text);
			Cursor.Current = Cursors.Default;
		}

		private teamForMailClass getTestTeamClass() {
			teamForMailClass aTeamC = new teamForMailClass();
			aTeamC.EntrantNumber = 1;
			personClass aPersonC = new personClass();
			aTeamC.Leader = aPersonC;
			aTeamC.Leader.PersonName = "橋の介";
			aTeamC.Leader.MailAddress =mWebFormatC.MailAddress; //"7925ftul@jcom.home.ne.jp"; //"entry@ofunabc.jp";
			return aTeamC;
		}

		private string replaceOfMailContent(int entrantNumber, string personName, string aMailContent) {
			string s = aMailContent.Replace("<name>", personName);
			return s.Replace("<entry>", entrantNumber.ToString());
		}

		private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void aDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.ColumnIndex == (int)colT.送信) {
				aDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (!getCheckButtonCellFlag(e.RowIndex, (int)colT.送信));
				sendBtn.Enabled = isEnableOfSendBtn();
			}
			sendBtn.Enabled = isEnableOfSendBtn();
		}

		private bool getCheckButtonCellFlag(int row, int colIndex) {
			return (etcClass.isCheckOfCheckBoxOnDataGridView(aDGV.Rows[row].Cells[colIndex]));
		}
		
		private void aDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
			DataGridView dgv = (DataGridView)sender;
			//新しい行のセルでなく、セルの内容が変更されている時だけ検証する
			if (e.RowIndex == dgv.NewRowIndex || !dgv.IsCurrentCellDirty) {
				return;
			}
			if (e.ColumnIndex == (int)colT.送信) {
				string mailContent = etcClass.objToStr(aDGV.Rows[e.RowIndex].Cells[(int)colT.メールアドレス].Value);
				if(string.IsNullOrEmpty(mailContent)){			
					//入力した値をキャンセルして元に戻すには、次のようにする
					dgv.CancelEdit();
					//キャンセルする
					e.Cancel = true;
				}
			}
		}
		
		
		private void aDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			setMailNumsLbl();
		}
		
		private void aDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			etcClass.RowNumsDraw(aDGV, e, e.RowIndex + 1);
		}

		private void allCheckBtn_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow aRow in aDGV.Rows) {
				if(!string.IsNullOrEmpty(etcClass.objToStr(aRow.Cells[(int)colT.メールアドレス].Value))){
					aRow.Cells[(int)colT.送信].Value = true;
				}
			}
		}

		private void allClearBtn_Click(object sender, EventArgs e) {
			foreach (DataGridViewRow aRow in aDGV.Rows) {
				aRow.Cells[(int)colT.送信].Value = false;
			}
		}

		private void mailContentSaveBtn_Click(object sender, EventArgs e) {
			updateOfMailContent(mailContentTextBox.Text, mEventInfo.EventID);
			MessageBox.Show("メール内容を保存しました");
		}

		private void mailContentTextBox_TextChanged(object sender, EventArgs e) {
			mailContentSaveBtn.Enabled = true;
		}

		private void mailContentCancelBtn_Click(object sender, EventArgs e) {
			string s = getMailContent(mEventInfo.EventID);
			mailContentTextBox.Text = s;
			mailContentSaveBtn.Enabled = false;
		}

		private void mailContentDefaultBtn_Click(object sender, EventArgs e) {
			if (etcClass.isNoYesDialogBox("メール内容をデフォルト値に戻しますか?")) {
				mailContentTextBox.Text = getDefaultMailContent(mEventInfo);
				mailContentSaveBtn.Enabled = true;
			}
		}

		private void phpEntryMailFrm_FormClosing(object sender, FormClosingEventArgs e) {
			string savedContent = getMailContent(mEventInfo.EventID);
			string tempContent = mailContentTextBox.Text;
			//同じかどうか比較
			if (savedContent != tempContent) {
				if (etcClass.isYesNoDialogBox("メール内容が保存されているものと異なっています。保存しますか?")) {
					updateOfMailContent(tempContent, mEventInfo.EventID);
				}
			}
		}

		private void dispRadioBtn_CheckedChanged(object sender, EventArgs e) {
			drawContent();
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e) {
			doEdit(aDGV.CurrentCell.RowIndex);
		}

		private void doEdit(int rowIndex){
			mailTableClass aClass = new mailTableClass();
			aClass.JcblNumber = mTeamList[rowIndex].Leader.JcblNumber;
			aClass.PersonName = mTeamList[rowIndex].Leader.PersonName;
			aClass.MailAddress = mTeamList[rowIndex].Leader.MailAddress;
			simpleMailAddressRegistFrm aFrm = new simpleMailAddressRegistFrm(aClass, rowIndex);
			aFrm.mPhpEhtryFrm=this;
			aFrm.ShowDialog();		
		}
		
		private void aDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
			doEdit(aDGV.CurrentCell.RowIndex);		
		}
		
		public void setMailContent(int rIndex,string mailContent){
			aDGV.Rows[rIndex].Cells[(int)colT.メールアドレス].Value=mailContent;
			aDGV.Refresh();
			mTeamList[rIndex].Leader.MailAddress=mailContent;
		}

	}
}
