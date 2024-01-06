using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EntryRegistWebPr {
	public partial class splushFrm : Form {
		public splushFrm() {
			InitializeComponent();
		}

		private void splushFrm_Load(object sender, EventArgs e) {
			var assembly = Assembly.GetExecutingAssembly();
			var assemblyName = assembly.GetName();
			var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			label1.Text= fileVersionInfo.ProductName;
			string s= String.Format("ver. {0}  {1}", assemblyName.Version,fileVersionInfo.LegalCopyright);
			versionLabel.Text = s;

		}
	}
}
