using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EntryRegistWebPr{
    class EntryTableClass {
        public enum fieldT {
            EventID,                        //0
            EntryNo,                        //1
            TotalSP,                        //2
            JCBLNumber_0,personName_0,      //3-4
            JCBLNumber_1, personName_1,     //5-6
            JCBLNumber_2, personName_2,     //7-8
            JCBLNumber_3, personName_3,     //9-10
            JCBLNumber_4, personName_4,     //11-12
            JCBLNumber_5, personName_5      //13-14
        };


        //全てのデータを読み込んでいる
        public static DataTable getEntryTableDataForJsonFile(EventInfoClass aEventInfo,string mdbFileName) {
            string sql = getSqlOfEntryTableData(aEventInfo.EventID);
            return MicrosoftAccessClass.getDataTable(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + mdbFileName);
        }

        private static string getSqlOfEntryTableData(int eventID) {
            string sql = "SELECT Team.Event, Team.受付番号, Team.ＳＰ合計, Team.[1Number], Team.[1Name], Team.[2Number], Team.[2Name], Team.[3Number], Team.[3Name], Team.[4Number], Team.[4Name], Team.[5Number], Team.[5Name], Team.[6Number], Team.[6Name] FROM Team";
			sql += string.Format(" WHERE Team.Event={0} AND Team.Cancel=False ORDER BY Team.受付番号", eventID);          
            return sql;
        }

        public static List<teamClass> getTeamsListFromDataTbl(DataTable entryTable) {
			return etcClass.getDataTableRowsList(entryTable).Select(aRow=> getTeamClassFromDataRow(aRow)).ToList();
        }

		private static teamClass getTeamClassFromDataRow(DataRow aRow) {
			teamClass aTeamInfo = new teamClass(){
				EntrantNumber = etcClass.objToInt(aRow[(int)fieldT.EntryNo]),
				TotalSP = etcClass.objToInt(aRow[(int)fieldT.TotalSP])
			};
			for (int jj = 0; jj < teamClass.MAX_TEAM_MEMBERS; jj++) {
				aTeamInfo.MembersList.Add(getPersonInfoFromDataTbl(aRow, new personFieldClass(jj)));
			}
			return aTeamInfo;
		}

        private static personClass getPersonInfoFromDataTbl(DataRow aRow,personFieldClass aPersonField) { // on 11/08/27
            return new personClass(){
				JcblNumber = etcClass.objToInt(aRow[(int)aPersonField.F_JcblNumber]),
				PersonName = etcClass.objToStr(aRow[(int)aPersonField.F_personName])           
            };
        }

        public static int getEntryNums(int eventID,string mdbFileName) {
            return MicrosoftAccessClass.getTableDataNums(string.Format("SELECT COUNT(*) FROM Team WHERE Event={0} AND Cancel=false", eventID),MicrosoftAccessClass.ACCESS_BASE_CONNECTION+ mdbFileName);	 // on 10/03/17
        }
    }

    class personFieldClass {
        private EntryTableClass.fieldT f_JcblNumber;
        private EntryTableClass.fieldT f_personName;

        public EntryTableClass.fieldT F_JcblNumber {
            get { return f_JcblNumber; }
            set { f_JcblNumber = value; }
        }

        public EntryTableClass.fieldT F_personName {
            get { return f_personName; }
            set { f_personName = value; }
        }

        public personFieldClass(int ord) {
            switch (ord) {
                case 0: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_0;
                    f_personName = EntryTableClass.fieldT.personName_0;
                    break;
                case 1: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_1;
                    f_personName = EntryTableClass.fieldT.personName_1;
                    break;
                case 2: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_2;
                    f_personName = EntryTableClass.fieldT.personName_2;
                    break;
                case 3: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_3;
                    f_personName = EntryTableClass.fieldT.personName_3;
                    break;
                case 4: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_4;
                    f_personName = EntryTableClass.fieldT.personName_4;
                    break;
                case 5: f_JcblNumber = EntryTableClass.fieldT.JCBLNumber_5;
                    f_personName = EntryTableClass.fieldT.personName_5;
                    break;
            }
        }
    }
}
