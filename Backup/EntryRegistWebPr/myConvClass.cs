using System;

namespace EntryRegistWebPr{
    class myConvClass {
		 
        public static string getMpStr(object obj) {
            if (Convert.IsDBNull(obj) || obj.ToString() == "") {
                return "";
            }
            else {
                double d = Convert.ToDouble(obj) / 100f;
                return d.ToString("f2");
            }
        }

        public static object getTableValOfMP(string value) {
            if (value.Trim() == "") {
                return Convert.DBNull;
            }
            else {
                double d = Convert.ToDouble(value);
                d *= 100f;
                int n = (int)d;
                return n;
            }
        }

        public static object getIntObjectFromTextBox(string value) {
            return (value.Trim() == "") ? Convert.DBNull : etcClass.objToInt(value.Trim());
        }

        public static object getStrObjectFromTextBox(string value) {
            return (value.Trim() == "") ? Convert.DBNull : value.Trim();
        }

        /// <summary>
        /// DBNull�l���܂ޒl�𐔒l�t�B�[���h�ɖ߂��f�[�^�x�[�X�������Ԃ�
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string getDataBaseIntValContainDBNullValue(object obj) {
			if (obj == null) {
				return "NULL";
			}
			return Convert.IsDBNull(obj) ? "NULL" : obj.ToString();
        }

        /// <summary>
        /// DBNull�l���܂ޒl�𕶎���t�B�[���h�ɖ߂��f�[�^�x�[�X�������Ԃ�
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string getDataBaseStrValContainDBNullValue(object obj) {
            if (obj==null){
				return "NULL";
            }
            return Convert.IsDBNull(obj) ? "NULL" : "'" + obj.ToString() + "'";
        }
    }
}
