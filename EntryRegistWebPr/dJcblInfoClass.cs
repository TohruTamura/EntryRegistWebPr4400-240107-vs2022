using System.Data;

// on 120/9/08
// on 13/04/03 会員情報取得のsqlにバグがあった。

namespace EntryRegistWebPr {
	class dJcblInfoClass {
		private int jcblNumber;
		private string personName;
		private bool senior;
		private string furigana;
		private string sex;

		public string Sex {
			get { return sex; }
			set { sex = value; }
		}

		public int JcblNumber {
			get { return jcblNumber; }
			set { jcblNumber = value; }
		}

		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}

		public bool Senior {
			get { return senior; }
			set { senior = value; }
		}

		public string Furigana {
			get { return furigana; }
			set { furigana = value; }
		}

		public dJcblInfoClass(int aJcblNuber, string aPersonName, bool aSenior, string aFurigana,string aSex) {
			this.jcblNumber = aJcblNuber;
			this.personName = aPersonName;
			this.senior = aSenior;
			this.furigana = aFurigana;
			this.sex=aSex;
		}

		public static DataTable getMPTable(int min, int max) {
			string sql = string.Format("SELECT 会員番号,姓名,敬老割引,フリガナ,性別 FROM JCBLMEM WHERE 会員番号 BETWEEN {0} AND {1}", min, max); //on 13/04/03
			return EntryMdbClass.getDataTable(sql, new entryFileClass().FileFullPath); 
			//string sql = string.Format("SELECT 会員番号,姓名,敬老割引,フリガナ FROM {0} WHERE 会員番号 BETWEEN {1} AND {2}", mpInfoTableName, min, max);
			//return EntryMdbClass.getDataTable(sql, new entryFileClass().FileFullPath); 
			//DataTable dt = JcblInfoManageClass.getDataTable(sql);
			//DataColumn[] cc = new DataColumn[1];
			//cc[0] = dt.Columns[0];
			//dt.PrimaryKey = cc;
			//return dt;
		}
	}
}
