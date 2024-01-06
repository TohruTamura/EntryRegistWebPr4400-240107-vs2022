
namespace EntryRegistWebPr {
    class EventToJsonClass {
        private int eventID_;
        private string eventDate_;
        private string eventName_;
        private string eventType_; // on 08/11/07
        private int entryNums_;
        private bool closingFlag_; // 08/11/07
        private int maxMembers_;
		private bool spDispFlag_; // on 10/03/18
		private bool playDateEntryFlag_; // on 14/01/16

		public bool PlayDateEntryFlag_ {
			get { return playDateEntryFlag_; }
			set { playDateEntryFlag_ = value; }
		}

		public bool SpDispFlag_ {
			get { return spDispFlag_; }
			set { spDispFlag_ = value; }
		}

        public int eventID {
            get { return eventID_; }
            set { eventID_ = value; }
        }

        public string eventDate {
            get { return eventDate_; }
            set { eventDate_ = value; }
        }

        public string eventName {
            get { return eventName_; }
            set { eventName_ = value; }
        }

        public string eventType {
            get { return eventType_; }
            set { eventType_ = value; }
        }

        public int entryNums {
            get { return entryNums_; }
            set { entryNums_ = value; }
        }

        public bool closingFlag {
            get { return closingFlag_; }
            set { closingFlag_ = value; }
        }

        public int maxMembers {
            get { return maxMembers_; }
            set { maxMembers_ = value; }
        }

        public EventToJsonClass() {
        }

        public EventToJsonClass(EventInfoClass aEventInfo) {
            this.eventID_ = aEventInfo.EventID;
            this.eventDate_ = aEventInfo.EventDate.ToShortDateString();
            this.eventName_ = aEventInfo.EventName;
            this.eventType_ = aEventInfo.EventType;
            this.entryNums_ = aEventInfo.EntryNums;
            this.closingFlag_ = aEventInfo.ClosingFlag;
            this.maxMembers_ = aEventInfo.MaxMembers;
            this.spDispFlag_=aEventInfo.SpDispFlag;
            this.playDateEntryFlag_=aEventInfo.PlayDateEntryFlag;
        }

		//public void EventInfoToJoson(EventInfoClass aEventInfo) {
		//    this.eventID_ = aEventInfo.EventID;
		//    this.eventDate_ = aEventInfo.EventDate.ToShortDateString();
		//    this.eventName_ = aEventInfo.EventName;
		//    this.eventType_ = aEventInfo.EventType;
		//    this.entryNums_ = aEventInfo.EntryNums;
		//    this.closingFlag_ = aEventInfo.ClosingFlag;
		//    this.maxMembers_ = aEventInfo.MaxMembers;
		//    this.spDispFlag_ = aEventInfo.SpDispFlag;
		//}
    }
}
