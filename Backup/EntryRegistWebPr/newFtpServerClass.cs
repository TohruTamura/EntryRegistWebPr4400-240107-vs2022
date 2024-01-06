using System.Web.Script.Serialization;

namespace EntryRegistWebPr {
	class newFtpServerClass {
		private string fptServerName;
		private string ftpDefaultFolder;
		private string ftpAccount;
		private string homePageUrl;
		private string entryFolderName;
		private string webDbPassword;
		private string ftpUserPassword;

		public string FptServerName {
			get { return fptServerName; }
			set { fptServerName = value; }
		}

		public string FtpDefaultFolder {
			get { return ftpDefaultFolder; }
			set { ftpDefaultFolder = value; }
		}

		public string FtpAccount {
			get { return ftpAccount; }
			set { ftpAccount = value; }
		}

		public string FtpUserPassword {
			get { return ftpUserPassword; }
			set { ftpUserPassword = value; }
		}

		public string HomePageUrl {
			get { return homePageUrl; }
			set { homePageUrl = value; }
		}

		public string EntryFolderName {
			get { return entryFolderName; }
			set { entryFolderName = value; }
		}

		public string WebDbPassword {
			get { return webDbPassword; }
			set { webDbPassword = value; }
		}

		public newFtpServerClass() {
            readProperties();
        }
        		
		public void readProperties() {
			this.fptServerName=Properties.newFtpServer.Default.ftpServerName;
			this.ftpDefaultFolder=Properties.newFtpServer.Default.ftpDefaultFolder;
			this.ftpAccount=Properties.newFtpServer.Default.ftpAccount;
			this.ftpUserPassword=Properties.newFtpServer.Default.ftpUserPassword;
			this.homePageUrl=Properties.newFtpServer.Default.homePageUrl;
			this.entryFolderName=Properties.newFtpServer.Default.entryFolderName;
			this.webDbPassword=Properties.newFtpServer.Default.WebDbPassword;
			
		}

		public void writeProperties() {
			Properties.newFtpServer.Default.ftpServerName=this.fptServerName;
			Properties.newFtpServer.Default.ftpDefaultFolder=this.ftpDefaultFolder;
			Properties.newFtpServer.Default.ftpAccount=this.ftpAccount;
			Properties.newFtpServer.Default.homePageUrl=this.homePageUrl;
			Properties.newFtpServer.Default.entryFolderName=this.entryFolderName;
			Properties.newFtpServer.Default.WebDbPassword=this.webDbPassword;
            Properties.newFtpServer.Default.ftpUserPassword=this.FtpUserPassword; //on 17/04/22
			Properties.newFtpServer.Default.Save();
		}

		public static string getWebRootDirectory() {
			// www.ofunabc.jp/wwwroot/ofunabc.jp
			newFtpServerClass aClass=new newFtpServerClass();
			return string.Format("{0}/{1}",aClass.FptServerName,aClass.FtpDefaultFolder);
			//return string.Format("{0}/", new ftpSeverClass().ftpServerName);
		}

		private string getWebPhpFolderName() { // on 17/04/22
			//http://www.ofunabc.jp/entrySystemOfunaDB/php/eventInfoRegist.php		
			//return string.Format("http://{0}/{1}/php/", this.fptServerName, this.entryFolderName);
            return string.Format("http://{0}/{1}/php/", this.homePageUrl, this.entryFolderName);
		}

		public string getWebPhpUrl(string phpFileName) {
			return string.Format("{0}{1}", this.getWebPhpFolderName(), phpFileName);
		}
		
		public string getEventListHtml() {
			return string.Format("http://{0}/{1}/entryDisp/EventList.html", this.homePageUrl, this.entryFolderName);
		}

		public string getWebEntrySendMailPhpUrl() {
			return string.Format("http://ofunabc.jp/{0}/php/newEntrySendMail.php", this.entryFolderName); // on 17/08/17
            //return string.Format("http://{0}/{1}/php/newEntrySendMail.php", this.fptServerName, this.entryFolderName);
		}
		
		public string getWebTempFolder(){
            // on 17/03/23 fptServerNameの後 //に
			string s = string.Format("{0}//{1}/{2}/temp/",this.fptServerName,this.ftpDefaultFolder,this.entryFolderName);
			return s;
		}
		
		public string convertToJson(){
			string s=new JavaScriptSerializer().Serialize(this);
			return s;
		}
		
		public static newFtpServerClass jsonToConvert(string s){
			newFtpServerClass aClass=new JavaScriptSerializer().Deserialize<newFtpServerClass>(s);
			return aClass;
		}
		
		
	}
}
