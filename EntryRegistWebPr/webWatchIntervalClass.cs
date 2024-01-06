
namespace EntryRegistWebPr {
	class webWatchIntervalClass {
		private int watchInterval;

		public int WatchInterval{
			get { return watchInterval; }
			set { watchInterval = value; }
		}


		public webWatchIntervalClass() {
            readProperties();
        }

        public void readProperties() {
            this.watchInterval = Properties.webWatchInterval.Default.interval;
        }

        public void writeProperties() {
			Properties.webWatchInterval.Default.interval=this.watchInterval;
			Properties.webWatchInterval.Default.Save();
        }
	}
}
