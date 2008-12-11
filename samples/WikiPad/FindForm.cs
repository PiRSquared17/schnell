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

        private static void Find(TextBoxBase textBox, string findString, bool caseSensitive, bool upwards) 
        {
            if (textBox.Text.IndexOf(findString, caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) == -1)
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

                if (caseSensitive)
                    searchPosition = toBeSearched.LastIndexOf(findString, StringComparison.CurrentCulture);
                else
                    searchPosition = toBeSearched.LastIndexOf(findString, StringComparison.CurrentCultureIgnoreCase);

                if (searchPosition == -1) 
                {
                    MessageBox.Show(String.Format("No further occurences of \"{0}\" have been found", findString),
                                    Application.ProductName);
                    return;
                }
            }
            textBox.SelectionStart = searchPosition;
            textBox.SelectionLength = findString.Length;
            textBox.ScrollToCaret();
        }

        private void CancelButton_Click(object sender, EventArgs e) 
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e) 
        {
            _findButton.Enabled = !String.IsNullOrEmpty(_searchBox.Text);
        }
    }

}
