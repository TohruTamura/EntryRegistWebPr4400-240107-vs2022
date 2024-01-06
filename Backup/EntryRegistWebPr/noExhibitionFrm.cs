using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace EntryRegistWebPr{

    public partial class noExhibitionFrm : Form{
		const int DISP_NUMS=50;

        private enum ColT{
            会員番号,
            名前,
            登録日
        }

		private string mSourceFileName;
		private bool mOpenningFlag;
		private List<nonExhibitionClass> mOldnonExhibitionClassList;
		
        public noExhibitionFrm(string aSourceFileName){
            InitializeComponent();
            mSourceFileName=aSourceFileName;
        }

        private void noExhibitionFrm_Load(object sender, EventArgs e){
			mOpenningFlag=true;
            drawDGVFrame();
            mOldnonExhibitionClassList=getNonExhibitMemberListFromDB();
			DrawData(getNonExhibitMemberListFromDB());
			saveStripMenuItem.Enabled=false;

        }
        
        //----------------　表示--------------------------------------------------------
        private void drawDGVFrame(){
            int[] colW = new int[] { 100, 120, 120};
            aDGV.RowHeadersVisible = true;
            aDGV.RowCount = 0;
	        aDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (ColT j = ColT.会員番号; j <= ColT.登録日; j++){
                DataGridViewContentAlignment aAlign = (j == ColT.会員番号) ? 
														DataGridViewContentAlignment.MiddleRight : 
														DataGridViewContentAlignment.MiddleLeft;
                aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j], aAlign));
            }
			aDGV.Columns[(int)ColT.名前].ReadOnly = true;
			aDGV.Columns[(int)ColT.登録日].ReadOnly = true;
			foreach (DataGridViewColumn c in aDGV.Columns){
				c.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		private void DrawData(List<nonExhibitionClass> aList) {
			aDGV.Rows.Clear();
			Cursor.Current = Cursors.WaitCursor;
			aDGV.Visible = true;
			int nn=(aList==null)?0:aList.Count;
			int n=getDataRows(nn);
			for (int j = 0; j < n; j++) {
				nonExhibitionClass aClass=new nonExhibitionClass();
				if(j<nn){
					 aClass=aList[j];
				}
				aDGV.Rows.Add( getSetDataRow(aClass) );
			}
			aDGV.CurrentCell = null;
			Cursor.Current = Cursors.Default;
		}

		private List<nonExhibitionClass> getNonExhibitMemberListFromDB(){
            string result = postOFHttpClass.getPhpResultWithoutWebPassword("getNonExhibitMember.php");
			return new JavaScriptSerializer().Deserialize<List<nonExhibitionClass>>(result);
		}
		 
		private static string[] getSetDataRow(nonExhibitionClass aClass){
			string[] aRow = new string[3];
			aRow[(int)ColT.会員番号] = (aClass.JcblNo == 0) ? "" : aClass.JcblNo.ToString();
			aRow[(int)ColT.登録日] = aClass.RegistDate;
			aRow[(int)ColT.名前] = aClass.PersonName;
			return aRow;
		}
		
		private int getDataRows(int dataNums){
			return (dataNums / DISP_NUMS + 1) * DISP_NUMS;		
		}

		private void aDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			etcClass.RowNumsDraw(aDGV, e, e.RowIndex + 1);
			mOpenningFlag = false;
		}

		private void HomePageFrm_Shown(object sender, EventArgs e) {
			aDGV.CurrentCell = null;
		}

		//既に登録されている時はその行番号を返す
		//登録されていない時は-1を
		private int isRegisted(int rowNo,int jcblNo){
			for(int j=0;j<aDGV.Rows.Count;j++){
				int temp=etcClass.objToInt(aDGV.Rows[j].Cells[(int)ColT.会員番号].Value);
				if (temp==jcblNo && rowNo!=j){
					return j;
				}
			}	
			return -1;
		}

		private void aDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
			DataGridView dgv = (DataGridView)sender;
			if (e.RowIndex == dgv.NewRowIndex || !dgv.IsCurrentCellDirty){
				return;
			}		
			if (e.ColumnIndex==(int)ColT.会員番号){
				if ((e.FormattedValue.ToString()!="")){
					int jcblNo=etcClass.objToInt(e.FormattedValue);
					if (!JCBLCalcClass.isProperJCBLNumber(jcblNo)) {
						ShowErrorMessageOfJcblNumber("不適正な会員番号です");
						dgv.CancelEdit();
						e.Cancel = true;
						return;
					}
					int rIndex = isRegisted(e.RowIndex, jcblNo);
					if (rIndex != -1) {
						ShowErrorMessageOfJcblNumber("既に" + (rIndex+1).ToString() + "行目に登録されています");
						dgv.CancelEdit();
						e.Cancel = true;
						return;
					}
					string personName = JcblMembersInfoClass.getPersonNameInfoFromDataBase(jcblNo, mSourceFileName);
					if (personName == "") {
						ShowErrorMessageOfJcblNumber("該当者はいません");
						dgv.CancelEdit();
						e.Cancel = true;
						return;
					}
					setCellsValue(e.RowIndex, personName, DateTime.Now.ToShortDateString());
				}
				else{   //空白になった
					setCellsValue(e.RowIndex, "", "");
				}
			}
		}
		
		private void setCellsValue(int rowIndex,string sNameVal, string sRegistDateVal){
			aDGV.Rows[rowIndex].Cells[(int)ColT.名前].Value =sNameVal;
			aDGV.Rows[rowIndex].Cells[(int)ColT.登録日].Value = sRegistDateVal;							
		}
		

		private void ShowErrorMessageOfJcblNumber(string error) {
			MessageBox.Show(error);
		}
		
		private void aDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (!mOpenningFlag){
				saveStripMenuItem.Enabled=true;
			}
		}

		private void searchBtn_Click(object sender, EventArgs e) {
			int rIndex = getNumberSearchRowIndex(etcClass.objToInt(JCBLNumberTextBox.Text.Trim()));
			if (rIndex == -1) {
				MessageBox.Show("見つかりません");
			}
			else {
				aDGV.CurrentCell = aDGV[0, rIndex];
			}
		}

		private int getNumberSearchRowIndex(int searchNumber) {
			return etcClass.getDataGridViewRowsList(aDGV).FindIndex( delegate(DataGridViewRow aRow){
				return (searchNumber == etcClass.objToInt(aRow.Cells[(int)ColT.会員番号].Value) );
			});
		}

		private void saveStripMenuItem_Click(object sender, EventArgs e) {
			string s=new JavaScriptSerializer().Serialize(getSaveList());
			string result = ftpUploadClass.uploadDispDataString(nonExhibitionListClass.NON_EXHIBIT_INFO_FILE_NAME, s);
            string dummy = postOFHttpClass.getPhpResultWithoutWebPassword("nonExhibitMemberRegist.php");
			MessageBox.Show("Webサーバーのデータベースに保存されました");
			mOldnonExhibitionClassList = getNonExhibitMemberListFromDB();
			saveStripMenuItem.Enabled = false;		
		}

		private List<nonExhibitionClass> getSaveList(){
			List<nonExhibitionClass> aList=new List<nonExhibitionClass>(); 
			etcClass.getDataGridViewRowsList(aDGV).ForEach( delegate(DataGridViewRow aRow){
				if (etcClass.objToStr(aRow.Cells[(int)ColT.会員番号].Value) != "") {
					aList.Add(getNonExhibitionClassFromDataGridView(aRow));
				}
			});
			nonExhibitionListClass.Sorting(aList);
			return aList;		
		}

		private static nonExhibitionClass getNonExhibitionClassFromDataGridView(DataGridViewRow aRow) {
			return new nonExhibitionClass(	etcClass.objToInt(aRow.Cells[(int)ColT.会員番号].Value),
											etcClass.objToStr(aRow.Cells[(int)ColT.名前].Value),
											etcClass.objToStr(aRow.Cells[(int)ColT.登録日].Value) );
		}
		
		private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName =nonExhibitionListClass.NON_EXHIBIT_INFO_FILE_NAME; //はじめのファイル名を指定する
			//[ファイルの種類]に表示される選択肢を指定する
			sfd.Filter = "Json形式ファイル(*.txt;*.txt)|*.txt;*.txt|すべてのファイル(*.*)|*.*";
			sfd.FilterIndex = 1;
			sfd.Title = "保存先のファイルを選択してください";
			sfd.RestoreDirectory = true; //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
			if (sfd.ShowDialog() == DialogResult.OK) {
				nonExhibitionListClass.writeJsonFile(getSaveList(), sfd.FileName);
				MessageBox.Show("エクスポートされました");
			}
		}
		private void importStripMenuItem_Click(object sender, EventArgs e) {
			string fileName = SelectOfSource();
			if (fileName != null) {
				List<nonExhibitionClass> aList=nonExhibitionListClass.ReadJsonFile(fileName);
				MessageBox.Show("インポートされました");
				DrawData(aList);
				saveStripMenuItem.Enabled = true;
			}
		}

		private static string SelectOfSource() { //Selectされなかったらnullを返す
			OpenFileDialog oFileDialog = new OpenFileDialog();
			oFileDialog.Filter = "Json形式ファイル(*.txt;*.txt)|*.txt;*.txt|すべてのファイル(*.*)|*.*";
			oFileDialog.FilterIndex = 1;
			oFileDialog.FileName = nonExhibitionListClass.NON_EXHIBIT_INFO_FILE_NAME;
			oFileDialog.Title = "インポートファイルを選択してください";
			return (oFileDialog.ShowDialog() == DialogResult.OK) ? oFileDialog.FileName : null;
		}
	
		private void allDeleteToolStripMenuItem_Click(object sender, EventArgs e) {
			if (getDeleteDialogResult("全てを削除しますか？") == DialogResult.Yes) {
				aDGV.Rows.Clear();
				for (int j = 0; j < DISP_NUMS; j++) {
					aDGV.Rows.Add(getSetDataRow(new nonExhibitionClass()));
				}
				saveStripMenuItem.Enabled = true;
			}
		}

		private DialogResult getDeleteDialogResult(string message){
			return MessageBox.Show(message, "削除", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);		
		}
		
		private void 閉じるXToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			int rn=aDGV.CurrentCell.RowIndex;
			string content=aDGV.Rows[rn].Cells[(int)ColT.名前].Value.ToString();
			if (getDeleteDialogResult(content+"を削除しますか？") == DialogResult.Yes) {
				aDGV.Rows.RemoveAt(rn);
				aDGV.Rows.Add(getSetDataRow(new nonExhibitionClass()));
				saveStripMenuItem.Enabled = true;
			}
		}

		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e) {
		   deleteToolStripMenuItem_Click(sender,e);
		}
		
		private void noExhibitionFrm_FormClosing(object sender, FormClosingEventArgs e) {
			List<nonExhibitionClass> tempList = getSaveList();
			List<nonExhibitionClass> preList = mOldnonExhibitionClassList;
			if (!nonExhibitionListClass.isSame(tempList, preList)) {
				DialogResult result = MessageBox.Show("変更されています。キャンセルしていいですか？", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				if (result != DialogResult.Yes) {
					e.Cancel = true;
				}
			}
		}
    }
}
