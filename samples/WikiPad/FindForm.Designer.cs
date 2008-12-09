using System.Windows.Forms;

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
            this.SuspendLayout();
            // 
            // _findLabel
            // 
            this._findLabel.AutoSize = true;
            this._findLabel.Location = new System.Drawing.Point(13, 13);
            this._findLabel.Name = "_findLabel";
            this._findLabel.Size = new System.Drawing.Size(56, 13);
            this._findLabel.TabIndex = 0;
            this._findLabel.Text = "Find what:";
            // 
            // _searchBox
            // 
            this._searchBox.Location = new System.Drawing.Point(75, 10);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(212, 20);
            this._searchBox.TabIndex = 1;
            // 
            // _findButton
            // 
            this._findButton.Location = new System.Drawing.Point(293, 8);
            this._findButton.Name = "_findButton";
            this._findButton.Size = new System.Drawing.Size(102, 23);
            this._findButton.TabIndex = 2;
            this._findButton.Text = "Find";
            this._findButton.UseVisualStyleBackColor = true;
            this._findButton.Click += new System.EventHandler(this._findButton_Click);
            // 
            // FindForm
            // 
            this.AcceptButton = this._findButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 140);
            this.Controls.Add(this._findButton);
            this.Controls.Add(this._searchBox);
            this.Controls.Add(this._findLabel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _findLabel;
        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.Button _findButton;
    }
}