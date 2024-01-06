using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntryRegistWebPr {
	class webEntryAutoSaveClass {
		private bool webEntryAutoSaveFlag;

		public bool WebEntryAutoSaveFlag {
			get { return webEntryAutoSaveFlag; }
			set { webEntryAutoSaveFlag = value; }
		}


		public webEntryAutoSaveClass() {
			readProperties();
		}

		public void readProperties() {
			this.webEntryAutoSaveFlag = Properties.webentryAutoSave.Default.webentryAutoSaveFlag;
		}

		public void writeProperties() {
			Properties.webentryAutoSave.Default.webentryAutoSaveFlag = this.webEntryAutoSaveFlag;
			Properties.webentryAutoSave.Default.Save();
		}
	}
}
