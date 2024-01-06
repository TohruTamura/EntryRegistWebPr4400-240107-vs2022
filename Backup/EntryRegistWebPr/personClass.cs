
namespace EntryRegistWebPr {
    public class personClass {

        const string MALE = "Male";
        const string FEMALE = "Female";

        private int jcblNumber;
        private string personName;
        private string hurigana;
        private string sex;
        private bool seniorFlag;
        private string postNumber;
        private string state;
        private string address;
        private string homeTelNumber;
        private string fax;
        private string mailAddress;
        private int sp;
        private int bp; //100î{Ç≥ÇÍÇƒÇ¢ÇÈ
        private string honor; //DataBaseè„Ç≈ÇÕmaster

        public string Honor {
            get { return honor; }
            set { honor = value; }
        }


        public int Sp {
            get { return sp; }
            set { sp = value; }
        }

        public int Bp {
            get { return bp; }
            set { bp = value; }
        }


        public bool SeniorFlag {
            get { return seniorFlag; }
            set { seniorFlag = value; }
        }

        public int JcblNumber {
            get { return jcblNumber; }
            set { jcblNumber = value; }
        }

        public string PersonName {
            get { return personName; }
            set { personName = value; }
        }

        public string Hurigana {
            get { return hurigana; }
            set { hurigana = value; }
        }

        public string Sex {
            get { return sex; }
            set { sex = value; }
        }

        public string PostNumber {
            get { return postNumber; }
            set { postNumber = value; }
        }

        public string State {
            get { return state; }
            set { state = value; }
        }

        public string Address {
            get { return address; }
            set { address = value; }
        }

        public string HomeTelNumber {
            get { return homeTelNumber; }
            set { homeTelNumber = value; }
        }

        public string Fax {
            get { return fax; }
            set { fax = value; }
        }

        public string MailAddress {
            get { return mailAddress; }
            set { mailAddress = value; }
        }

        public personClass() {
            jcblNumber = 0;
            personName = null;
            hurigana = null;
            sex = null;
            seniorFlag = false;
            postNumber = null;
            state = null;
            address = null;
            homeTelNumber = null;
            fax = null;
            mailAddress = null;
            sp = 0;
            bp = 0;
            honor = null;
        }

        public  string getSexStr(){
            return (sex == "F") ? FEMALE : MALE;
        }
    }
}

