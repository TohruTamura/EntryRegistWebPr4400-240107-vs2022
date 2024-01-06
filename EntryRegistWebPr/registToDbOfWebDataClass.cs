using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Data;

// on 22/08/31 編集
namespace EntryRegistWebPr {
	class registToDbOfWebDataClass {
		public static string RegistToDbOfWebEntryList() {
			string mes = "";
			int count = 0;
			List<WebEntryClass> webList = WebEntryClass.getWebEntryList();
			if (webList != null) {
				progressFrm dlg = getProgressDialog(webList.Count);
				dlg.Show();

				for (int j = 0; j < webList.Count; j++) {
					dlg.Update();
					dlg.progressBar1.Value = j;
					string result = "";
					count += RegistingToDbOfEachWebEntry(ref result, webList[j], j);
					mes += result + Environment.NewLine;
					dlg.resultTextBox.Text = result;
					dlg.resultTextBox.Update();
				}
				dlg.Close();
				if (count != 0) {
					return mes + string.Format("WEB上のデータ{0}件を登録しました" + Environment.NewLine, count);
				}
				else {
					return mes;
				}
			}
			else {
				return "WEB上にデータはありませんでした" + Environment.NewLine;
			}
		}

		private static progressFrm getProgressDialog(int webEntryCount) {
			progressFrm dlg = new progressFrm();
			dlg.numsTextBox.Text = string.Format("{0}件", webEntryCount);
			dlg.progressBar1.Minimum = 0;
			dlg.progressBar1.Maximum = webEntryCount;
			dlg.progressBar1.Value = 0;
			return dlg;
		}

		// 保存されたら1を返す
		private static int RegistingToDbOfEachWebEntry(ref string result, WebEntryClass aWebEntry,int index) {
			if (!isRegisted(aWebEntry)) {
				bool flag = doRegist(index, aWebEntry, ref result);
				if (flag) {
					//mailTableにデータを保存する
					// on 22/09/03 mail Registはコメント化しない
					var dummy= registToDbOfMailAddress(aWebEntry);
					setFalseOfEachWebEntryFlag(aWebEntry);
					return 1;
				}
				else {
					result = "";
					return 0;
				}
			}
			else {
				setFalseOfEachWebEntryFlag(aWebEntry);
				result= getRegistedErrorMessage(index, aWebEntry);
				return 0;
			}
		}
		private static string registToDbOfMailAddress(WebEntryClass aWebEntryC){
			string mes="";
			int jcblNumber=etcClass.objToInt(aWebEntryC.jcbl[0]);
			string sql=string.Format(
				"SELECT COUNT(*) FROM mailTable WHERE JcblNumber={0}",
				jcblNumber
			);
			int n=MicrosoftAccessClass.getTableDataNums(sql,EntryMdbClass.getIMP_SumConnectStr(new entryFileClass().FileFullPath));
			if (n==0){
				string errorMes=MicrosoftAccessClass.executeSQL(getMailAddressInsertSql(aWebEntryC), EntryMdbClass.getIMP_SumConnectStr(new entryFileClass().FileFullPath));
				if (string.IsNullOrEmpty(errorMes)){
					mes=string.Format("{0} {1}のメールアドレスを登録"+Environment.NewLine,jcblNumber,aWebEntryC.name[0]);	
				}
			}
			return mes;
			// このmesは使用していない
		}

		private static string getMailAddressInsertSql(WebEntryClass aWebEntryC) {
			string sql = "INSERT INTO mailTable (jcblNumber,personName,mailAddress) VALUES ({0},'{1}','{2}')";
			return string.Format(
				sql, 
				etcClass.objToInt(aWebEntryC.jcbl[0]), 
				aWebEntryC.name[0], 
				aWebEntryC.mailAddress
			);
		}
		
		private static string getRegistedErrorMessage(int pos,WebEntryClass aWebEntryC){
			return string.Format(
				"{0}: id={1} {2} {3} {4} {5}は既に受付データベースに登録されています。"+Environment.NewLine,
				(pos + 1).ToString(),
				aWebEntryC.id.ToString(),
				aWebEntryC.eventDate,
				aWebEntryC.eventName,
				aWebEntryC.jcbl[0],
				aWebEntryC.name[0]
			);		
		}
		
		private static void setFalseOfEachWebEntryFlag(WebEntryClass aWebEntryC) {
			NameValueCollection post = new NameValueCollection();
			post.Add("eventId", aWebEntryC.id.ToString());
			post.Add("jcblNumber", aWebEntryC.jcbl[0].ToString());
            string result = postOFHttpClass.getPhpResultMultiParamWithoutPasswordParam(post, "setFalseOfEachWebEntryFlag.php");
		}

