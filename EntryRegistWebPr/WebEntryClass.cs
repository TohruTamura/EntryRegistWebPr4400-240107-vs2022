using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	class WebEntryClass {
		public int id;
		public string eventDate;
		public string eventName;
		public List<string> jcbl;
		public List<string> name;
		public string zipCode;
		public string address;
		public string telNumber;
		public string mailAddress;
		public string message;
		public string eNo;
		public string sp;
		public List<string> sexes;
		public List<string> bps;
		public List<string> eachSps;
		public string webRegistDate;
		
		public WebEntryClass() {
			this.id = -1;
			this.eventDate = "";
			this.eventName = "";
			this.jcbl = new List<string>();
			this.name = new List<string>();
			this.zipCode = "";
			this.address = "";
			this.telNumber = "";
			this.mailAddress = "";
			this.message = "";
			this.eNo = "";
			this.sp = "";
			this.sexes=new List<string>();
			this.bps=new List<string>();
			this.eachSps = new List<string>();
			this.webRegistDate="";
			
		}

		public WebEntryClass(tempRegistClass arg) {
			this.id = arg.id;
			this.eventDate = arg.eventDate;
			this.eventName = arg.eventName;
			this.jcbl =arg.jcbl.ToList();
			this.name=arg.name.ToList();
			string s = arg.postNumber[0];
			for (int j = 1; j < arg.postNumber.Length; j++) {
				s += "-"+arg.postNumber[j];
			}
			if (s=="-"){
				s="";
			}
			this.zipCode = s;
			this.address = arg.address;
			s = arg.telNumber[0];
			for (int j = 1; j < arg.telNumber.Length; j++) {
				s += "-"+arg.telNumber[j];
			}
			if(s=="--"){
				s="";
			}
			this.telNumber = s;
			this.mailAddress = arg.mailAddress;
			this.message = arg.message;
			this.eNo = arg.eNo;
			this.sp = arg.sp;
			if(arg.sex==null){
				this.sexes=new List<string>();
			}
			else{
				this.sexes =arg.sex.ToList();
			}
			if(arg.bp==null){
				this.bps=new List<string>();
			}
			else{
				this.bps=arg.bp.ToList();
			}
			if (arg.eachSp == null) {
				this.bps = new List<string>();
			}
			else {
				this.eachSps = arg.eachSp.ToList();
			}
			this.webRegistDate=arg.webRegistDate; 
		}
		
		// on 11/11/29 不正なデータをチェックし、あればnullを返す
		public static WebEntryClass getWebEntryClassFromTempRegistClass(tempRegistClass arg){
			try{
				WebEntryClass aClass = new WebEntryClass();
				aClass.id = arg.id;
				aClass.eventDate = arg.eventDate;
				aClass.eventName = arg.eventName;
				aClass.jcbl = arg.jcbl.ToList();
				aClass.name = arg.name.ToList();
				string s = arg.postNumber[0];
				for (int j = 1; j < arg.postNumber.Length; j++) {
					s += "-" + arg.postNumber[j];
				}
				if (s == "-") {
					s = "";
				}
				aClass.zipCode = s;
				aClass.address = arg.address;
				s = arg.telNumber[0];
				for (int j = 1; j < arg.telNumber.Length; j++) {
					s += "-" + arg.telNumber[j];
				}
				if (s == "--") {
					s = "";
				}
				aClass.telNumber = s;
				aClass.mailAddress = arg.mailAddress;
				aClass.message = arg.message;
				aClass.eNo = arg.eNo;
				aClass.sp = arg.sp;
				aClass.sexes = arg.sex.ToList();
				aClass.bps = arg.bp.ToList();
				aClass.eachSps = arg.eachSp.ToList();
				return aClass;
			}
			catch{
				return null;
			}		
		}

		public static List<WebEntryClass> getWebEntryList() {
            string response=postOFHttpClass.getPhpResultWithoutWebPassword("getWebEntryList.php");

            try{
                List<tempRegistClass> tList = new JavaScriptSerializer().Deserialize<List<tempRegistClass>>(response);
                if (tList.Count == 0){
                    return null;
                }
                else{
                    return tList.Select(aObj => new WebEntryClass(aObj)).ToList();
                }
            }
            catch{
                return null;
            }
		
		}
		
	}
}
