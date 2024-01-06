using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Linq;

namespace EntryRegistWebPr{
    class EntryListJsonConvertClass {
        public const string ENTRY_LIST_FILE_NAME = "EntryList.txt";

        public static string EntryListJsonConverting(List<EventInfoClass> convertEventList,string mdbFileName) {
			// îÒåˆäJèÓïÒÇéÊìæ
			//nonExhibitionListClass.getDownLoadWebContentToFile(); 
			List<nonExhibitionClass> nonExhibitionMemmberList =null;  //nonExhibitionListClass.ReadXmlFile(nonExhibitionListClass.getSaveXmlFileName());
            List<EntryToJsonClass> aEntryJsonList = new List<EntryToJsonClass>();
            convertEventList.ForEach( delegate(EventInfoClass aEventInfoC){
                DataTable aTbl = EntryTableClass.getEntryTableDataForJsonFile(aEventInfoC, mdbFileName);
				List<teamClass> entryTeamsList = EntryTableClass.getTeamsListFromDataTbl(aTbl);
				//aEventInfoC.MaxMembers = getMaxMembers(entryTeamsList);
				List<EntryToJsonClass> aList = entryTeamsList.Select(aTeamC => new EntryToJsonClass(aEventInfoC.EventID, aTeamC, nonExhibitionMemmberList)).ToList();
                aEntryJsonList=aEntryJsonList.Concat(aList).ToList(); 
            });
			return new JavaScriptSerializer().Serialize(aEntryJsonList);
        }
    }
}
