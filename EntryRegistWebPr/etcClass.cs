using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;

namespace EntryRegistWebPr{
 
    class etcClass {

		/// <summary>
		/// DataGridView�̒��g��csv�`���ŃG�N�X�|�[�g����
		/// </summary>
		/// <param name="fileFullPath">export����t�@�C����fullPath</param>
		/// <param name="dgv">DataGridView</param>
		public static void exportCSVOfDataGridView(string fileFullPath,DataGridView dgv){
				StreamWriter sw = new StreamWriter(fileFullPath, false, Encoding.GetEncoding(932));
				for (int j = 0; j < dgv.Rows.Count; j++) {
					string[] s = new string[dgv.ColumnCount + 1];
					s[0] = (j + 1).ToString();
					for (int jj = 0; jj < dgv.ColumnCount; jj++) {
						s[jj + 1] = dgv.Rows[j].Cells[jj].Value.ToString();
					}
					sw.WriteLine(string.Join(",", s));
				}
				sw.Close();
		}
				
		public static void goEndOfTextOfConvertInfoText(TextBox convMessageTextBox) {
			convMessageTextBox.SelectionStart = convMessageTextBox.Text.Length; //�J���b�g�ʒu�𖖔��Ɉړ�
			convMessageTextBox.Focus(); //�e�L�X�g�{�b�N�X�Ƀt�H�[�J�X���ړ�
			convMessageTextBox.ScrollToCaret(); //�J���b�g�ʒu�܂ŃX�N���[��
			convMessageTextBox.Refresh();
		}
		
		public static void DispErrorMessageDlg(string message){
			MessageBox.Show(message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);		
		}
		
