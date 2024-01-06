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
		/// �ėp���Ȃ� on 11/08/21
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="newFileName"></param>
		/// <returns></returns>
		public static bool RenameOfEventListInitFtpFile(string fileName, string newFileName) {
			return RenameOfFtpFile(fileName,newFileName,getEventListInitDirFullUri());
		}
					
		public static bool RenameOfFtpFile(string fileName,string newFileName,string fullUri){
			//���O��ύX����t�@�C����URI
			Uri u = new Uri(fullUri+ fileName);
			//FtpWebRequest�̍쐬
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
			//���O�C�����[�U�[���ƃp�X���[�h��ݒ�
			ftpReq.Credentials = getFtpCredential();
			//Method��WebRequestMethods.Ftp.Rename(RENAME)��ݒ�
            try {
				ftpReq.Method = WebRequestMethods.Ftp.Rename;
				//�ύX��̐V�����t�@�C������ݒ�
				ftpReq.RenameTo = newFileName;
				//FtpWebResponse���擾
				FtpWebResponse ftpRes =(FtpWebResponse)ftpReq.GetResponse();
				//����
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
            //InterNet�ڑ��m�F
            if (!ftpUploadClass.IsInternetConnected()) {
                return "�C���^�[�l�b�g�ɐڑ��ł��܂���B�ڑ����m�F���Ă�������";
            }
            return "";
        }

		/// <summary>
		/// FTP�T�[�o�[��Dir���쐬����
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
			newSetCredetials(ftpReq, ftpServer);  //���O�C�����[�U�[���ƃp�X���[�h��ݒ�
			ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

			ftpReq.KeepAlive = false;  //�v���̊�����ɐڑ������
			ftpReq.UseBinary = false;  //ASCII���[�h�œ]������
			ftpReq.UsePassive = false; //PASV���[�h�𖳌��ɂ���

			byte[] postDataBytes = Encoding.UTF8.GetBytes(sendStr);
			try {
				Stream reqStrm = ftpReq.GetRequestStream();
				reqStrm.Write(postDataBytes, 0, postDataBytes.Length);
				reqStrm.Close();

				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponse���擾
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

		// EventList��EntryList���A�b�v���[�h���邽�߂�
		public static string uploadDispDataString(string fileName, string sendStr) { // on 11/08/20
			return uploadString(fileName, sendStr, getDataFolderFullUri());
		}

		// EventList��EntryList���A�b�v���[�h���邽�߂�
		public static string uploadDispInitDataString(string fileName, string sendStr) { // on 11/08/20
			return uploadString(fileName,sendStr,getEventListInitDirFullUri());
		}
							
        public static string uploadString(string fileName,string sendStr, string fullUri){ //on 17/04/23
            // ���ʂ�PATH
            // document�ɂȂ����-tTournamentEntryTemp���쐬
            // ����Β��̃t�@�C����dir���폜
            //�Ȃ���΁A�쐬
            //temp.txt�Ńf�[�^��file��
            // upload
            // directory���폜
            string retMes = "";

            string myDocumentPath=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string tempDir = string.Format("{0}\\{1}", myDocumentPath, "_tTournamentEntryTemp");         
            if (Directory.Exists(tempDir)){
                Directory.Delete(tempDir, true);
            }
            DirectoryInfo di =Directory.CreateDirectory(tempDir);
            //�������ރt�@�C�������ɑ��݂��Ă���ꍇ�́A�㏑������
            string writeFileName = string.Format("{0}\\{1}", tempDir, "temp.txt");
            StreamWriter sw = new StreamWriter( writeFileName, false, Encoding.GetEncoding("UTF-8"));
            sw.Write(sendStr);
            sw.Close();
            // send
            // on 17/04/23 ����ڂŃG���[�����������B550�B
            // �A�h���X�̌�̃X���b�V�����Q�ɂ��邱�ƂŐڑ��ł���悤�ɂȂ���
            // on 17/05/18 Direct�ɋL��
            try {
                newFtpServerClass ftpServer = new newFtpServerClass();
                WebClient wc = new WebClient();
                wc.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
                //fullUri = "ftp://www.ofunabc.jp//entrySystemOfunaDB/temp/";
 
                // ���O�C�����[�U�[���ƃp�X���[�h���w��
                wc.Credentials = new NetworkCredential(ftpServer.FtpAccount, ftpServer.FtpUserPassword);
                // FTP�T�[�o�[�փA�b�v���[�h����
                //wc.UploadFile("ftp://211.13.204.12//www.ofunabc.jp/entrySystemOfunaDB/temp/"+fileName, writeFileName);
				//fullUri = "ftp://153.127.49.160/tTournamentEntry/temp/";
				wc.UploadFile(fullUri + fileName, writeFileName);
				retMes += string.Format("{0}���A�b�v���[�h", fullUri + fileName) + Environment.NewLine;
            }
            catch{
                Directory.Delete(tempDir, true);
                retMes += "�T�[�o�[�Ƃ̐ڑ��ɖ�肪�������܂���";
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

				
		public static string downLoadStringFromWebFile(string fileFullUri) { // on 10/03/23 ���ɖ߂���
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(fileFullUri));
			//���O�C�����[�U�[���ƃp�X���[�h��ݒ�
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.DownloadFile;

			ftpReq.KeepAlive = false;  //�v���̊�����ɐڑ������
			ftpReq.UseBinary = false;  //ASCII���[�h�œ]������
			ftpReq.UsePassive = false; //PASV���[�h�𖳌��ɂ���

			try {
				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
				Stream readFs = ftpRes.GetResponseStream();�@//�t�@�C�����_�E�����[�h���邽�߂�Stream���擾
				StreamReader sr = new StreamReader(readFs, Encoding.UTF8);
				string html = sr.ReadToEnd();
				readFs.Close();
				//FTP�T�[�o�[���瑗�M���ꂽ�X�e�[�^�X��\��
				//����
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
            Uri u = new Uri(uri + Path.GetFileName(fileFullPath));             //�A�b�v���[�h���URI
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
            //���O�C�����[�U�[���ƃp�X���[�h��ݒ�
            setCredetials(ftpReq);
            //Method��WebRequestMethods.Ftp.UploadFile("STOR")��ݒ�
            ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

            ftpReq.KeepAlive = false;  //�v���̊�����ɐڑ������
            ftpReq.UseBinary = false;  //ASCII���[�h�œ]������
            ftpReq.UsePassive = false; //PASV���[�h�𖳌��ɂ���

            //�t�@�C�����A�b�v���[�h���邽�߂�Stream���擾
            try {
                Stream reqStrm = ftpReq.GetRequestStream();
                convMessageTextBox.Text += string.Format("{0}�ɃA�b�v���[�h", uri) + Environment.NewLine;
                ////�A�b�v���[�h����t�@�C�����J��
                FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
                ////�A�b�v���[�hStream�ɏ�������
                byte[] buffer = new byte[1024];
                while (true) {
                    int readSize = fs.Read(buffer, 0, buffer.Length);
                    if (readSize == 0)
                        break;
                    reqStrm.Write(buffer, 0, readSize);
                }
                fs.Close();
                reqStrm.Close();

                FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponse���擾
                //FTP�T�[�o�[���瑗�M���ꂽ�X�e�[�^�X��\��
                convMessageTextBox.Text += ftpRes.StatusDescription + Environment.NewLine;
                //����
                ftpRes.Close();
                return true;
            }
            catch {
                convMessageTextBox.Text += "�T�[�o�[�Ƃ̐ڑ��ɖ�肪�������܂���" + Environment.NewLine;
                return false;
            }
        }

		public static bool upLoadFileToFTP(string fileFullPath, string uri) {
			Uri u = new Uri(uri + Path.GetFileName(fileFullPath));             //�A�b�v���[�h���URI
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
			//���O�C�����[�U�[���ƃp�X���[�h��ݒ�
			setCredetials(ftpReq);
			//Method��WebRequestMethods.Ftp.UploadFile("STOR")��ݒ�
			ftpReq.Method = WebRequestMethods.Ftp.UploadFile;

			ftpReq.KeepAlive = false;  //�v���̊�����ɐڑ������
			ftpReq.UseBinary = false;  //ASCII���[�h�œ]������
			ftpReq.UsePassive = false; //PASV���[�h�𖳌��ɂ���

			//�t�@�C�����A�b�v���[�h���邽�߂�Stream���擾
			try {
				Stream reqStrm = ftpReq.GetRequestStream();
				////�A�b�v���[�h����t�@�C�����J��
				FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
				////�A�b�v���[�hStream�ɏ�������
				byte[] buffer = new byte[1024];
				while (true) {
					int readSize = fs.Read(buffer, 0, buffer.Length);
					if (readSize == 0)
						break;
					reqStrm.Write(buffer, 0, readSize);
				}
				fs.Close();
				reqStrm.Close();

				FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();  //FtpWebResponse���擾
				//FTP�T�[�o�[���瑗�M���ꂽ�X�e�[�^�X��\��
				//����
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
        /// FTP�T�[�o�[�Ƀf�B���N�g�����쐬����
        /// </summary>
        public static void makeDirectoryOnFtpServer(string directory) {
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(directory));
            ftpReq.KeepAlive=false;
            //���O�C�����[�U�[���ƃp�X���[�h��ݒ�
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
            //����
            ftpRes.Close();
        }

        /// <summary>
        /// �w�肳�ꂽ�t�H���_�ɂ���t�@�C�����폜����
        /// </summary>
        public static void deleteFileOnFtpServer(string fileName) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(newFtpServerClass.getWebRootDirectory() + fileName));
            //���O�C�����[�U�[���ƃp�X���[�h��ݒ�					  
            setCredetials(ftpReq);
            //Method��WebRequestMethods.Ftp.DeleteFile(DELE)��ݒ�
            ftpReq.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //����
            ftpRes.Close();
        }

        /// <summary>
        /// �C���^�[�l�b�g�ɐڑ�����Ă��邩 on 12/12/30�ύX
        /// </summary>
        /// <returns>�ڑ�����Ă���Ƃ���true</returns>
        public static bool IsInternetConnected() {
			return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// FtpServer��̃t�@�C���ꗗ���擾���AGenericList�ɕԂ��BDir��"<DIR>"���܂�
        /// </summary>
        public static List<string> getAllFilesOfFtpServer() {
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create( new Uri(new newFtpServerClass().FptServerName) );
            setCredetials(ftpReq);

            //Method��WebRequestMethods.Ftp.ListDirectoryDetails("LIST")��ݒ�
            ftpReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            ftpReq.KeepAlive = false; //�v���̊�����ɐڑ������
            ftpReq.UsePassive = false; //PASSIVE���[�h�𖳌��ɂ���

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //FTP�T�[�o�[���瑗�M���ꂽ�f�[�^���擾
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
        /// FtpServer���Directory�ꗗ���擾���AGenericList�ɕԂ�
        /// </summary>
        public static List<string> getAllDirectoriesOfFtpServer(string dirName) {
            //�t�@�C���ꗗ���擾����f�B���N�g����URI
			newFtpServerClass aftp = new newFtpServerClass();
            Uri u = new Uri("ftp://" + aftp.FptServerName + dirName + "/"); // on 10/01/31
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(u);
            setCredetials(ftpReq);

            //Method��WebRequestMethods.Ftp.ListDirectoryDetails("LIST")��ݒ�
            ftpReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            ftpReq.KeepAlive = false; //�v���̊�����ɐڑ������
            ftpReq.UsePassive = false; //PASSIVE���[�h�𖳌��ɂ���

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
            //FTP�T�[�o�[���瑗�M���ꂽ�f�[�^���擾
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

		/// FTP�T�[�o�[����Folder�ꗗ���擾����
		/// </summary>
		/// <param name="dirUri">�f�B���N�g����URI</param>
		/// <returns>�f�B���N�g�����̈ꗗ</returns>
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
			//.��..��dir�͍폜����
			return dirList.Where( s=> (!s.EndsWith(".") && !s.Contains("."))).ToList(); //�����̕����������Ⴄ
		}

		/// <summary>
		/// FTP�T�[�o�[�̃t�@�C�����폜����
		/// </summary>
		/// <param name="fileUri">�폜����t�@�C����URI</param>
		public static void DeleteFtpFile(string fileUri) {
			FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(fileUri);
			ftpReq.Credentials = getFtpCredential();
			ftpReq.Method = WebRequestMethods.Ftp.DeleteFile;
			using (FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse()) {
			}
		}

		/// FTP�T�[�o�[����t�@�C���ꗗ���擾����
		/// </summary>
		/// <param name="dirUri">�f�B���N�g����URI</param>
		/// <returns>�t�@�C���A�f�B���N�g�����̈ꗗ</returns>
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
			//.��..��dir�͍폜����
			return dirList.Where(s=> !s.EndsWith(".")).ToList();
		}
		
		public static void DelteFtpFolder(string fullDirPath){
			List<string> aFilesList = GetFtpDirectoryList(fullDirPath);
			// file���폜
			aFilesList.ForEach(delegate(string fileName){
				//string s = fileName.Split('/')[1];
				DeleteFtpFile(fullDirPath + "/" + fileName);
			});
			// directory���폜	
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
