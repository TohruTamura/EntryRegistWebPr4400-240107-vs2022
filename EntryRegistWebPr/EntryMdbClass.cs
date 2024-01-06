using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace EntryRegistWebPr{
    class EntryMdbClass{
        public static DataSet getSubDataTable(string sourceFileName){
            OleDbConnection cn = new OleDbConnection(getIMP_SumConnectStr(sourceFileName));
            string sql = "SELECT * FROM imp曜日";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Weekday");
            da = new OleDbDataAdapter("SELECT * FROM imp時間", cn);
            da.Fill(ds, "Time");
            da = new OleDbDataAdapter("SELECT * FROM impクラス", cn);
            da.Fill(ds, "Class");
            da = new OleDbDataAdapter("SELECT * FROM imp試合形式", cn);
            da.Fill(ds, "試合形式");
            return ds;
        }

        public static string SelectOfSourceMDB(){ //Selectされなかったら空文字を返す
            string sourceFileName = "";
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Access files (*.mdb)|*.mdb|All files (*.*)|*.*";
            oFileDialog.FilterIndex = 1;
            oFileDialog.FileName = "受付.mdb";
            oFileDialog.Title = "受付データベースを選択してください";
            if (oFileDialog.ShowDialog() == DialogResult.OK) {
                sourceFileName = oFileDialog.FileName;
            }
            else{
                return "";
            }
            return sourceFileName;
        }

        public static string getIMP_SumConnectStr(string sourceFileName){
            return MicrosoftAccessClass.ACCESS_BASE_CONNECTION + sourceFileName;
        }

        public static int getTableDataNums(string sourceFileName, string sql){
            return MicrosoftAccessClass.getTableDataNums(sql, getIMP_SumConnectStr(sourceFileName));
        }

        /// <summary>
        /// 受付.mdbからDataTableを取得する
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getDataTable( string sql,string sourceFileName){
            return MicrosoftAccessClass.getDataTable(sql, getIMP_SumConnectStr(sourceFileName));
        }

        public static DataTable getIMPSumTeamDataTable(string sourceFileName){
            return MicrosoftAccessClass.getDataTable("SELECT * FROM ImpTeam", getIMP_SumConnectStr(sourceFileName));
        }

        public static string getNumberFieldName(int num){
            return String.Format("{0}_Number", num);
        }

        public static string getPersonNameFieldName(int num){
            return String.Format("{0}_Name", num);
        }

        public static int getLeaguesFromSourceFile(string sourceFileName){
            return getTableDataNums(sourceFileName, "SELECT count(*) FROM IMPLeague");
        }
    }
}
