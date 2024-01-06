using System.Collections.Generic;

namespace EntryRegistWebPr{
    public class teamClass {
        public const int MAX_TEAM_MEMBERS = 6;

        private int entrantNumber;
        private List<personClass> membersList;
        private int teamNo;
        private int totalSP;

        public int TotalSP {
            get { return totalSP; }
            set { totalSP = value; }
        }

        public int TeamNo {
            get { return teamNo; }
            set { teamNo = value; }
        }

        public int EntrantNumber {
            get { return entrantNumber; }
            set { entrantNumber = value; }
        }

        public List<personClass> MembersList {
            get { return membersList; }
            set { membersList = value; }
        }

        public teamClass() {
            entrantNumber = 0;
            membersList = new List<personClass>();
        }
    }
}

