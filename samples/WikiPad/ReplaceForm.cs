namespace WikiPad 
{

    #region Imports

    using System;
    using System.Windows.Forms;
    using System.Text;

    #endregion

    public partial class ReplaceForm : Form 
    {
        private readonly TextBoxBase _textBox;
        public ReplaceForm(TextBoxBase textBox) 
        {
            InitializeComponent();
            _textBox = textBox;
        }

        private void FindButton_Click(object sender, System.EventArgs e) 
        {
            WikiPad.FindForm.Find(_textBox, _searchTextBox.Text, _matchCaseCheckBox.Checked, false);
        }

        private void ReplaceButton_Click(object sender, System.EventArgs e) 
        {
            var comparison = _matchCaseCheckBox.Checked
                                 ? StringComparison.CurrentCulture
                                 : StringComparison.InvariantCultureIgnoreCase;
            if (string.Compare(_textBox.Text.Substring(_textBox.SelectionStart, _textBox.SelectionLength), _searchTextBox.Text, comparison) != 0)
            {
                WikiPad.FindForm.Find(_textBox, _searchTextBox.Text, _matchCaseCheckBox.Checked, false);
                return;
            }

            _textBox.Text = Replace(_textBox.Text, _replaceTextBox.Text, _textBox.SelectionStart, _textBox.SelectionLength);

            // jump to the next occurence of searched string so user can replace one by one
            WikiPad.FindForm.Find(_textBox, _searchTextBox.Text, _matchCaseCheckBox.Checked, false);
        }

        private void ReplaceAll_Click(object sender, EventArgs e) 
        {
            if (!_matchCaseCheckBox.Checked)
            {
                _textBox.Text = _textBox.Text.Replace(_searchTextBox.Text, _replaceTextBox.Text);
                return;
            }
            int position = 0;
            int hit;
            while ((hit = _textBox.Text.IndexOf(_searchTextBox.Text, position, StringComparison.CurrentCulture)) >= 0)
            {
                _textBox.Text = Replace(_textBox.Text, _replaceTextBox.Text, hit, _replaceTextBox.Text.Length);
                position = hit + _replaceTextBox.Text.Length;
            }
        }

        /// <summary>
        /// Replaces specified range of operand by newValue.
        /// </summary>
        private static string Replace(string operand, string newValue, int start, int length)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(operand.Substring(0, start));
            sb.Append(newValue);
            sb.Append(operand.Substring(start + length));
            return sb.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e) 
        {
            // Hide() would cause replaceForm to be disposed
            Visible = false;
        }
    }
}
