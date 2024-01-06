
namespace EntryRegistWebPr{
    
    class installClass{
        private bool installFlag;

        public bool InstallFlag {
            get { return installFlag; }
            set { installFlag = value; }
        }

        public installClass(){
            readProperties();
        }

        public void readProperties() {
            this.installFlag = Properties.install.Default.installFlag;
        }

        public void writeProperties() {
            Properties.install.Default.installFlag = this.installFlag;
            Properties.install.Default.Save();
        }

    }
}
