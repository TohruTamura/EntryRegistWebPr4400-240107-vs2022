using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

// on 13/02/05
//・webentryaddress Tableを削除
//・centernameをshortcenternameに変更
//・longcenternameを追加
//・urlandfoldernameを追加

namespace EntryRegistWebPr {
	class webFormatClass {

		public const string WEB_FORMAT_FILE_NAME = "webFormat.txt";

		private string shortCenterName;
		private string mailAddress;
		private string telNumber;
        private string longCenterName;
        private string urlAndFolderName;

        public string UrlAndFolderName
        {
            get { return urlAndFolderName; }
            set { urlAndFolderName = value; }
        }


        public string LongCenterName{
            get { return longCenterName; }
            set { longCenterName = value; }
        }


		public string ShortCenterName {
			get { return shortCenterName; }
			set { shortCenterName = value; }
		}

		public string MailAddress {
			get { return mailAddress; }
			set { mailAddress = value; }
		}

		public string TelNumber {
			get { return telNumber; }
			set { telNumber = value; }
		}

		
		public webFormatClass(){
		}
		
		public static webFormatClass getWebFormatFromDB(int id) {
			NameValueCollection post = new NameValueCollection();
			post.Add("id", id.ToString());
            string jsonStr = postOFHttpClass.getPhpResultMultiParamWithoutPasswordParam(post, "getWebFormatForC.php");
			List<webFormatClass> aList = new JavaScriptSerializer().Deserialize<List<webFormatClass>>(jsonStr);
			return aList[0]; //1個しかないので		
		}
	}
}
