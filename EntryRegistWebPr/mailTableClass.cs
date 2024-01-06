using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	public class mailTableClass {
		private int jcblNumber;
		private string personName;
		private string mailAddress;

		public int JcblNumber {
			get { return jcblNumber; }
			set { jcblNumber = value; }
		}

		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}

		public string MailAddress {
			get { return mailAddress; }
			set { mailAddress = value; }
		}

		public bool isSame(mailTableClass arg){
			return (arg.jcblNumber==this.jcblNumber && arg.personName==this.personName && arg.mailAddress==this.mailAddress);
		}
		
		public bool isRegisted(){
			string sql=string.Format("SELECT COUNT(*) FROM mailTable WHERE JCBLNumber={0}",this.JcblNumber);
			int n = MicrosoftAccessClass.getTableDataNums(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
			return n!=0;
		}
				
		public void doUserUpdate() {
			string sql = string.Format("UPDATE mailTable SET mailAddress='{0}' WHERE JCBLNumber={1}", this.mailAddress, this.jcblNumber);
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
		}
		
		public void doUserRegist(){
			string sql = "INSERT INTO mailTable (jcblNumber,personName,mailAddress) VALUES ({0},'{1}','{2}')";
			sql=string.Format(sql,this.jcblNumber,this.personName,this.mailAddress);
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
		}
			
		public static List<mailTableClass> getMailList() {
			string sql = "SELECT jcblNumber,personName,mailAddress FROM mailTable ORDER BY jcblNumber";
			DataTable dt = MicrosoftAccessClass.getDataTable(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
			var aList = etcClass.getDataTableRowsList(dt);
			List<mailTableClass> aTeamList = aList.Select(aRow => { return getrMailTableClassFromMailTable(aRow); }).ToList();
			return aTeamList;
		}

		private static mailTableClass getrMailTableClassFromMailTable(DataRow aRow) {
			return new mailTableClass(){
				JcblNumber = etcClass.objToInt(aRow[0]),
				PersonName = etcClass.objToStr(aRow[1]),
				MailAddress = etcClass.objToStr(aRow[2])
			};
		}
		
		public static void eachUserDeleteOfWebDb(int jcblNumber){
			string sql=string.Format("DELETE FROM mailTable WHERE jcblNumber={0}",jcblNumber);
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
		}
		
		/// <summary>
		/// 削除した場合はtrueを返す
		/// </summary>
		/// <returns></returns>
		public bool deleteEachUser(){
			string message = string.Format("{0}をメールリストから削除しますか?", this.personName);
			if (etcClass.isNoYesDialogBox(message)) {
				mailTableClass.eachUserDeleteOfWebDb(this.jcblNumber);
				MessageBox.Show("削除しました");
				return true;
			}
			else{
				return false;
			}
		}
		
	}
}