        public static string getShortDateAndLongTimeStrOfNow() {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        public static string zeroToBlankStr(int n){
            return (n == 0) ? "" : n.ToString();   
        }

        public static string getDayOfWeekJ(DateTime d){
            return ("�����ΐ��؋��y").Substring(int.Parse(d.DayOfWeek.ToString("d")), 1);
        }

        public static string getTempDateAndTime() {
            return DateTime.Now.ToLongDateString() + "(" + DateTime.Now.ToString("dddd") + ")" + DateTime.Now.ToShortTimeString();
        }

        public static int intFromDBValue(object obj) {
            return (Convert.IsDBNull(obj)) ? 0 : Convert.ToInt32(obj);
        }

		//**************** DataGridView ********************/
		/// <summary>
		/// dataRow��RowList�𓾂� // on 10/04/16
		/// </summary>
		/// <param name="DataTable"></param>
		/// <returns></returns>
		public static List<DataRow> getDataTableRowsList(DataTable dt) {
			List<DataRow> aList = new List<DataRow>();
			foreach (DataRow aRow in dt.Rows) {
				aList.Add(aRow);
			}
			return aList;
		}


		/// <summary>
		/// dataGridView��RowList�𓾂� // on 10/04/09
		/// </summary>
		/// <param name="aDGV"></param>
		/// <returns></returns>
		public static List<DataGridViewRow> getDataGridViewRowsList(DataGridView aDGV) {
			List<DataGridViewRow> aList = new List<DataGridViewRow>();
			foreach (DataGridViewRow aRow in aDGV.Rows) {
				aList.Add(aRow);
			}
			return aList;
		}

		/// <summary>
		/// dataGridView��ColumnList�𓾂� // on 10/04/15
		/// </summary>
		/// <param name="aDGV"></param>
		/// <returns></returns>
		public static List<DataGridViewColumn> getDataGridViewColumnsList(DataGridView aDgv) {
			List<DataGridViewColumn> aList = new List<DataGridViewColumn>();
			foreach (DataGridViewColumn aCol in aDgv.Columns) {
				aList.Add(aCol);
			}
			return aList;
		}

		/// <summary>
		/// dataGridView�̓���s��CellList�𓾂� // on 10/04/09
		/// </summary>
		/// <param name="aDGV"></param>
		/// <returns></returns>
		public static List<DataGridViewCell> getDataGridViewCellsList(DataGridViewRow aRow) {
			List<DataGridViewCell> aList = new List<DataGridViewCell>();
			foreach (DataGridViewCell aCell in aRow.Cells) {
				aList.Add(aCell);
			}
			return aList;
		}

		public static bool isCheckOfCheckBoxOnDataGridView(DataGridViewCell aCell) {
			return aCell.Value.ToString() == "True";
		}
		 
		public static DataGridViewTextBoxColumn ColumnDefine(string headerText, string name, int width, DataGridViewContentAlignment align) { //common
			DataGridViewTextBoxColumn aTextColumn = new DataGridViewTextBoxColumn();
			aTextColumn.HeaderText = headerText;
			aTextColumn.Name = name;
			aTextColumn.Width = width;
			aTextColumn.DefaultCellStyle.Alignment = align;
			return aTextColumn;
		}

		public static DataGridViewCheckBoxColumn ColumnDefine(string headerText, string name, int width) {
			DataGridViewCheckBoxColumn aColumn = new DataGridViewCheckBoxColumn();
			aColumn.HeaderText = headerText;
			aColumn.Name = name;
			aColumn.Width = width;
			return aColumn;
		}

		public static DataGridViewComboBoxColumn ColumnDefine(string headerText, string name, int maxDropDownItems, int width) { //common
			DataGridViewComboBoxColumn aComboColumn = new DataGridViewComboBoxColumn();
			aComboColumn.HeaderText = headerText;
			aComboColumn.Name = name;
			aComboColumn.Width = width;
			aComboColumn.MaxDropDownItems = maxDropDownItems;
			aComboColumn.Items.Add("�\");
			aComboColumn.Items.Add("����");
			return aComboColumn;
		}
		
        public static void RowNumsDraw(DataGridView dgv, DataGridViewRowPostPaintEventArgs e, int rIndex) {
            // �s�w�b�_�̃Z���̈���A�s�ԍ���`�悷�钷���`�Ƃ���i�������E�[��4�h�b�g�̂����Ԃ��󂯂�j
            Rectangle rect = new Rectangle(
                e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            // ��L�̒����`���ɍs�ԍ����c�����������E�l�߂ŕ`�悷��t�H���g��O�i�F�͍s�w�b�_�̊���l���g�p����
            TextRenderer.DrawText(
                e.Graphics,
                rIndex.ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rect,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        public static bool isYesNoDialogBox(string mes) {
            DialogResult result = MessageBox.Show(   mes,
													 "����",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button1,
                                                     MessageBoxOptions.DefaultDesktopOnly);
            return (result == DialogResult.Yes);
        }

        public static bool isNoYesDialogBox(string mes) {
            DialogResult result = MessageBox.Show(  mes,
                                                    "",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2,
                                                    MessageBoxOptions.DefaultDesktopOnly);
            return (result == DialogResult.Yes);
        }

        public static string dateTimeObjToStr(object obj) {
            return (Convert.IsDBNull(obj) || obj == null)? "": Convert.ToDateTime(obj).ToShortDateString();
        }

        public static DateTime objToDateTime(object obj) {
            return (Convert.IsDBNull(obj) || obj == null || obj.ToString()=="" ) ? DateTime.Now: Convert.ToDateTime(obj);        
        }

        public static int objToInt(object obj) {
            return (Convert.IsDBNull(obj) || obj == null || Convert.ToString(obj) == "") ? 0 : Convert.ToInt32(obj);
        }

        public static double objToDouble(object obj) {
            return (Convert.IsDBNull(obj) || obj == null || obj.ToString()=="") ? 0 : Convert.ToDouble(obj);
        }

        public static string objToStr(object obj) {
            return (Convert.IsDBNull(obj) || obj == null) ? "" : obj.ToString();
        }

        public static bool objToBool(object obj){
            return (Convert.IsDBNull(obj) || obj == null) ? false : Convert.ToBoolean(obj);
        }
    }
}