		// on 12/07/10 全ての名前をチェックするように変更
		// on 13/02/27 会員番号が0でないメンバーをチェック
		// on 22/08/31 (Cancel=FALSE)を追加。cancelFlagのついているデータを除くため
		private static bool isRegisted(WebEntryClass aClass) {
			for (int j = 0; j < aClass.jcbl.Count; j++) {
				if (aClass.jcbl[j]!="0"){
					// on 22/08/31　AND (Cancel=FALSE)
					string sql = string.Format(
						"SELECT COUNT(*) FROM Team WHERE Event={0} AND (Cancel=FALSE) AND ( (Team.[1Number]={2} AND Team.[1Name]='{1}') OR (Team.[2Number]={2} AND Team.[2Name]='{1}') OR (Team.[3Number]={2} AND Team.[3Name]='{1}') OR (Team.[4Number]={2} AND Team.[4Name]='{1}') OR (Team.[5Number]={2} AND Team.[5Name]='{1}') OR (Team.[6Number]={2} AND Team.[6Name]='{1}') ) ", 
						aClass.id, 
						aClass.name[j], 
						aClass.jcbl[j]
					);
					if (MicrosoftAccessClass.getTableDataNums(sql, EntryMdbClass.getIMP_SumConnectStr(new entryFileClass().FileFullPath)) > 0) {
						return true;
					}
				}
			}
			return false;
		}

		//登録された場合はtrueを返す
		private static bool doRegist(int pos,WebEntryClass aWebC,ref string result) {  //一部改変
			string sql = getInsertSqlOfEntryTableByWebEntry(aWebC);
			// on 22/09/02
			string errorMes = MicrosoftAccessClass.executeSQL(
				sql, 
				EntryMdbClass.getIMP_SumConnectStr(new entryFileClass().FileFullPath)
			);
			if (errorMes == "") {
				result = getWevEntryMessage(pos, aWebC);
				return true;
			}
			else {
				result = errorMes;
				return false;
			}
		}

		private static string getWevEntryMessage(int pos, WebEntryClass aWebEntryC) {
			return string.Format(
				"{0}: id={1} {2} {3} {4} {5} {6}を登録",
				(pos + 1).ToString(),
				aWebEntryC.id.ToString(),
				aWebEntryC.eventDate,
				aWebEntryC.eventName,
				aWebEntryC.eNo,
				aWebEntryC.jcbl[0],
				aWebEntryC.name[0]
			);
		}
		private static string getInsertSqlOfEntryTableByWebEntry(WebEntryClass aWebEntryC) { // on 10/07/08
			return getInsertSqlSub(getRegistClassFromWebEntryClass(aWebEntryC));
		}

