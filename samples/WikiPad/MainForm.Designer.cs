#region License, Terms and Author(s)
//
// Schnell - Wiki widgets
// Copyright (c) 2007 Atif Aziz. All rights reserved.
//
//  Author(s):
//      Atif Aziz, http://www.raboof.com
//
// This library is free software; you can redistribute it and/or modify it 
// under the terms of the GNU Lesser General Public License as published by 
// the Free Software Foundation; either version 2.1 of the License, or (at 
// your option) any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or 
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
// License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, 
// Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion
namespace WikiPad
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem wikiSyntaxToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator;
            System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
            System.Windows.Forms.SplitContainer splitContainer;
            System.Windows.Forms.TabControl _tabControl;
            System.Windows.Forms.TabPage _wikiTab;
            System.Windows.Forms.TabPage _htmlSourceTab;
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._wikiBox = new System.Windows.Forms.TextBox();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this._htmlBox = new System.Windows.Forms.RichTextBox();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            wikiSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer = new System.Windows.Forms.SplitContainer();
            _tabControl = new System.Windows.Forms.TabControl();
            _wikiTab = new System.Windows.Forms.TabPage();
            _htmlSourceTab = new System.Windows.Forms.TabPage();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            _tabControl.SuspendLayout();
            _wikiTab.SuspendLayout();
            _htmlSourceTab.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this._mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            wikiSyntaxToolStripMenuItem});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // wikiSyntaxToolStripMenuItem
            // 
            wikiSyntaxToolStripMenuItem.Name = "wikiSyntaxToolStripMenuItem";
            wikiSyntaxToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            wikiSyntaxToolStripMenuItem.Text = "&Wiki Syntax";
            wikiSyntaxToolStripMenuItem.Click += new System.EventHandler(this.HelpWikiSyntaxMenu_Click);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newToolStripMenuItem,
            openToolStripMenuItem,
            this.toolStripSeparator2,
            saveToolStripMenuItem,
            saveAsToolStripMenuItem,
            toolStripSeparator1,
            toolStripMenuItem1,
            toolStripSeparator,
            exitToolStripMenuItem});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            newToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += new System.EventHandler(this.FileNewMenu_Click);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            openToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            openToolStripMenuItem.Text = "&Open...";
            openToolStripMenuItem.Click += new System.EventHandler(this.FileOpenMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            saveToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveMenu_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            saveAsToolStripMenuItem.Text = "Save &As...";
            saveAsToolStripMenuItem.Click += new System.EventHandler(this.FileSaveAsMenu_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(205, 24);
            toolStripMenuItem1.Text = "&Import From Web...";
            toolStripMenuItem1.Click += new System.EventHandler(this.ImportFromWebMenu_Click);
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += new System.EventHandler(this.FileExitMenu_Click);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            undoToolStripMenuItem,
            redoToolStripMenuItem,
            toolStripSeparator4,
            cutToolStripMenuItem,
            copyToolStripMenuItem,
            pasteToolStripMenuItem,
            toolStripSeparator5,
            selectAllToolStripMenuItem});
            editToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            undoToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            redoToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            cutToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            copyToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            pasteToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(3, 3);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(this._wikiBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(this._webBrowser);
            splitContainer.Size = new System.Drawing.Size(756, 439);
            splitContainer.SplitterDistance = 366;
            splitContainer.TabIndex = 3;
            // 
            // _wikiBox
            // 
            this._wikiBox.AcceptsReturn = true;
            this._wikiBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wikiBox.Location = new System.Drawing.Point(0, 0);
            this._wikiBox.MaxLength = 131072;
            this._wikiBox.Multiline = true;
            this._wikiBox.Name = "_wikiBox";
            this._wikiBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._wikiBox.Size = new System.Drawing.Size(366, 439);
            this._wikiBox.TabIndex = 1;
            this._wikiBox.TextChanged += new System.EventHandler(this.WikiBox_TextChanged);
            // 
            // _webBrowser
            // 
            this._webBrowser.AllowNavigation = false;
            this._webBrowser.AllowWebBrowserDrop = false;
            this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webBrowser.IsWebBrowserContextMenuEnabled = false;
            this._webBrowser.Location = new System.Drawing.Point(0, 0);
            this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser.Name = "_webBrowser";
            this._webBrowser.ScriptErrorsSuppressed = true;
            this._webBrowser.Size = new System.Drawing.Size(386, 439);
            this._webBrowser.TabIndex = 0;
            this._webBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // _tabControl
            // 
            _tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            _tabControl.Controls.Add(_wikiTab);
            _tabControl.Controls.Add(_htmlSourceTab);
            _tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _tabControl.Location = new System.Drawing.Point(0, 0);
            _tabControl.Name = "_tabControl";
            _tabControl.SelectedIndex = 0;
            _tabControl.Size = new System.Drawing.Size(770, 477);
            _tabControl.TabIndex = 0;
            // 
            // _wikiTab
            // 
            _wikiTab.Controls.Add(splitContainer);
            _wikiTab.Location = new System.Drawing.Point(4, 28);
            _wikiTab.Name = "_wikiTab";
            _wikiTab.Padding = new System.Windows.Forms.Padding(3);
            _wikiTab.Size = new System.Drawing.Size(762, 445);
            _wikiTab.TabIndex = 0;
            _wikiTab.Text = "Wiki/Preview";
            _wikiTab.UseVisualStyleBackColor = true;
            // 
            // _htmlSourceTab
            // 
            _htmlSourceTab.Controls.Add(this._htmlBox);
            _htmlSourceTab.Location = new System.Drawing.Point(4, 28);
            _htmlSourceTab.Name = "_htmlSourceTab";
            _htmlSourceTab.Padding = new System.Windows.Forms.Padding(3);
            _htmlSourceTab.Size = new System.Drawing.Size(762, 445);
            _htmlSourceTab.TabIndex = 1;
            _htmlSourceTab.Text = "HTML Source";
            _htmlSourceTab.UseVisualStyleBackColor = true;
            // 
            // _htmlBox
            // 
            this._htmlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._htmlBox.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._htmlBox.Location = new System.Drawing.Point(3, 3);
            this._htmlBox.Name = "_htmlBox";
            this._htmlBox.ReadOnly = true;
            this._htmlBox.Size = new System.Drawing.Size(756, 439);
            this._htmlBox.TabIndex = 1;
            this._htmlBox.Text = "";
            // 
            // _timer
            // 
            this._timer.Enabled = true;
            this._timer.Interval = 500;
            this._timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(_tabControl);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(770, 477);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(770, 505);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this._mainMenu);
            // 
            // _mainMenu
            // 
            this._mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            editToolStripMenuItem,
            helpToolStripMenuItem});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(770, 28);
            this._mainMenu.TabIndex = 0;
            this._mainMenu.Text = "menuStrip1";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.DefaultExt = "wiki";
            this._openFileDialog.Filter = "Wiki files (*.wiki)|*.wiki|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 505);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "MainForm";
            this.Text = "WikiPad";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.ResumeLayout(false);
            _tabControl.ResumeLayout(false);
            _wikiTab.ResumeLayout(false);
            _htmlSourceTab.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.RichTextBox _htmlBox;
        private System.Windows.Forms.TextBox _wikiBox;
        private System.Windows.Forms.WebBrowser _webBrowser;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

    }
}

