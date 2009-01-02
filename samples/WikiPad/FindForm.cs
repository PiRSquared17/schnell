namespace WikiPad 
{
    #region Imports

    using System;
    using System.Windows.Forms;

    #endregion

    public partial class FindForm : Form 
    {
        private readonly TextBoxBase _textBox;

        public FindForm(TextBoxBase textBox) 
        {
            InitializeComponent();
            _textBox = textBox;
        }

        private void FindButton_Click(object sender, EventArgs e) 
        {
            Find(_textBox, _searchBox.Text, _matchCaseCheckBox.Checked, _upRadioButton.Checked);
        }

        internal static void Find(TextBoxBase textBox, string findString, bool caseSensitive, bool upwards) 
        {
            var comparison = caseSensitive
                           ? StringComparison.CurrentCulture 
                           : StringComparison.CurrentCultureIgnoreCase;

            var text = textBox.Text;
            if (text.IndexOf(findString, comparison) == -1)
            {
                ShowFormattedMessageBox("Cannot find \"{0}\".", findString);
                return;
            }

            var foundIndex = Find(text, textBox.SelectionStart, textBox.SelectionLength, findString, comparison, upwards);
            if (foundIndex == -1)
            {
                ShowFormattedMessageBox("No further occurences of \"{0}\" have been found.", findString);
                return;
            }

            textBox.Select(foundIndex, findString.Length);
            textBox.ScrollToCaret();
        }

        private static int Find(string text, int start, int count, string sought, StringComparison comparison, bool upwards)
        {
            if (!upwards)
            {
                if (start == text.Length) start = 0;
                start = start >= 0 ? start + count : 0;
                return text.IndexOf(sought, start, comparison);
            }
            else
            {
                if (start == 0)
                    return -1;
                return text.LastIndexOf(sought, start -1, start -1, comparison);
            }
        }

        internal static void ShowFormattedMessageBox(string format, params object[] args)
        {
            MessageBox.Show(string.Format(format, args), Application.ProductName);
        }

        private void CancelButton_Click(object sender, EventArgs e) 
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e) 
        {
            _findButton.Enabled = !string.IsNullOrEmpty(_searchBox.Text);
        }
    }

}
