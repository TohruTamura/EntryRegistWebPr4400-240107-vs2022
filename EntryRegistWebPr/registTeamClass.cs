using System.Collections.Generic;
using System.Linq;


namespace EntryRegistWebPr {
	class registTeamClass {
		private int eventId;
		private int entryNo;
		private List<string> jcblNumberList;
		private List<string> personNameList;
		private List<string> spList;
		private List<string> bpList;
		private List<string> sexList;
		private string postNumber;
		private string address;
		private string telNumber;
		private string mailAddress;
		private string registDate;

		public string RegistDate {
			get { return registDate; }
			set { registDate = value; }
		}
		

		public string MailAddress {
			get { return mailAddress; }
			set { mailAddress = value; }
		}

		public string PostNumber {
			get { return postNumber; }
			set { postNumber = value; }
		}

		public string Address {
			get { return address; }
			set { address = value; }
		}

		public string TelNumber {
			get { return telNumber; }
			set { telNumber = value; }
		}
		
		public int EventId {
			get { return eventId; }
			set { eventId = value; }
		}

		public int EntryNo {
			get { return entryNo; }
			set { entryNo = value; }
		}

		public List<string> JcblNumberList {
			get { return jcblNumberList; }
			set { jcblNumberList = value; }
		}

		public List<string> PersonNameList {
			get { return personNameList; }
			set { personNameList = value; }
		}

		public List<string> SpList {
			get { return spList; }
			set { spList = value; }
		}

		public List<string> BpList {
			get { return bpList; }
			set { bpList = value; }
		}
		

		public List<string> SexList {
			get { return sexList; }
			set { sexList = value; }
		}
		
		public registTeamClass(){
			this.eventId=0;
			this.entryNo=0;
			this.jcblNumberList=new List<string>();
			this.personNameList=new List<string>();
			this.spList=new List<string>();
			this.bpList=new List<string>();
			this.sexList=new List<string>();
			this.postNumber=null;
			this.address=null;
			this.telNumber=null;
			for(int j=0;j<teamClass.MAX_TEAM_MEMBERS;j++){
				this.jcblNumberList.Add("NULL");
				this.personNameList.Add("NULL");
				this.spList.Add("NULL");
				this.bpList.Add("NULL");
				this.sexList.Add("NULL");
			}
			this.mailAddress=null;
		}
		
		public string getTotalSpStr(){
			return getTotalSub(this.spList).ToString();
		}
		
		public string getTotalBpStr(){
			float f = (float)getTotalSub(this.bpList) / 100;
			return f.ToString("f2");	
		}
		
		private int getTotalSub(List<string> aStrList){
			List<int> aList=aStrList.Where(aStr=>aStr!="NULL").Select(str => (int.Parse(str))).OrderByDescending(nn=>nn).ToList();
			int n = (aList.Count > 4) ? 4 : aList.Count;
			return aList.GetRange(0, n).Sum();	   //Linq network3.5
		}
		
	}
}
