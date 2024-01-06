using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	class postOFHttpClass {
		/// <summary>
		/// POSTを送信する
		/// </summary>
		/// <param name="url">送信先URL</param>
		/// <param name="post">送信データ</param>
		/// <returns>受信データ</returns>
		public static string SendPost(string url, NameValueCollection post) {
			//POSTを送信
			using (WebClient webClient = new WebClient()) {
				//POSTしてデータを受信する
				byte[] data = webClient.UploadValues(url, post);
				return Encoding.UTF8.GetString(data);
			}
		}

        public static string getPhpResultWithoutWebPassword(string phpName){
            NameValueCollection post = new NameValueCollection();
            post.Add("password", new newFtpServerClass().WebDbPassword); //POSTデータを追加   
            string url = new newFtpServerClass().getWebPhpUrl(phpName);
            return postOFHttpClass.SendPost(url, post);	//
        }

        public static string getPhpResultMultiParamWithoutPasswordParam(NameValueCollection param, string phpName){
            param.Add("password", new newFtpServerClass().WebDbPassword); //POSTデータを追加   
            string url = new newFtpServerClass().getWebPhpUrl(phpName);
            return postOFHttpClass.SendPost(url, param);	//
        }
	}
}
