
namespace EntryRegistWebPr {
	class logDataClass {
		private string registDateTime;
		private string content;
		private int id;
		private int code;

		public int Code {
			get { return code; }
			set { code = value; }
		}

		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		public string RegistDateTime {
			get { return registDateTime; }
			set { registDateTime = value; }
		}

		public string Content {
			get { return content; }
			set { content = value; }
		}
		
		public logDataClass(){
		
		}
		
		public logDataClass(int aId,string aRegistDateTime,int aCode, string aContent){
			this.id=aId;
			this.registDateTime=aRegistDateTime;
			this.code=aCode;
			this.content=aContent;
		}
		
	}
}
