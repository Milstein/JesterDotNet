namespace JesterDotNet.Forms
{
    partial class NewProjectFileForm
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
            this.browseTargetAssemblyButton = new System.Windows.Forms.Button();
            this.browseTestAssemblyButton = new System.Windows.Forms.Button();
            this.targetAssemblyLabel = new System.Windows.Forms.Label();
            this.testAssemblyLabel = new System.Windows.Forms.Label();
            this.targetAssemblyTextBox = new System.Windows.Forms.TextBox();
            this.testAssemblyTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.saveAsTextBox = new System.Windows.Forms.TextBox();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // browseTargetAssemblyButton
            // 
            this.browseTargetAssemblyButton.Location = new System.Drawing.Point(422, 12);
            this.browseTargetAssemblyButton.Name = "browseTargetAssemblyButton";
            this.browseTargetAssemblyButton.Size = new System.Drawing.Size(75, 23);
            this.browseTargetAssemblyButton.TabIndex = 0;
            this.browseTargetAssemblyButton.Text = "Browse...";
            this.browseTargetAssemblyButton.UseVisualStyleBackColor = true;
            this.browseTargetAssemblyButton.Click += new System.EventHandler(this.browseTargetAssemblyButton_Click);
            // 
            // browseTestAssemblyButton
            // 
            this.browseTestAssemblyButton.Location = new System.Drawing.Point(422, 41);
            this.browseTestAssemblyButton.Name = "browseTestAssemblyButton";
            this.browseTestAssemblyButton.Size = new System.Drawing.Size(75, 23);
            this.browseTestAssemblyButton.TabIndex = 1;
            this.browseTestAssemblyButton.Text = "Browse...";
            this.browseTestAssemblyButton.UseVisualStyleBackColor = true;
            this.browseTestAssemblyButton.Click += new System.EventHandler(this.browseTestAssemblyButton_Click);
            // 
            // targetAssemblyLabel
            // 
            this.targetAssemblyLabel.AutoSize = true;
            this.targetAssemblyLabel.Location = new System.Drawing.Point(13, 17);
            this.targetAssemblyLabel.Name = "targetAssemblyLabel";
            this.targetAssemblyLabel.Size = new System.Drawing.Size(85, 13);
            this.targetAssemblyLabel.TabIndex = 2;
            this.targetAssemblyLabel.Text = "Target Assembly";
            // 
            // testAssemblyLabel
            // 
            this.testAssemblyLabel.AutoSize = true;
            this.testAssemblyLabel.Location = new System.Drawing.Point(23, 46);
            this.testAssemblyLabel.Name = "testAssemblyLabel";
            this.testAssemblyLabel.Size = new System.Drawing.Size(75, 13);
            this.testAssemblyLabel.TabIndex = 3;
            this.testAssemblyLabel.Text = "Test Assembly";
            // 
            // targetAssemblyTextBox
            // 
            this.targetAssemblyTextBox.Location = new System.Drawing.Point(104, 14);
            this.targetAssemblyTextBox.Name = "targetAssemblyTextBox";
            this.targetAssemblyTextBox.ReadOnly = true;
            this.targetAssemblyTextBox.Size = new System.Drawing.Size(312, 20);
            this.targetAssemblyTextBox.TabIndex = 4;
            // 
            // testAssemblyTextBox
            // 
            this.testAssemblyTextBox.Location = new System.Drawing.Point(104, 43);
            this.testAssemblyTextBox.Name = "testAssemblyTextBox";
            this.testAssemblyTextBox.ReadOnly = true;
            this.testAssemblyTextBox.Size = new System.Drawing.Size(312, 20);
            this.testAssemblyTextBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(340, 141);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(422, 141);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Dlls|*.dll|Exes|*.exe";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(44, 73);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(54, 13);
            this.fileNameLabel.TabIndex = 8;
            this.fileNameLabel.Text = "File Name";
            // 
            // saveAsTextBox
            // 
            this.saveAsTextBox.Location = new System.Drawing.Point(104, 70);
            this.saveAsTextBox.Name = "saveAsTextBox";
            this.saveAsTextBox.ReadOnly = true;
            this.saveAsTextBox.Size = new System.Drawing.Size(312, 20);
            this.saveAsTextBox.TabIndex = 9;
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(422, 68);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 10;
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Jester Project Files|*.jst";
            // 
            // NewProjectFileForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(509, 172);
            this.ControlBox = false;
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveAsTextBox);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.testAssemblyTextBox);
            this.Controls.Add(this.targetAssemblyTextBox);
            this.Controls.Add(this.testAssemblyLabel);
            this.Controls.Add(this.targetAssemblyLabel);
            this.Controls.Add(this.browseTestAssemblyButton);
            this.Controls.Add(this.browseTargetAssemblyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectFileForm";
            this.Text = "Create a new project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseTargetAssemblyButton;
        private System.Windows.Forms.Button browseTestAssemblyButton;
        private System.Windows.Forms.Label targetAssemblyLabel;
        private System.Windows.Forms.Label testAssemblyLabel;
        private System.Windows.Forms.TextBox targetAssemblyTextBox;
        private System.Windows.Forms.TextBox testAssemblyTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TextBox saveAsTextBox;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}