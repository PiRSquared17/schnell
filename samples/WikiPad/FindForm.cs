using System;
using System.Windows.Forms;

namespace WikiPad {
    public partial class FindForm : Form {
        private readonly TextBoxBase _textBox;

        public FindForm(TextBoxBase textBox) {
            InitializeComponent();
            _textBox = textBox;
        }

        private void _findButton_Click(object sender, System.EventArgs e) {
            Find(_textBox, _searchBox.Text);
        }

        private static void Find(TextBoxBase textBox, string findString) {
            if (!textBox.Text.Contains(findString))
            {
                MessageBox.Show(String.Format("Cannot find \"{0}\"", findString), Application.ProductName);
                return;
            }
            if (textBox.SelectionStart == textBox.Text.Length) textBox.SelectionStart = 0;
            int searchPosition = textBox.SelectionStart >= 0 ? textBox.SelectionStart + textBox.SelectionLength : 0;
            searchPosition = textBox.Text.IndexOf(findString, searchPosition);
            if (searchPosition == -1)
            {
                MessageBox.Show(String.Format("No further occurences of \"{0}\" have been found", findString), Application.ProductName);
                return;
            }
            textBox.SelectionStart = searchPosition;
            textBox.SelectionLength = findString.Length;
            textBox.ScrollToCaret();
        }
    }
}