		private static registTeamClass getRegistClassFromWebEntryClass(WebEntryClass aWebEntryC) {
			registTeamClass aRegistTeamC = new registTeamClass(){
				EventId = aWebEntryC.id,
				EntryNo = getMaxEntryNumber(aWebEntryC.id) + 1, // on 12/08/01 このままでいい
				PostNumber = (aWebEntryC.zipCode == "") ? "NULL" : myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.zipCode),
				Address = (aWebEntryC.address == "") ? "NULL" : myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.address),
				TelNumber = (aWebEntryC.telNumber == "") ? "NULL" : myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.telNumber),
				MailAddress = (aWebEntryC.mailAddress == "") ? "NULL" : myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.mailAddress)
			};
			
			for(int j=0;j<aWebEntryC.jcbl.Count;j++){
				if (aWebEntryC.jcbl[j]!=null){
					aWebEntryC.sexes[j] = getSexOfPerson(aWebEntryC.jcbl[j]);
				} 
			}
			
			for (int j = 0; j < aWebEntryC.jcbl.Count; j++) {
				aRegistTeamC.JcblNumberList[j] = myConvClass.getDataBaseIntValContainDBNullValue(aWebEntryC.jcbl[j]);
				aRegistTeamC.SpList[j] = myConvClass.getDataBaseIntValContainDBNullValue(aWebEntryC.eachSps[j]);
				aRegistTeamC.BpList[j] = myConvClass.getDataBaseIntValContainDBNullValue(aWebEntryC.bps[j]);
				aRegistTeamC.SexList[j] = myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.sexes[j]);
			}

			for (int j = 0; j < aWebEntryC.name.Count; j++) {	 // on 13/02/27 この部分を分離
				aRegistTeamC.PersonNameList[j] = myConvClass.getDataBaseStrValContainDBNullValue(aWebEntryC.name[j]);
			}
			aRegistTeamC.RegistDate = aWebEntryC.webRegistDate;
			return aRegistTeamC;
		}
		
		private static string getSexOfPerson(string jcblNo){
			string sql = "SELECT 性別 FROM JCBLMEM WHERE 会員番号=" + jcblNo;
			DataTable dt = EntryMdbClass.getDataTable(sql, (new entryFileClass().FileFullPath));
			List<DataRow> aList = etcClass.getDataTableRowsList(dt);
			//見つからない時はMに
			return  (aList.Count==0)?  "M" : etcClass.objToStr(aList[0].ItemArray[0]);
		}
		
		/// <summary>
		/// eventIdの最大のentryNumberを取得する
		/// </summary>
		/// <param name="eventId"></param>
		/// <returns></returns>
		private static int getMaxEntryNumber(int eventId) {
			string sql = "SELECT 受付番号 FROM Team WHERE Event=" + eventId;
			DataTable dt = EntryMdbClass.getDataTable(sql, (new entryFileClass().FileFullPath));
			List<DataRow> aList = etcClass.getDataTableRowsList(dt);
			if (aList.Count != 0) {  // on 12/07/09
				return etcClass.getDataTableRowsList(dt).Max(val => etcClass.objToInt(val[0]));
			}
			else {
				return 0; // on 12/08/02 新競技会でデーベース保存時,受付番号が2になるバグ 1->0へ修正
			}
		}

		private static string getInsertSqlSub(registTeamClass aRegistTeamC) {
			double[] bp = new double[6] { 0, 0, 0, 0, 0, 0 };
			string[] bpStr = new string[6] { "NULL", "NULL", "NULL", "NULL", "NULL", "NULL" };
			for (int j = 0; j < 6; j++) {
				if (aRegistTeamC.BpList[j] != "NULL") {
					double d = Convert.ToDouble(aRegistTeamC.BpList[j]);
					d = d / 100;
					bp[j] = ToHalfAdjust(d, 2);
					bpStr[j] = bp[j].ToString();
				}
			}

			string sql = "INSERT INTO Team (Event,受付番号, ";
			sql += " 1Number,1Name,1MP,1SP,1Sex, ";
			sql += " 2Number,2Name,2MP,2SP,2Sex, ";
			sql += " 3Number,3Name,3MP,3SP,3Sex, ";
			sql += " 4Number,4Name,4MP,4SP,4Sex, ";
			sql += " 5Number,5Name,5MP,5SP,5Sex, ";
			sql += " 6Number,6Name,6MP,6SP,6Sex, ";
			sql += " 郵便番号,住所,TEL1,ＳＰ合計,ＭＰ合計,mailAddress,registDate) ";
			sql += " VALUES ({0},{1},";
			sql += "{2},{3},{4},{5},{6},";		//member1
			sql += "{7},{8},{9},{10},{11},";	//member2
			sql += "{12},{13},{14},{15},{16},"; //member3
			sql += "{17},{18},{19},{20},{21},"; //member4
			sql += "{22},{23},{24},{25},{26},"; //member5
			sql += "{27},{28},{29},{30},{31},"; //member6
			sql += "{32},{33},{34},{35},{36},{37},'{38}'";
			sql += ")";
			sql = string.Format(
				sql,
				aRegistTeamC.EventId.ToString(), aRegistTeamC.EntryNo.ToString(),
				aRegistTeamC.JcblNumberList[0], aRegistTeamC.PersonNameList[0], bpStr[0], aRegistTeamC.SpList[0], aRegistTeamC.SexList[0],
				aRegistTeamC.JcblNumberList[1], aRegistTeamC.PersonNameList[1], bpStr[1], aRegistTeamC.SpList[1], aRegistTeamC.SexList[1],
				aRegistTeamC.JcblNumberList[2], aRegistTeamC.PersonNameList[2], bpStr[2], aRegistTeamC.SpList[2], aRegistTeamC.SexList[2],
				aRegistTeamC.JcblNumberList[3], aRegistTeamC.PersonNameList[3], bpStr[3], aRegistTeamC.SpList[3], aRegistTeamC.SexList[3],
				aRegistTeamC.JcblNumberList[4], aRegistTeamC.PersonNameList[4], bpStr[4], aRegistTeamC.SpList[4], aRegistTeamC.SexList[4],
				aRegistTeamC.JcblNumberList[5], aRegistTeamC.PersonNameList[5], bpStr[5], aRegistTeamC.SpList[5], aRegistTeamC.SexList[5],
				aRegistTeamC.PostNumber, aRegistTeamC.Address, aRegistTeamC.TelNumber,
				aRegistTeamC.getTotalSpStr(), aRegistTeamC.getTotalBpStr(),
				aRegistTeamC.MailAddress, aRegistTeamC.RegistDate
			);
			return sql;
		}

		/// ------------------------------------------------------------------------
		/// <summary>
		///     指定した精度の数値に四捨五入します。</summary>
		/// <param name="dValue">
		///     丸め対象の倍精度浮動小数点数。</param>
		/// <param name="iDigits">
		///     戻り値の有効桁数の精度。</param>
		/// <returns>
		///     iDigits に等しい精度の数値に四捨五入された数値。</returns>
		/// ------------------------------------------------------------------------
		public static double ToHalfAdjust(double dValue, int iDigits) {
			double dCoef = Math.Pow(10, iDigits);
			return dValue > 0 ? Math.Floor((dValue * dCoef) + 0.5) / dCoef :
								Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
		}

	}
}
