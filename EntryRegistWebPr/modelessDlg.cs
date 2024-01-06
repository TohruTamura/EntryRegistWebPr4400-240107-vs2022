using System.Windows.Forms;

namespace EntryRegistWebPr {
	public partial class modelessDlg : Form {
		public modelessDlg(string s) {
			InitializeComponent();
			label2.Text=s;
		}
	}
}
