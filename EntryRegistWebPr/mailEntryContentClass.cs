
namespace EntryRegistWebPr {
	class mailEntryContentClass {
		private int entryNumber;
		private string personName;
		private string mailAddress;
		private int eventId;
		private string mailContent;

		public string MailContent {
			get { return mailContent; }
			set { mailContent = value; }
		}

		public int EventId {
			get { return eventId; }
			set { eventId = value; }
		}

		public int EntryNumber {
			get { return entryNumber; }
			set { entryNumber = value; }
		}

		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}

		public string MailAddress {
			get { return mailAddress; }
			set { mailAddress = value; }
		}

		public mailEntryContentClass(int aEntryNo, string aPersonName, string aMailAddress, int aEventId, string aMailContent) {
			this.entryNumber = aEntryNo;
			this.personName = aPersonName;
			this.mailAddress = aMailAddress;
			this.eventId = aEventId;
			this.mailContent = aMailContent;
		}	
	}
}
