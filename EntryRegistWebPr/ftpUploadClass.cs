using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace EntryRegistWebPr{
    class ftpUploadClass {

		public const string DATA_FOLDER_NAME="temp";
		
		public static bool isExistFileInFtpServer(string folderFullPath, string aFileName) {
			return GetFtpDirectoryList(folderFullPath).Any(fileName=> fileName==aFileName);
		}

		/// <summary>
		/// 汎用性なし on 11/08/21
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="newFileName"></param>
		/// <returns></returns>
		public static bool RenameOfEventListInitFtpFile(string fileName, string newFileName) {
			return RenameOfFtpFile(fileName,newFileName,getEventListInitDirFullUri());
		}
					
		public static bool RenameOfFtpFile(string fileName,string newFileName,string fullUri){
			//名前を変更するファイルのURI
			Uri u = new Uri(fullUri+ fileName);
			//FtpWebRequestの作成
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
			//ログインユーザー名とパスワードを設定
			ftpReq.Credentials = getFtpCredential();
			//MethodにWebRequestMethods.Ftp.Rename(RENAME)を設定
            try {
				ftpReq.Method = WebRequestMethods.Ftp.Rename;
				//変更後の新しいファイル名を設定
				ftpReq.RenameTo = newFileName;
				//FtpWebResponseを取得
				FtpWebResponse ftpRes =(FtpWebResponse)ftpReq.GetResponse();
				//閉じる
				ftpRes.Close();
				return true;
			}
			catch{
				return false;
			}		
		}
		
		//public static bool upLoadFile(string fileFullPath, TextBox convMessageTextBox, string sourceFileName) {
		//    ftpSeverClass ftpServer = new ftpSeverClass();
		//    return upLoadFileToFTP(fileFullPath, convMessageTextBox, ftpSeverClass.getWebTargetDirectory(sourceFileName));
		//}

        public static string isConfirmOfWeb() {
            //InterNet接続確認
            if (!ftpUploadClass.IsInternetConnected()) {
                return "インターネットに接続できません。接続を確認してください";
            }
            return "";
        }

		/// <summary>
		/// FTPサーバーにDirを作成する
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="sendStr"></param>
		/// <param name="ftpServer"></param>
		/// <returns></returns>
		public static void makeDirectory(string dirUri) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(dirUri);
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.MakeDirectory;
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse()) {
			}
		}


		public static bool newUploadString(string uri, string sendStr, newFtpServerClass ftpServer) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(uri));
			newSetCredetials(ftpReq, ftpServer);  //ログインユーザー名とパスワードを設定
			ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

			ftpReq.KeepAlive = false;  //要求の完了後に接続を閉じる
			ftpReq.UseBinary = false;  //ASCIIモードで転送する
			ftpReq.UsePassive = false; //PASVモードを無効にする

			byte[] postDataBytes = Encoding.UTF8.GetBytes(sendStr);
			try {
				Stream reqStrm = ftpReq.GetRequestStream();
				reqStrm.Write(postDataBytes, 0, postDataBytes.Length);
				reqStrm.Close();

				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponseを取得
				ftpRes.Close();
				return true;
			}
			catch {
				return false;
			}
		}

		private static void newSetCredetials(FtpWebRequest ftpReq, newFtpServerClass ftpServer) {
			ftpReq.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
		}

		// EventListとEntryListをアップロードするために
		public static string uploadDispDataString(string fileName, string sendStr) { // on 11/08/20
			return uploadString(fileName, sendStr, getDataFolderFullUri());
		}

		// EventListとEntryListをアップロードするために
		public static string uploadDispInitDataString(string fileName, string sendStr) { // on 11/08/20
			return uploadString(fileName,sendStr,getEventListInitDirFullUri());
		}
							
        public static string uploadString(string fileName,string sendStr, string fullUri){ //on 17/04/23
            // 特別なPATH
            // documentになければ-tTournamentEntryTempを作成
            // あれば中のファイル毎dirを削除
            //なければ、作成
            //temp.txtでデータをfile化
            // upload
            // directoryを削除
            string retMes = "";

            string myDocumentPath=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string tempDir = string.Format("{0}\\{1}", myDocumentPath, "_tTournamentEntryTemp");         
            if (Directory.Exists(tempDir)){
                Directory.Delete(tempDir, true);
            }
            DirectoryInfo di =Directory.CreateDirectory(tempDir);
            //書き込むファイルが既に存在している場合は、上書きする
            string writeFileName = string.Format("{0}\\{1}", tempDir, "temp.txt");
            StreamWriter sw = new StreamWriter( writeFileName, false, Encoding.GetEncoding("UTF-8"));
            sw.Write(sendStr);
            sw.Close();
            // send
            // on 17/04/23 数回目でエラーが発生した。550。
            // アドレスの後のスラッシュを２つにすることで接続できるようになった
            // on 17/05/18 Directに記載
            try {
                newFtpServerClass ftpServer = new newFtpServerClass();
                WebClient wc = new WebClient();
                wc.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
                //fullUri = "ftp://www.ofunabc.jp//entrySystemOfunaDB/temp/";
 
                // ログインユーザー名とパスワードを指定
                wc.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
                // FTPサーバーへアップロードする
                //wc.UploadFile("ftp://211.13.204.12//www.ofunabc.jp/entrySystemOfunaDB/temp/"+fileName, writeFileName);
				//fullUri = "ftp://153.127.49.160/tTournamentEntry/temp/";
				wc.UploadFile(fullUri + fileName, writeFileName);
				retMes += string.Format("{0}をアップロード", fullUri + fileName) + Environment.NewLine;
            }
            catch{
                Directory.Delete(tempDir, true);
                retMes += "サーバーとの接続に問題が発生しました";
                return retMes;
            }
            Directory.Delete(tempDir, true);
            return retMes;
        }

		public static NetworkCredential getFtpCredential() {
			newFtpServerClass aftp = new newFtpServerClass();
			return ftpUploadClass.getFtpCredential(aftp.FtpAccount, aftp.FtpUserPassword);
		}

		public static NetworkCredential getFtpCredential(string loginName, string password) {
			return new NetworkCredential(loginName, password);
		}

				
		public static string downLoadStringFromWebFile(string fileFullUri) { // on 10/03/23 元に戻した
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(fileFullUri));
			//ログインユーザー名とパスワードを設定
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.DownloadFile;

			ftpReq.KeepAlive = false;  //要求の完了後に接続を閉じる
			ftpReq.UseBinary = false;  //ASCIIモードで転送する
			ftpReq.UsePassive = false; //PASVモードを無効にする

			try {
				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
				Stream readFs = ftpRes.GetResponseStream();　//ファイルをダウンロードするためのStreamを取得
				StreamReader sr = new StreamReader(readFs, Encoding.UTF8);
				string html = sr.ReadToEnd();
				readFs.Close();
				//FTPサーバーから送信されたステータスを表示
				//閉じる
				ftpRes.Close();
				return html;
			}
			catch {
				return null;
			}
			//NetworkCredential ftpCredential=  getFtpCredential();
			//WebClient wc = new WebClient();
			//wc.Credentials = ftpCredential;
			//return Encoding.UTF8.GetString(wc.DownloadData(fileFullUri));
		}
		
        public static string getFullUri() {
            newFtpServerClass fsc=new newFtpServerClass();
            return string.Format("ftp://{0}/{1}/", fsc.FptServerName, fsc.getWebTempFolder());
        }

		public static string getDataFolderFullUri(){ //on 11/08/21
			newFtpServerClass fsc = new newFtpServerClass();
			return string.Format("ftp://{0}", fsc.getWebTempFolder());		
		}
		
		public static string getEventListInitDirFullUri(){
           return string.Format("{0}/init/", getDataFolderFullUri());		
		}
		
        public static bool upLoadFileToFTP(string fileFullPath, TextBox convMessageTextBox, string uri) {
            Uri u = new Uri(uri + Path.GetFileName(fileFullPath));             //アップロード先のURI
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
            //ログインユーザー名とパスワードを設定
            setCredetials(ftpReq);
            //MethodにWebRequestMethods.Ftp.UploadFile("STOR")を設定
            ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

            ftpReq.KeepAlive = false;  //要求の完了後に接続を閉じる
            ftpReq.UseBinary = false;  //ASCIIモードで転送する
            ftpReq.UsePassive = false; //PASVモードを無効にする

            //ファイルをアップロードするためのStreamを取得
            try {
                Stream reqStrm = ftpReq.GetRequestStream();
                convMessageTextBox.Text += string.Format("{0}にアップロード", uri) + Environment.NewLine;
                ////アップロードするファイルを開く
                FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
                ////アップロードStreamに書き込む
                byte[] buffer = new byte[1024];
                while (true) {
                    int readSize = fs.Read(buffer, 0, buffer.Length);
                    if (readSize == 0)
                        break;
                    reqStrm.Write(buffer, 0, readSize);
                }
                fs.Close();
                reqStrm.Close();

                FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponseを取得
                //FTPサーバーから送信されたステータスを表示
                convMessageTextBox.Text += ftpRes.StatusDescription + Environment.NewLine;
                //閉じる
                ftpRes.Close();
                return true;
            }
            catch {
                convMessageTextBox.Text += "サーバーとの接続に問題が発生しました" + Environment.NewLine;
                return false;
            }
        }

		public static bool upLoadFileToFTP(string fileFullPath, string uri) {
			Uri u = new Uri(uri + Path.GetFileName(fileFullPath));             //アップロード先のURI
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
			//ログインユーザー名とパスワードを設定
			setCredetials(ftpReq);
			//MethodにWebRequestMethods.Ftp.UploadFile("STOR")を設定
			ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

			ftpReq.KeepAlive = false;  //要求の完了後に接続を閉じる
			ftpReq.UseBinary = false;  //ASCIIモードで転送する
			ftpReq.UsePassive = false; //PASVモードを無効にする

			//ファイルをアップロードするためのStreamを取得
			try {
				Stream reqStrm = ftpReq.GetRequestStream();
				////アップロードするファイルを開く
				FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
				////アップロードStreamに書き込む
				byte[] buffer = new byte[1024];
				while (true) {
					int readSize = fs.Read(buffer, 0, buffer.Length);
					if (readSize == 0)
						break;
					reqStrm.Write(buffer, 0, readSize);
				}
				fs.Close();
				reqStrm.Close();

				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponseを取得
				//FTPサーバーから送信されたステータスを表示
				//閉じる
				ftpRes.Close();
				return true;
			}
			catch {
				return false;
			}
		}
		
        private static void setCredetials(FtpWebRequest ftpReq) {
			newFtpServerClass ftpServer = new newFtpServerClass();
            ftpReq.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
            //ftpReq.Credentials = new NetworkCredential("ftp.ofunabc.jp","Darkrope81667");
        }

        /// <summary>
        /// FTPサーバーにディレクトリを作成する
        /// </summary>
        public static void makeDirectoryOnFtpServer(string directory) {
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(directory));
            ftpReq.KeepAlive=false;
            //ログインユーザー名とパスワードを設定
            setCredetials(ftpReq);
            ftpReq.Method = WebRequestMethods.Ftp.MakeDirectory;
			//try {
				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
			//}
			//catch (WebException e) {
			//    FtpWebResponse res = (FtpWebResponse)e.Response;
			//    Console.WriteLine(res.StatusDescription); 
			//    //Console.WriteLine(e.Message);
			//} 
