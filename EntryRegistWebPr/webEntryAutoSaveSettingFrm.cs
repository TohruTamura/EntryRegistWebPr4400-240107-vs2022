using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	public partial class webEntryAutoSaveSettingFrm : Form {
		public webEntryAutoSaveSettingFrm() {
			InitializeComponent();
		}

		private void webEntryAutoSaveSettingFrm_Load(object sender, EventArgs e) {
			webEntryAutoSaveClass aClass = new webEntryAutoSaveClass();
			checkBox1.Checked = aClass.WebEntryAutoSaveFlag;
		}

		private void cancelBtn_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void saveBtn_Click(object sender, EventArgs e) {
			webEntryAutoSaveClass aClass = new webEntryAutoSaveClass();
			aClass.WebEntryAutoSaveFlag =checkBox1.Checked;
			aClass.writeProperties();
			MessageBox.Show("保存されました。次回起動時から反映されます。");
			this.Close();
		}

	}
}
