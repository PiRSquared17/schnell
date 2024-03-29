﻿using System.Windows.Forms;

namespace WikiPad {
    partial class FindForm {
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
            this._findLabel = new System.Windows.Forms.Label();
            this._searchBox = new System.Windows.Forms.TextBox();
            this._findButton = new System.Windows.Forms.Button();
            this._matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._downRadioButton = new System.Windows.Forms.RadioButton();
            this._upRadioButton = new System.Windows.Forms.RadioButton();
            this._cancelButton = new System.Windows.Forms.Button();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _findLabel
            // 
            this._findLabel.AutoSize = true;
            this._findLabel.Location = new System.Drawing.Point(17, 16);
            this._findLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._findLabel.Name = "_findLabel";
            this._findLabel.Size = new System.Drawing.Size(72, 17);
            this._findLabel.TabIndex = 0;
            this._findLabel.Text = "Fi&nd what:";
            // 
            // _searchBox
            // 
            this._searchBox.Location = new System.Drawing.Point(100, 12);
            this._searchBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(281, 22);
            this._searchBox.TabIndex = 1;
            this._searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // _findButton
            // 
            this._findButton.Enabled = false;
            this._findButton.Location = new System.Drawing.Point(391, 10);
            this._findButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._findButton.Name = "_findButton";
            this._findButton.Size = new System.Drawing.Size(136, 28);
            this._findButton.TabIndex = 2;
            this._findButton.Text = "&Find";
            this._findButton.UseVisualStyleBackColor = true;
            this._findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // _matchCaseCheckBox
            // 
            this._matchCaseCheckBox.AutoSize = true;
            this._matchCaseCheckBox.Location = new System.Drawing.Point(21, 64);
            this._matchCaseCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._matchCaseCheckBox.Name = "_matchCaseCheckBox";
            this._matchCaseCheckBox.Size = new System.Drawing.Size(102, 21);
            this._matchCaseCheckBox.TabIndex = 3;
            this._matchCaseCheckBox.Text = "Match &case";
            this._matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._downRadioButton);
            this._groupBox.Controls.Add(this._upRadioButton);
            this._groupBox.Location = new System.Drawing.Point(219, 64);
            this._groupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBox.Size = new System.Drawing.Size(164, 59);
            this._groupBox.TabIndex = 4;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Direction";
            // 
            // _downRadioButton
            // 
            this._downRadioButton.AutoSize = true;
            this._downRadioButton.Checked = true;
            this._downRadioButton.Location = new System.Drawing.Point(71, 25);
            this._downRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._downRadioButton.Name = "_downRadioButton";
            this._downRadioButton.Size = new System.Drawing.Size(64, 21);
            this._downRadioButton.TabIndex = 1;
            this._downRadioButton.TabStop = true;
            this._downRadioButton.Text = "&Down";
            this._downRadioButton.UseVisualStyleBackColor = true;
            // 
            // _upRadioButton
            // 
            this._upRadioButton.AutoSize = true;
            this._upRadioButton.Location = new System.Drawing.Point(9, 25);
            this._upRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._upRadioButton.Name = "_upRadioButton";
            this._upRadioButton.Size = new System.Drawing.Size(47, 21);
            this._upRadioButton.TabIndex = 0;
            this._upRadioButton.Text = "&Up";
            this._upRadioButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(392, 47);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(135, 28);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FindForm
            // 
            this.AcceptButton = this._findButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(556, 139);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._matchCaseCheckBox);
            this.Controls.Add(this._findButton);
            this.Controls.Add(this._searchBox);
            this.Controls.Add(this._findLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _findLabel;
        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.Button _findButton;
        private CheckBox _matchCaseCheckBox;
        private GroupBox _groupBox;
        private RadioButton _downRadioButton;
        private RadioButton _upRadioButton;
        private Button _cancelButton;
    }
}