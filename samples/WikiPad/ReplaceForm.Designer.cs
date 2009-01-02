namespace WikiPad {
    partial class ReplaceForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this._replaceTextBox = new System.Windows.Forms.TextBox();
            this._findButton = new System.Windows.Forms.Button();
            this._replaceButton = new System.Windows.Forms.Button();
            this._ReplaceAll = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this._regexCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "F&ind what:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Re&place with:";
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Location = new System.Drawing.Point(106, 10);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(197, 20);
            this._searchTextBox.TabIndex = 1;
            // 
            // _replaceTextBox
            // 
            this._replaceTextBox.Location = new System.Drawing.Point(106, 37);
            this._replaceTextBox.Name = "_replaceTextBox";
            this._replaceTextBox.Size = new System.Drawing.Size(197, 20);
            this._replaceTextBox.TabIndex = 3;
            // 
            // _findButton
            // 
            this._findButton.Location = new System.Drawing.Point(309, 8);
            this._findButton.Name = "_findButton";
            this._findButton.Size = new System.Drawing.Size(75, 23);
            this._findButton.TabIndex = 4;
            this._findButton.Text = "&Find Next";
            this._findButton.UseVisualStyleBackColor = true;
            this._findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // _replaceButton
            // 
            this._replaceButton.Location = new System.Drawing.Point(309, 37);
            this._replaceButton.Name = "_replaceButton";
            this._replaceButton.Size = new System.Drawing.Size(75, 23);
            this._replaceButton.TabIndex = 5;
            this._replaceButton.Text = "&Replace";
            this._replaceButton.UseVisualStyleBackColor = true;
            this._replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // _ReplaceAll
            // 
            this._ReplaceAll.Location = new System.Drawing.Point(309, 66);
            this._ReplaceAll.Name = "_ReplaceAll";
            this._ReplaceAll.Size = new System.Drawing.Size(75, 23);
            this._ReplaceAll.TabIndex = 6;
            this._ReplaceAll.Text = "Replace &All";
            this._ReplaceAll.UseVisualStyleBackColor = true;
            this._ReplaceAll.Click += new System.EventHandler(this.ReplaceAll_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(309, 96);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _matchCaseCheckBox
            // 
            this._matchCaseCheckBox.AutoSize = true;
            this._matchCaseCheckBox.Location = new System.Drawing.Point(16, 82);
            this._matchCaseCheckBox.Name = "_matchCaseCheckBox";
            this._matchCaseCheckBox.Size = new System.Drawing.Size(82, 17);
            this._matchCaseCheckBox.TabIndex = 8;
            this._matchCaseCheckBox.Text = "Match &case";
            this._matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // _regexCheckBox
            // 
            this._regexCheckBox.AutoSize = true;
            this._regexCheckBox.Location = new System.Drawing.Point(16, 102);
            this._regexCheckBox.Name = "_regexCheckBox";
            this._regexCheckBox.Size = new System.Drawing.Size(144, 17);
            this._regexCheckBox.TabIndex = 9;
            this._regexCheckBox.Text = "&Use Regular Expressions";
            this._regexCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReplaceForm
            // 
            this.AcceptButton = this._findButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(391, 128);
            this.Controls.Add(this._regexCheckBox);
            this.Controls.Add(this._matchCaseCheckBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._ReplaceAll);
            this.Controls.Add(this._replaceButton);
            this.Controls.Add(this._findButton);
            this.Controls.Add(this._replaceTextBox);
            this.Controls.Add(this._searchTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _searchTextBox;
        private System.Windows.Forms.TextBox _replaceTextBox;
        private System.Windows.Forms.Button _findButton;
        private System.Windows.Forms.Button _replaceButton;
        private System.Windows.Forms.Button _ReplaceAll;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.CheckBox _matchCaseCheckBox;
        private System.Windows.Forms.CheckBox _regexCheckBox;
    }
}