using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Web.Script.Serialization;


namespace EntryRegistWebPr {
	public partial class logDispFrm : Form {

		private enum ColT {
			ID,登録日,code,内容
		}
		
		public logDispFrm() {
			InitializeComponent();
		}

		private void 閉じるXToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void logDispFrm_Load(object sender, EventArgs e) {
			drawDGVFrame();
			DrawData();
		}

		private void drawDGVFrame() {
			int[] colW = new int[] {45, 120,60, 760 };
			DataGridViewContentAlignment[] align=new DataGridViewContentAlignment[]{DataGridViewContentAlignment.TopRight,DataGridViewContentAlignment.TopCenter,DataGridViewContentAlignment.TopCenter,DataGridViewContentAlignment.TopLeft};
			aDGV.RowHeadersVisible = true;
			// セル内で文字列を折り返す
			aDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			// 文字列全体が表示されるように行の高さを自動調節する
			aDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			aDGV.RowCount = 0;
			aDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
			aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			for (ColT j = ColT.ID; j <= ColT.内容; j++) {
				aDGV.Columns.Add(etcClass.ColumnDefine(j.ToString(), j.ToString(), colW[(int)j],align[(int)j]));
			}
			foreach (DataGridViewColumn c in aDGV.Columns) {
				c.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		private void DrawData() {
			aDGV.Rows.Clear();
			Cursor.Current = Cursors.WaitCursor;
			aDGV.Visible = true;
			List<logDataClass> aList=getLogDataListFromDB();
			for(int j=0;j<aList.Count;j++){
				aDGV.Rows.Add(getSetDataRow(aList[j]));
			}
			aDGV.CurrentCell = null;
			Cursor.Current = Cursors.Default;
		}

		private List<logDataClass> getLogDataListFromDB() {
            string result = postOFHttpClass.getPhpResultWithoutWebPassword("getLogData.php");
			return new JavaScriptSerializer().Deserialize<List<logDataClass>>(result);
		}
		
		private static string[] getSetDataRow(logDataClass aClass) {
			string[] aRow = new string[4];
			aRow[(int)ColT.ID] = aClass.Id.ToString();
			aRow[(int)ColT.登録日] = aClass.RegistDateTime;
			aRow[(int)ColT.code] = aClass.Code.ToString();
			aRow[(int)ColT.内容] = aClass.Content;
			return aRow;
		}

		private void aDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			etcClass.RowNumsDraw(aDGV, e, e.RowIndex + 1);
		}

		private void 全行削除ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (etcClass.isNoYesDialogBox("復活できませんが、全て削除しますか？")) {
				logAllDelete();
				MessageBox.Show("ログを全て消去しました。");
				DrawData();
			}
		}
		
		private void logAllDelete(){
            string result = postOFHttpClass.getPhpResultWithoutWebPassword("logAllDelete.php");
		}

		private void 行削除ToolStripMenuItem_Click(object sender, EventArgs e) {
			//idを取得
			List<int> idList=selectedRowsIdList();
			string jsonStr=new JavaScriptSerializer().Serialize(idList);
			deleteSelectedIdLog(jsonStr);
			MessageBox.Show(idList.Count.ToString()+"行削除しました");
			DrawData();
		}

		private static void deleteSelectedIdLog(string jsonStr) {
			//idのJson形式でphpに渡す
			NameValueCollection post = new NameValueCollection();
			post.Add("idList", jsonStr);
			string result = postOFHttpClass.getPhpResultMultiParamWithoutPasswordParam(post,"eachLogDelete.php");//返値は不必要
		}
		
		private List<int> selectedRowsIdList(){
			//選択されている行を取得
			List<int> idList = new List<int>();
			foreach (DataGridViewRow r in aDGV.SelectedRows) {
				idList.Add(etcClass.objToInt(aDGV.Rows[r.Index].Cells[(int)ColT.ID].Value.ToString()));
			}
			return idList;		
		}

        private void logDispFrm_Shown(object sender, EventArgs e) {
             aDGV.CurrentCell = null;
        }
	}
}
