using System.Data;

namespace EntryRegistWebPr {
	class dMpInfoClass {
		private int month;
		private int jcblNumber;
		private int bp;
		private int rp;
		private int sp;

		public int Month {
			get { return month; }
			set { month = value; }
		}

		public int JcblNumber {
			get { return jcblNumber; }
			set { jcblNumber = value; }
		}

		public int Bp {
			get { return bp; }
			set { bp = value; }
		}

		public int Rp {
			get { return rp; }
			set { rp = value; }
		}

		public int Sp {
			get { return sp; }
			set { sp = value; }
		}

		public dMpInfoClass(int aMonth, int aJcblNumber, int aBp, int aRp, int aSp) {
			this.month = aMonth;
			this.jcblNumber = aJcblNumber;
			this.bp = aBp;
			this.rp = aRp;
			this.sp = aSp;
		}

		public static DataTable getJcblMemDataTable(int minJcblNumber, int maxJcblNumber) {
			string sql = string.Format("SELECT 会員番号,合計MP,合計RP,SP00 FROM JCBLMEM WHERE 会員番号 BETWEEN {0} AND {1}", minJcblNumber, maxJcblNumber);
			return EntryMdbClass.getDataTable(sql, new entryFileClass().FileFullPath);
		}
		
		//public static DataTable getMPTable(string mpInfoTableName, int min, int max) {
		//    string sql = string.Format("SELECT 会員番号,合計MP,合計RP,SP00 FROM {0} WHERE 会員番号 BETWEEN {1} AND {2}", mpInfoTableName, min, max);
		//    DataTable dt = JcblInfoManageClass.getDataTable(sql);
		//    return dt;
		//}

	}
}
