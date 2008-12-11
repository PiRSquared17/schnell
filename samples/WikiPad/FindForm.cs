using System;
using System.Windows.Forms;

namespace WikiPad {
    public partial class FindForm : Form {
        private readonly TextBoxBase _textBox;

        public FindForm(TextBoxBase textBox) {
            InitializeComponent();
            _textBox = textBox;
        }

        private void _findButton_Click(object sender, EventArgs e) {
            Find(_textBox, _searchBox.Text, _matchCaseCheckBox.Checked, _upRadioButton.Checked);
        }

        private static void Find(TextBoxBase textBox, string findString, bool caseSensitive, bool upwards) {
            if (!textBox.Text.Contains(findString))
            {
                MessageBox.Show(String.Format("Cannot find \"{0}\"", findString), Application.ProductName);
                return;
            }

            int searchPosition;
            if (!upwards) // search downwards
            {
                if (textBox.SelectionStart == textBox.Text.Length) textBox.SelectionStart = 0;
                searchPosition = textBox.SelectionStart >= 0 ? textBox.SelectionStart + textBox.SelectionLength : 0;
                if (caseSensitive)
                    searchPosition = textBox.Text.IndexOf(findString, searchPosition, StringComparison.CurrentCulture);
                else
                    searchPosition = textBox.Text.IndexOf(findString, searchPosition,
                                                          StringComparison.CurrentCultureIgnoreCase);
                if (searchPosition == -1)
                {
                    MessageBox.Show(String.Format("No further occurences of \"{0}\" have been found", findString),
                                    Application.ProductName);
                    return;
                }
            }
            else // search upwards
            {
                string toBeSearched = textBox.Text.Substring(0, textBox.SelectionStart);
                searchPosition = toBeSearched.LastIndexOf(findString);
                if (searchPosition == -1) {
                    MessageBox.Show(String.Format("No further occurences of \"{0}\" have been found", findString),
                                    Application.ProductName);
                    return;
                }
            }
            textBox.SelectionStart = searchPosition;
            textBox.SelectionLength = findString.Length;
            textBox.ScrollToCaret();
        }

        private void _cancelButton_Click(object sender, EventArgs e) {
            Close();
        }
    }

}
