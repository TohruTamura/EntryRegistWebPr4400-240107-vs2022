using System;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace EntryRegistWebPr{
    class MicrosoftAccessClass {

        public const string ACCESS_BASE_CONNECTION = "Provider=Microsoft.jet.OLEDB.4.0;Data Source=";


        public static string executeSQL(string sql, string connectStr) {
			string error = "";
			OleDbConnection cn = new OleDbConnection(connectStr);
            cn.Open();
            try {
				new OleDbCommand(sql, cn).ExecuteNonQuery();
			}
			catch (Exception ex){
				error=ex.Message;
			}
			finally{
				cn.Close();
            }   
            return error;     
        }

        public static int getTableDataNums(string sql, string connectStr) {
            OleDbConnection sn = new OleDbConnection(connectStr);
            OleDbCommand cmd = new OleDbCommand(sql, sn);
            sn.Open();
            int n = (int)new OleDbCommand(sql, sn).ExecuteScalar();
            sn.Close();
            return n;
        }

        /// <summary>
        /// IMP_Sum‚©‚çDataTable‚ðŽæ“¾‚·‚é
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getDataTable(string sql, string connectStr) {
            DataTable dt = new DataTable();
            new OleDbDataAdapter(sql, new OleDbConnection(connectStr)).Fill(dt);
            return dt;
        }
       
        /// <summary>
        /// access DB‚©‚çtable‚Ìˆê——‚ðŽæ“¾‚·‚é
        /// </summary>
        /// <param name="connectStr"></param>
        /// <returns></returns>
        public static List<string> getTableNamesList(string connectStr){
			OleDbConnection sn = new OleDbConnection(connectStr);
			sn.Open();
			DataTable dt=sn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new Object[] {null,null,null,"Table"} );
			sn.Close();
			List<string> aList=new List<string>();
			foreach(DataRow dr in dt.Rows){
				aList.Add(dr[2].ToString());
			}	
			return aList;		
        }
        
        /// <summary>
        /// DB‚É‚ ‚étable‚ª‚ ‚é‚©
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="tableName"></param>
        /// <returns>‚ ‚ê‚Îtrue‚ð•Ô‚·</returns>
        public static bool isExistTableOnDB(string connectStr,string tableName){
			List<string> aTableList=getTableNamesList(connectStr);
			return aTableList.Any(aTableName=> aTableName==tableName);
        }
        
        /// <summary>
        /// access DB‚Ì‚ ‚éTable‚ÌField–¼‚Ìˆê——‚ðŽæ“¾‚·‚é
        /// </summary>
        /// <param name="connectStr"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> getFieldNamesList(string connectStr, string tableName){
			OleDbConnection sn = new OleDbConnection(connectStr);
			sn.Open();
			DataTable dt = sn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, tableName, null });
			sn.Close();
			List<string> aList = new List<string>();
			foreach (DataRow dr in dt.Rows) {
				aList.Add(dr[3].ToString());
			}
			return aList;		
        
        }
   
		/// <summary>
		/// ‚ ‚éTable‚Éfield‚ª‚ ‚é‚©‚Ç‚¤‚©•Ô‚·
		/// </summary>
		/// <param name="connectStr"></param>
		/// <param name="tableName"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
     
        public static bool isExistFieldOnTable(string connectStr,string tableName,string fieldName){
			List<string> aFieldList=getFieldNamesList(connectStr,tableName);
			return aFieldList.Any(aFieldName => aFieldName == fieldName);			
        }
        
    }
}
