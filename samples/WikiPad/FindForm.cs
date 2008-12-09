using System.Windows.Forms;

namespace WikiPad {
    public partial class FindForm : Form {
        private readonly MainForm _mainForm;

        public FindForm(MainForm mainForm) {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void _findButton_Click(object sender, System.EventArgs e) {
            _mainForm.Find(_findTextBox.Text);
        }
    }
}
