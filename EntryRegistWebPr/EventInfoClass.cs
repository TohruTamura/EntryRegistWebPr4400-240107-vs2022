using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EntryRegistWebPr{
    public class EventInfoClass {
        private int eventID;
        protected DateTime eventDate;
        protected string eventName;
        private string eventType; // on 08/11/07
        private int entryNums;
        private bool closingFlag; // 08/11/07
        private int maxMembers;
		private bool spDispFlag;  // on 10/03/18
		private bool uploadFlag;
		private bool playDateEntryFlag;

		public bool PlayDateEntryFlag {
			get { return playDateEntryFlag; }
			set { playDateEntryFlag = value; }
		}
		

		public bool UploadFlag {
			get { return uploadFlag; }
			set { uploadFlag = value; }
		}
		

		public bool SpDispFlag {
			get { return spDispFlag; }
			set { spDispFlag = value; }
		}
        

        public string EventType {
            get { return eventType; }
            set { eventType = value; }
        }

        public bool ClosingFlag {
            get { return closingFlag; }
            set { closingFlag = value; }
        }

        public int EventID {
            get { return eventID; }
            set { eventID = value; }
        }

        public DateTime EventDate {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public string EventName {
            get { return eventName; }
            set { eventName = value; }
        }

        public int MaxMembers {
            get { return maxMembers; }
            set { maxMembers = value; }
        }

        public int EntryNums {
            get { return entryNums; }
            set { entryNums = value; }
        }

        public EventInfoClass() {
            eventDate = DateTime.Now;
            eventName = "";
            maxMembers = 2;
            entryNums = 0;
            spDispFlag=false;
            uploadFlag=true;
        }

        public string getEventdateAndWeekStr() {
            return string.Format("{0}({1})", eventDate.ToShortDateString(), etcClass.getDayOfWeekJ(eventDate));
        }

		public bool isTeamEvent() {
			 return this.maxMembers>2;
		}
    }

    public class EventInfoManageClass{

        public static DataTable getEventInfoDataTable(string sql,string mdbFileName) {
            return EntryMdbClass.getDataTable(sql,mdbFileName);
        }

        private static EventInfoClass getEventInfoFromDataRow(DataRow dr, string sourceFileName) {
            EventInfoClass aInfo = new EventInfoClass(){
				EventID = etcClass.objToInt(dr["EventID"]),
				EventDate = Convert.ToDateTime(dr["EventDate"]),
				EventName = dr["EventName"].ToString(),
				EventType = etcClass.objToStr(dr["EventType"]),
				UploadFlag = etcClass.objToBool(dr["uploadFlag"]),
				ClosingFlag = etcClass.objToBool(dr["closingFlag"]),
                SpDispFlag = etcClass.objToBool(dr["spDispFlag"]),
                PlayDateEntryFlag=etcClass.objToBool(dr["PlayDateEntryFlag"])
            };
            aInfo.MaxMembers= getMaxMembers(etcClass.objToStr(dr["tab"]));
			aInfo.EntryNums = EntryTableClass.getEntryNums(aInfo.EventID,sourceFileName); // on 08/12/12
            return aInfo;
        }
		
		private static int getMaxMembers(string s){   // on 2010/05/01
			return s.ToCharArray().Count(ch=>ch=='1');
		}
		
        public static List<EventInfoClass> getEventInfoList(bool allDispFlag,string mdbFileName){
			DataTable dt = getEventInfoDataTable(getEachEventListSqlStr(allDispFlag), mdbFileName);
			return etcClass.getDataTableRowsList(dt).Select(aRow=>getEventInfoFromDataRow(aRow, mdbFileName)).ToList();				
        }

        private static string getEachEventListSqlStr(bool allDispFlag) {
            // update情報はない
			string sql = "SELECT Event AS EventID, 日程 AS EventDate, 競技会名 AS EventName, 種目 AS EventType,タブ AS tab, uploadFlag,closingFlag,spDispFlag,PlayDateEntryFlag FROM Event";
            if (!allDispFlag){
                sql += string.Format(" WHERE 日程>=#{0}#", DateTime.Now.ToShortDateString());
            }
            sql += " ORDER BY 日程 ";
            return sql;
        }

		/// <summary>
		/// EventIdから個々のEvent情報を取得する
		/// </summary>
		/// <param name="eventId"></param>
		/// <returns></returns>
		public static EventInfoClass getEachEventInfo(int eventId, string mdbFileName) {   // on 12/07/15
			string sql =string.Format("SELECT Event AS EventID, 日程 AS EventDate, 競技会名 AS EventName, 種目 AS EventType,タブ AS tab FROM Event WHERE Event={0}",eventId);
			DataTable dt = getEventInfoDataTable(sql, mdbFileName);
			EventInfoClass aEventInfoC = getEventInfoFromDataRow(dt.Rows[0], mdbFileName);
			return aEventInfoC;
		}

		public static void updateOfUploadFlagAndClosingFlag(bool uploadFlag,bool closingFlag,bool spDispFlag,bool playDateEntryFlag, int eventId) {
			int uploadFlagVal = (uploadFlag) ? -1 : 0;
			int closingFlagVal=(closingFlag)?-1:0;
            int spDispFlagVal = (spDispFlag) ? -1 : 0;
			string sql = string.Format("UPDATE Event SET uploadFlag={0},closingFlag={1},spDispFlag={2},PlayDateEntryFlag={3} WHERE Event={4}", uploadFlagVal, closingFlagVal, spDispFlagVal,playDateEntryFlag, eventId);
			MicrosoftAccessClass.executeSQL(sql, MicrosoftAccessClass.ACCESS_BASE_CONNECTION + new entryFileClass().FileFullPath);
		}
    }
}