//            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //閉じる
            ftpRes.Close();
        }

        /// <summary>
        /// 指定されたフォルダにあるファイルを削除する
        /// </summary>
        public static void deleteFileOnFtpServer(string fileName) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(newFtpServerClass.getWebRootDirectory() + fileName));
            //ログインユーザー名とパスワードを設定					  
            setCredetials(ftpReq);
            //MethodにWebRequestMethods.Ftp.DeleteFile(DELE)を設定
            ftpReq.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //閉じる
            ftpRes.Close();
        }

        /// <summary>
        /// インターネットに接続されているか on 12/12/30変更
        /// </summary>
        /// <returns>接続されているときはtrue</returns>
        public static bool IsInternetConnected() {
			return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// FtpServer上のファイル一覧を取得し、GenericListに返す。Dirは"<DIR>"を含む
        /// </summary>
        public static List<string> getAllFilesOfFtpServer() {
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create( new Uri(new newFtpServerClass().FptServerName) );
            setCredetials(ftpReq);

            //MethodにWebRequestMethods.Ftp.ListDirectoryDetails("LIST")を設定
            ftpReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            ftpReq.KeepAlive = false; //要求の完了後に接続を閉じる
            ftpReq.UsePassive = false; //PASSIVEモードを無効にする

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //FTPサーバーから送信されたデータを取得
            StreamReader reader = new StreamReader(ftpRes.GetResponseStream());
            List<string> filesList = new List<string>();
            string s = null;
            do {
                s = reader.ReadLine();
                if (s != null) {
                    if (s.StartsWith("d")) {
                        filesList.Add(s.Substring(s.LastIndexOf(" ") + 1) + " " + "<DIR>");
                    }
                    else {
                        filesList.Add(s.Substring(s.LastIndexOf(" ") + 1));
                    }
                }
            } while ((s != null));
            ftpRes.Close();
            return filesList;
        }

        /// <summary>
        /// FtpServer上のDirectory一覧を取得し、GenericListに返す
        /// </summary>
        public static List<string> getAllDirectoriesOfFtpServer(string dirName) {
            //ファイル一覧を取得するディレクトリのURI
			newFtpServerClass aftp = new newFtpServerClass();
            Uri u = new Uri("ftp://" + aftp.FptServerName + dirName + "/"); // on 10/01/31
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
            setCredetials(ftpReq);

            //MethodにWebRequestMethods.Ftp.ListDirectoryDetails("LIST")を設定
            ftpReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            ftpReq.KeepAlive = false; //要求の完了後に接続を閉じる
            ftpReq.UsePassive = false; //PASSIVEモードを無効にする

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //FTPサーバーから送信されたデータを取得
            StreamReader reader = new StreamReader(ftpRes.GetResponseStream());
            List<string> filesList = new List<string>();
            string s = null;
            do {
                s = reader.ReadLine();
                if (s != null) {
                    if (s.StartsWith("d")) {
                        filesList.Add(s.Substring(s.LastIndexOf(" ") + 1));
                    }
                }
            } while ((s != null));
            ftpRes.Close();
            return filesList;
        }

        public static bool existDirOnWebServer(string targetDir, string arg) {
            return getAllDirectoriesOfFtpServer(targetDir).Any(dir=> (dir == arg)); // no debug
        }

		/// FTPサーバーからFolder一覧を取得する
		/// </summary>
		/// <param name="dirUri">ディレクトリのURI</param>
		/// <returns>ディレクトリ名の一覧</returns>
		public static List<string> GetFtpDirectoryOnlyList(string fullFileUri) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(fullFileUri));
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.ListDirectory;
			ftpReq.UsePassive = false;
			ftpReq.KeepAlive=false;	   // on 11/10/18
			
			List<string> dirList = new List<string>();
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse())
			using (StreamReader sr = new StreamReader(ftpRes.GetResponseStream())) {
				while (true) {
					string line = sr.ReadLine();
					if (line == null)
						break;
					dirList.Add(line);
				}
			}
			//.と..のdirは削除する
			return dirList.Where( s=> (!s.EndsWith(".") && !s.Contains("."))).ToList(); //ここの部分だけが違う
		}

		/// <summary>
		/// FTPサーバーのファイルを削除する
		/// </summary>
		/// <param name="fileUri">削除するファイルのURI</param>
		public static void DeleteFtpFile(string fileUri) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(fileUri);
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.DeleteFile;
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse()) {
			}
		}

		/// FTPサーバーからファイル一覧を取得する
		/// </summary>
		/// <param name="dirUri">ディレクトリのURI</param>
		/// <returns>ファイル、ディレクトリ名の一覧</returns>
		public static List<string> GetFtpDirectoryList(string fullFileUri) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(fullFileUri));
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.ListDirectory;
			ftpReq.UsePassive = false;

			List<string> dirList = new List<string>();
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse())
			using (StreamReader sr = new StreamReader(ftpRes.GetResponseStream())) {
				while (true) {
					string line = sr.ReadLine();
					if (line == null)
						break;
					dirList.Add(line);
				}
			}
			//.と..のdirは削除する
			return dirList.Where(s=> !s.EndsWith(".")).ToList();
		}
		
		public static void DelteFtpFolder(string fullDirPath){
			List<string> aFilesList = GetFtpDirectoryList(fullDirPath);
			// fileを削除
			aFilesList.ForEach(delegate(string fileName){
				//string s = fileName.Split('/')[1];
				DeleteFtpFile(fullDirPath + "/" + fileName);
			});
			// directoryを削除	
			deleteFtpDirectory(fullDirPath);
		}
		
		public static void deleteFtpDirectory(string fullDirPath){
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(fullDirPath);
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.RemoveDirectory;
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse()) {
			}		
		}
    }
}
