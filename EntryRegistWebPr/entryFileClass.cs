
namespace EntryRegistWebPr {
	class entryFileClass {
	    private string fileFullPath;

        public string FileFullPath {
            get { return fileFullPath; }
            set { fileFullPath = value; }
        }

		public entryFileClass() {
            readProperties();
        }

		public entryFileClass(string aFilePath){
			this.fileFullPath=aFilePath;
		}
		
        public void readProperties() {
			this.fileFullPath = Properties.access.Default.fileFullPath;
        }

        public void writeProperties() {
			Properties.access.Default.fileFullPath = this.fileFullPath;
			Properties.access.Default.Save();
        }
	}
}
