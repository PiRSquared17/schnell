namespace WikiPad 
{

    #region Imports

    using System.Windows.Forms;

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
    }
}
