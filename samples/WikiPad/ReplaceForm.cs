using System;

namespace WikiPad 
{

    #region Imports

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
            StringBuilder sb = new StringBuilder();
            string text = _textBox.Text;
            sb.Append(text.Substring(0, _textBox.SelectionStart));
            sb.Append(_replaceTextBox.Text);
            sb.Append(text.Substring(_textBox.SelectionStart + _textBox.SelectionLength));
            _textBox.Text = sb.ToString();

            // jump to the next occurence of searched string so user can replace one by one
            WikiPad.FindForm.Find(_textBox, _searchTextBox.Text, _matchCaseCheckBox.Checked, false);
        }
    }
}
