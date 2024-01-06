using System.Data;

namespace EntryRegistWebPr {
	class JcblMembersInfoClass {
		private int jcblNo;
		private string personName;

		public int JcblNo {
			get { return jcblNo; }
			set { jcblNo = value; }
		}

		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}
		
		public static string getPersonNameInfoFromDataBase(int tempJcblNo, string mdbFileName){
			string sql = "SELECT 会員番号,姓名 FROM JCBLMEM WHERE 会員番号=" + tempJcblNo.ToString();
			DataTable dt =  EntryMdbClass.getDataTable(sql, mdbFileName);
			return (dt.Rows.Count==0) ?  "": dt.Rows[0]["姓名"].ToString();
		}
	}
}
