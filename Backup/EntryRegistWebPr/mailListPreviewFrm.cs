using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EntryRegistWebPr {
	public partial class mailListPreviewFrm : Form {
		enum colT {
			会員番号,
			姓名,
			メールアドレス
		}

		private List<mailTableClass> mMailList;
		
		public mailListPreviewFrm() {
			InitializeComponent();
		}

		private void mailListPreviewFrm_Load(object sender, EventArgs e) {
			drawFrameOfDGV();
			drawContent();
			toolStripStatusLabel2.Text=new entryFileClass().FileFullPath;
		}

		private void drawFrameOfDGV() {
			int[] colW = new int[] { 80, 150, 250 };
			DataGridViewTextBoxColumn[] textCol = new DataGridViewTextBoxColumn[3];
			aDGV.Columns.Clear();
			for (int j = 0; j < 3; j++) {
				textCol[j] = new DataGridViewTextBoxColumn();
				textCol[j].HeaderText = ((colT)j).ToString();
				textCol[j].Width = colW[j];
				aDGV.Columns.Add(textCol[j]);
			}
			aDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			aDGV.Columns[(int)colT.会員番号].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		public void drawContent() {
			mMailList = mailTableClass.getMailList();
			aDGV.Rows.Clear();
			mMailList.ForEach(malilUsreC => rowInsertOfData(malilUsreC));
			registedNumsLbl.Text = string.Format("登録件数={0}", mMailList.Count);
		}

		private void rowInsertOfData(mailTableClass aMailC) {
			aDGV.Rows.Add(aMailC.JcblNumber.ToString(),aMailC.PersonName,aMailC.MailAddress);
		}
		
		private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void aDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
			etcClass.RowNumsDraw(aDGV, e, e.RowIndex + 1);
		}

		private void aDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			goRegistForm(e.RowIndex + 1);
		}

		private void goRegistForm(int index){
			mailAddressRegistFrm frm = new mailAddressRegistFrm(index);
			frm.mPreviewFrm = this;
			frm.ShowDialog();		
		}
		
		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (mMailList[aDGV.CurrentCell.RowIndex].deleteEachUser()){
				drawContent();
			}
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e) {
			goRegistForm(aDGV.CurrentCell.RowIndex + 1);
		}

		private void 削除ToolStripMenuItem1_Click(object sender, EventArgs e) {
			削除ToolStripMenuItem_Click(sender,e);
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = "mailList.csv";
			sfd.InitialDirectory = @"C:\"; //[ファイルの種類]に表示される選択肢を指定する
			sfd.Filter = "csvファイル(*.csv;*.csv)|*.csv;*.csv|すべてのファイル(*.*)|*.*";
			sfd.Title = "保存先のファイルを選択してください";
			if (sfd.ShowDialog() == DialogResult.OK) {
				etcClass.exportCSVOfDataGridView(sfd.FileName,aDGV);
				MessageBox.Show("エクスポートしました");
			}
		}

		private void 検索ToolStripMenuItem_Click(object sender, EventArgs e) {
			string s = Interaction.InputBox("検索文字を入力してください", "検索", "", -1, -1);
			s=s.Trim();
			if(s!=""){
				int rowIndex=strSearch(s);
				if(rowIndex!=-1){
					aDGV.CurrentCell=aDGV.Rows[rowIndex].Cells[0];
				}
				else{
					MessageBox.Show("見つかりません");
				}
			}
		}
		
		/// <summary>
		/// DataGridView内の文字を検索し、あればその行Indexを返す。なければ-1を返す
		/// </summary>
		/// <param name="arg">検索文字</param>
		/// <returns>行Index</returns>
		private int strSearch(string arg){
			for (int j = 0; j < aDGV.Rows.Count; j++) {
				for (int jj = 0; jj < aDGV.ColumnCount; jj++) {
					string value = etcClass.objToStr(aDGV.Rows[j].Cells[jj].Value).Trim();
					if (arg == value) {
						return j;
					}
				}
			}
			return -1; 		
		}

		private void registFormToolStripMenuItem_Click(object sender, EventArgs e) {
			goRegistForm(1);
		}
		
	}
}
