using System;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	public partial class webWatchIntervalFrm : Form {
		public webWatchIntervalFrm() {
			InitializeComponent();
		}

		private void webWatchIntervalFrm_Load(object sender, EventArgs e) {
			webWatchIntervalClass aClass = new webWatchIntervalClass();
			intervalNumericUpDown.Value = aClass.WatchInterval;
		}

		private void CancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void OkBtn_Click(object sender, EventArgs e) {
			webWatchIntervalClass aClass = new webWatchIntervalClass();
			aClass.WatchInterval = (int)intervalNumericUpDown.Value;
			aClass.writeProperties();
			this.Close();
		}
	}
}
