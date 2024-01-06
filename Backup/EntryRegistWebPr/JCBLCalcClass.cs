
namespace EntryRegistWebPr {
    class JCBLCalcClass {
        public const int MAX_MEMBERS = 6;

        public const int SENIOR_DISCOUNT_FEE = 500;

        public static bool isProperJCBLNumber(int jcblNumber) {
            if (jcblNumber == 0) {
                return false;
            }
            if (jcblNumber.ToString().Length > 6) { //6åÖà»ì‡Ç≈Ç†ÇÈÇ±Ç∆ on 08/07/22
                return false;
            }
            return CheckDigit(jcblNumber);
        }

        public static string getFlightName(int section) {
            string s = "ABCDEFGHI";
            return s.Substring(section, 1);
        }

        //åÖêîÇÃÇ†Ç”ÇÍÇ…íçà”
        public static bool CheckDigit(int num) {
            int[] cd = new int[6] { 0, 7, 9, 3, 1, 7 };
            int[] n = new int[6] { 0, 0, 0, 0, 0, 0 };
            int temp = num / 10;
            string s = temp.ToString();
            for (int j = 1; j <= s.Length; j++) {
                n[j] = temp % 10;
                temp = temp / 10;
            }
            temp = 0;
            for (int j = 1; j <= 5; j++) {
                temp += n[j] * cd[j];
            }
            return ((num % 10) == (temp % 10));
        }

    }
}
