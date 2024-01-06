using System.Collections.Generic;
using System.Linq;

namespace EntryRegistWebPr {
	class accessFieldClass{
		private string fieldName;
		private string format;

		public string Format {
			get { return format; }
			set { format = value; }
		}
		
		public string FieldName {
			get { return fieldName; }
			set { fieldName = value; }
		}
		
		public accessFieldClass(string argFieldname,string argFormat){
			this.fieldName=argFieldname;
			this.format=argFormat;
			//existFlag=false;
		}
		
	}
	
	class accessTablePrepartionClass{
		private List<accessFieldClass> fieldList;
		private string tableName;

		public string TableName {
			get { return tableName; }
			set { tableName = value; }
		}
		
		public List<accessFieldClass> FieldList {
			get { return fieldList; }
			set { fieldList = value; }
		}
		
		public accessTablePrepartionClass(string argTableName, List<accessFieldClass> argFieldList){
			this.tableName=argTableName;
			this.fieldList=argFieldList;	
		}
				
		private bool isExistFieldOnTable(string fileFullPath, string tableName, string fieldName) {
			return MicrosoftAccessClass.isExistFieldOnTable(MicrosoftAccessClass.ACCESS_BASE_CONNECTION + fileFullPath, tableName, fieldName);
		}

		public bool isExistTables() {
			return !this.fieldList.Any(flag=>false);
		}
		
		public string getNotExistsFieldMessageOfTable(string fileFullPath) {
			var aList = this.fieldList.Where(aFieldC => !this.isExistFieldOnTable(fileFullPath, this.tableName, aFieldC.FieldName));
			List<string> fieldNameList = aList.Select( aFieldC=> aFieldC.FieldName).ToList();
			return this.getErrorMessage(this.tableName, fieldNameList);
		}

		private string getErrorMessage(string tableNme, List<string> fieldNameList) {
			string s = "";
			if (fieldNameList.Count != 0) {
				s = string.Format("選択されたデータベースの{0}テーブルに,", tableNme);
				string ss = fieldNameList[0];
				for (int j = 1; j < fieldNameList.Count; j++) {
					ss += "," + fieldNameList[j];
				}
				s += ss + "フィールドがありません。\n";
			}
			return s;
		}
		
		public string makingFieldOfTable(string fileFullPath){
			string mes="";
			this.fieldList.ForEach(delegate(accessFieldClass aFieldC){
				if (!this.isExistFieldOnTable(fileFullPath, this.tableName, aFieldC.FieldName)) {
					string sql = string.Format("ALTER TABLE {0} ADD COLUMN {1} {2}", this.tableName, aFieldC.FieldName, aFieldC.Format);
					this.executeSql(fileFullPath, sql);
					mes += string.Format("{0}テーブルに{1}フィールドを作成\n", this.tableName, aFieldC.FieldName);
				}
			});
			return mes;
		}

		private void executeSql(string fileFullPath, string sql) {
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + fileFullPath);
		}
		
	}
	
	class isExistTableClass {
		private bool mailTableFlag;
		private accessTablePrepartionClass teamTable;
		private accessTablePrepartionClass teamTTable;
		private accessTablePrepartionClass eventTable;
		private accessTablePrepartionClass eventTTable;
		private string fileFullPath;

		public string FileFullPath {
			get { return fileFullPath; }
			set { fileFullPath = value; }
		}

		public accessTablePrepartionClass EventTTable {
			get { return eventTTable; }
			set { eventTTable = value; }
		}

		public accessTablePrepartionClass EventTable {
			get { return eventTable; }
			set { eventTable = value; }
		}

		public accessTablePrepartionClass TeamTTable {
			get { return teamTTable; }
			set { teamTTable = value; }
		}

		public accessTablePrepartionClass TeamTable {
			get { return teamTable; }
			set { teamTable = value; }
		}

		public bool MailTableFlag {
			get { return mailTableFlag; }
			set { mailTableFlag = value; }
		}

		public isExistTableClass(string argFileFullPath) {
			//mailTableがあるか
			this.fileFullPath = argFileFullPath;
			this.mailTableFlag = MicrosoftAccessClass.isExistTableOnDB(MicrosoftAccessClass.ACCESS_BASE_CONNECTION + this.fileFullPath, "mailTable");
			this.eventTable=new accessTablePrepartionClass("Event", this.getFieldListOfEventTable());
			this.eventTTable = new accessTablePrepartionClass("EventT", this.getFieldListOfEventTable());
			this.teamTable=new	accessTablePrepartionClass("Team",   this.getFieldListOfTeamTable());
			this.teamTTable = new accessTablePrepartionClass("TeamT", this.getFieldListOfTeamTable());
		}
		
		private List<accessFieldClass> getFieldListOfEventTable(){
			return new List<accessFieldClass>{
				new accessFieldClass("mailContent", "LONGTEXT"),
				new accessFieldClass("uploadFlag", "yesno"),
				new accessFieldClass("closingFlag", "yesno"),
				new accessFieldClass("spDispFlag", "yesno"),	 
				new accessFieldClass(" playDateEntryFlag", "yesno"),
			};	
		}
		
		private List<accessFieldClass> getFieldListOfTeamTable(){
			return new List<accessFieldClass>{
				new accessFieldClass("mailAddress",	"TEXT(100)"),
				new accessFieldClass("registDate", "TEXT(20)")
			};			
		}


		public bool isAllExist() {
			return (this.mailTableFlag && this.eventTable.isExistTables() && this.eventTTable.isExistTables() && this.teamTable.isExistTables() && this.teamTTable.isExistTables()); 
		}

		public string getExistMessage() {
			string mes="";
			if(!this.mailTableFlag){
				mes += "選択されたデータベースにmailTableがありません。\n" ;
			}
			string s = this.eventTable.getNotExistsFieldMessageOfTable(this.fileFullPath);
			if (s!=""){
				mes+=s;
			}
			s = this.eventTTable.getNotExistsFieldMessageOfTable(this.fileFullPath);
			if (s != "") {
				mes += s;
			}
			s = this.teamTable.getNotExistsFieldMessageOfTable(this.fileFullPath);
			if (s != "") {
				mes += s;
			}
			//					
			s = this.teamTTable.getNotExistsFieldMessageOfTable(this.fileFullPath);
			if (s != "") {
				mes += s;
			} 
			return mes;
		}

		public string makeTableAndField() {
			string mes="";
			string sql="";
			if (!this.mailTableFlag){
				sql = "CREATE TABLE mailTable(jcblNumber LONG CONSTRAINT PrimaryKey PRIMARY KEY,personName TEXT(20),mailAddress TEXT(100))";
				this.executeSql(sql);
				mes += "mailTableを作成\n";
			}		
			mes+=this.eventTable.makingFieldOfTable(fileFullPath);
			mes+=this.eventTTable.makingFieldOfTable(fileFullPath);
			mes+=this.teamTable.makingFieldOfTable(fileFullPath);
			mes += this.teamTTable.makingFieldOfTable(fileFullPath);
			return mes;
		}
		
		private void executeSql(string sql){
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + this.fileFullPath);		
		}
		
	}
}
