using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Text;


namespace EntryRegistWebPr {
	public class nonExhibitionClass {
		
		private int jcblNo;
		private string registDate;
		private string personName;

		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}

		public string RegistDate {
			get { return registDate; }
			set { registDate = value; }
		}

		public int JcblNo {
			get { return jcblNo; }
			set { jcblNo = value; }
		}

		public nonExhibitionClass(){
			jcblNo=0;
			registDate="";
			personName="";
		}
		
		public nonExhibitionClass(int aJcblNumber,string aPersonName,string aRegistDate){
			this.jcblNo=aJcblNumber;
			this.personName=aPersonName;
			this.registDate=aRegistDate;
		}
		
		public bool isSame(nonExhibitionClass arg){
			if (this.jcblNo!=arg.jcblNo){
				return false;
			}
			if (this.personName != arg.personName) {
				return false;
			}
			if (this.registDate != arg.registDate) {
				return false;
			}			
			return true;
		}
	}
	
	public class nonExhibitionListClass{
		public const string NON_EXHIBIT_INFO_FILE_NAME = "nonExhibitionInfo.txt";

		private List<nonExhibitionClass> nonExhibitionList;

		public List<nonExhibitionClass> NonExhibitionList {
			get { return nonExhibitionList; }
			set { nonExhibitionList = value; }
		}
		
		private nonExhibitionListClass(){
			nonExhibitionList=new List<nonExhibitionClass>();
		}

		//public static string getSaveXmlFileName() {
		//// Windows7対策用にC#のentryTempに保存するように変更 on 11/08/22
		//    return ConsoleIniClass.ENTRY_TEMP_DIR + "\\" + NON_EXHIBIT_INFO_FILE_NAME;
		//}
		
		public static List<nonExhibitionClass> ReadJsonFile(string fileFullPath) {
			StreamReader sr = new StreamReader(fileFullPath,Encoding.GetEncoding("UTF-8"));
			string s = sr.ReadToEnd();
			sr.Close();
			List<nonExhibitionClass> swc=new JavaScriptSerializer().Deserialize<List<nonExhibitionClass>>(s);
			return swc;
		}

		public static void writeJsonFile(List<nonExhibitionClass> aList, string fileFullPath) {
			string s=new JavaScriptSerializer().Serialize(aList);
			StreamWriter sw = new StreamWriter(fileFullPath,false,Encoding.GetEncoding("UTF-8"));
			sw.Write(s);
			sw.Close();
		}

		public static void Sorting(List<nonExhibitionClass> aList) {
			aList.Sort(delegate(nonExhibitionClass x, nonExhibitionClass y) {
				return x.JcblNo-y.JcblNo;  //これが大事
			});
		}
		
		//public static bool getDownLoadWebContentToFile() {
		//    try {
		//        string fullFilePath = ftpUploadClass.getEventListInitDirFullUri() + NON_EXHIBIT_INFO_FILE_NAME;
		//        StreamWriter sw = new StreamWriter(getSaveXmlFileName(), false);
		//        sw.Write(ftpUploadClass.downLoadStringFromWebFile(fullFilePath));
		//        sw.Close();
		//        return true;
		//    }
		//    catch {
		//        return false;
		//    }
		//}

		public static bool isSame(List<nonExhibitionClass> aList, List<nonExhibitionClass> bList) {
			if (aList.Count != bList.Count) {
				return false;
			}
			bool flag=aList.SequenceEqual(bList);
			for (int j = 0; j < aList.Count; j++) {
				if(!aList[j].isSame(bList[j])){
					return false;
				}
			}
			return true;
		}

		public static bool isNonExhibitionMember(List<nonExhibitionClass> nonExhibitionList, int jcblNo) {
			return nonExhibitionList.Any( d=> d.JcblNo==jcblNo);
		}		
	}
	
}
