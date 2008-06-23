namespace JesterDotNet.Forms
{
    partial class PreferencesForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.frameworkToolsTabPage = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.ilDasmPathBrowseButton = new System.Windows.Forms.Button();
            this.ilAsmPathBrowseButton = new System.Windows.Forms.Button();
            this.ilDasmPathTextBox = new System.Windows.Forms.TextBox();
            this.ilAsmPathTextBox = new System.Windows.Forms.TextBox();
            this.ilDasmPathLabel = new System.Windows.Forms.Label();
            this.ilAsmPathLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.frameworkToolsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.frameworkToolsTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 276);
            this.tabControl.TabIndex = 0;
            // 
            // frameworkToolsTabPage
            // 
            this.frameworkToolsTabPage.Controls.Add(this.cancelButton);
            this.frameworkToolsTabPage.Controls.Add(this.okButton);
            this.frameworkToolsTabPage.Controls.Add(this.ilDasmPathBrowseButton);
            this.frameworkToolsTabPage.Controls.Add(this.ilAsmPathBrowseButton);
            this.frameworkToolsTabPage.Controls.Add(this.ilDasmPathTextBox);
            this.frameworkToolsTabPage.Controls.Add(this.ilAsmPathTextBox);
            this.frameworkToolsTabPage.Controls.Add(this.ilDasmPathLabel);
            this.frameworkToolsTabPage.Controls.Add(this.ilAsmPathLabel);
            this.frameworkToolsTabPage.Location = new System.Drawing.Point(4, 22);
            this.frameworkToolsTabPage.Name = "frameworkToolsTabPage";
            this.frameworkToolsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.frameworkToolsTabPage.Size = new System.Drawing.Size(476, 250);
            this.frameworkToolsTabPage.TabIndex = 1;
            this.frameworkToolsTabPage.Text = "Framework Tools";
            this.frameworkToolsTabPage.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(395, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(314, 219);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ilDasmPathBrowseButton
            // 
            this.ilDasmPathBrowseButton.Location = new System.Drawing.Point(395, 37);
            this.ilDasmPathBrowseButton.Name = "ilDasmPathBrowseButton";
            this.ilDasmPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ilDasmPathBrowseButton.TabIndex = 5;
            this.ilDasmPathBrowseButton.Text = "Browse...";
            this.ilDasmPathBrowseButton.UseVisualStyleBackColor = true;
            this.ilDasmPathBrowseButton.Click += new System.EventHandler(this.ilDasmPathBrowseButton_Click);
            // 
            // ilAsmPathBrowseButton
            // 
            this.ilAsmPathBrowseButton.Location = new System.Drawing.Point(395, 7);
            this.ilAsmPathBrowseButton.Name = "ilAsmPathBrowseButton";
            this.ilAsmPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ilAsmPathBrowseButton.TabIndex = 4;
            this.ilAsmPathBrowseButton.Text = "Browse...";
            this.ilAsmPathBrowseButton.UseVisualStyleBackColor = true;
            this.ilAsmPathBrowseButton.Click += new System.EventHandler(this.ilAsmPathBrowseButton_Click);
            // 
            // ilDasmPathTextBox
            // 
            this.ilDasmPathTextBox.Location = new System.Drawing.Point(90, 39);
            this.ilDasmPathTextBox.Name = "ilDasmPathTextBox";
            this.ilDasmPathTextBox.ReadOnly = true;
            this.ilDasmPathTextBox.Size = new System.Drawing.Size(299, 20);
            this.ilDasmPathTextBox.TabIndex = 3;
            // 
            // ilAsmPathTextBox
            // 
            this.ilAsmPathTextBox.Location = new System.Drawing.Point(90, 9);
            this.ilAsmPathTextBox.Name = "ilAsmPathTextBox";
            this.ilAsmPathTextBox.ReadOnly = true;
            this.ilAsmPathTextBox.Size = new System.Drawing.Size(299, 20);
            this.ilAsmPathTextBox.TabIndex = 2;
            // 
            // ilDasmPathLabel
            // 
            this.ilDasmPathLabel.AutoSize = true;
            this.ilDasmPathLabel.Location = new System.Drawing.Point(16, 42);
            this.ilDasmPathLabel.Name = "ilDasmPathLabel";
            this.ilDasmPathLabel.Size = new System.Drawing.Size(68, 13);
            this.ilDasmPathLabel.TabIndex = 1;
            this.ilDasmPathLabel.Text = "ILDasm Path";
            // 
            // ilAsmPathLabel
            // 
            this.ilAsmPathLabel.AutoSize = true;
            this.ilAsmPathLabel.Location = new System.Drawing.Point(23, 12);
            this.ilAsmPathLabel.Name = "ilAsmPathLabel";
            this.ilAsmPathLabel.Size = new System.Drawing.Size(61, 13);
            this.ilAsmPathLabel.TabIndex = 0;
            this.ilAsmPathLabel.Text = "ILAsm Path";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Executable Files|*.exe";
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(508, 300);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.tabControl.ResumeLayout(false);
            this.frameworkToolsTabPage.ResumeLayout(false);
            this.frameworkToolsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage frameworkToolsTabPage;
        private System.Windows.Forms.Label ilDasmPathLabel;
        private System.Windows.Forms.Label ilAsmPathLabel;
        private System.Windows.Forms.Button ilDasmPathBrowseButton;
        private System.Windows.Forms.Button ilAsmPathBrowseButton;
        private System.Windows.Forms.TextBox ilDasmPathTextBox;
        private System.Windows.Forms.TextBox ilAsmPathTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}