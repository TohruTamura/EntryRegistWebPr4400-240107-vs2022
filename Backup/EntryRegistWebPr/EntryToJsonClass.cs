using System.Collections.Generic;

namespace EntryRegistWebPr {
    class EntryToJsonClass {
        public int id;
        public int eNo;
        public int sp;
        public List<int> jcbl;
        public List<string> name;

		public EntryToJsonClass(int eventID, teamClass aTeamInfo, List<nonExhibitionClass> nonExhibitionMembersList) {
            this.id = eventID;
            this.eNo = aTeamInfo.EntrantNumber;
            this.sp = aTeamInfo.TotalSP;
            this.jcbl = new List<int>();
            this.name = new List<string>();
            aTeamInfo.MembersList.ForEach( delegate(personClass aPersonC){			
				//if (aPersonC.JcblNumber != 0) {
				if (string.IsNullOrEmpty(aPersonC.PersonName)==false) {	   // on 12/10/12
					jcbl.Add(aPersonC.JcblNumber);
					string s = aPersonC.PersonName;
					//if (noExbitionInfoFlag) {
					//    if (nonExhibitionListClass.isNonExhibitionMember(nonExhibitionMembersList, aPersonC.JcblNumber)) {
					//        s = "*****";
					//    }
					//}
					name.Add(s);
				}
			});
        }
    }
}
