using System;
using System.Windows.Forms;
using JesterDotNet.Presenter;

namespace JesterDotNet.Forms
{
    /// <summary>
    /// Provides a UI allowing users to set their own preferences specific to their 
    /// installation.
    /// </summary>
    public partial class PreferencesForm : Form, IPreferencesView
    {
        private PreferencesPresenter _preferencesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferencesForm"/> class.
        /// </summary>
        public PreferencesForm()
        {
            InitializeComponent();
            _preferencesPresenter = new PreferencesPresenter(this);
        }

        /// <summary>
        /// Handles the Click event of the ilAsmPathBrowseButton control.  Allows the user
        /// to set the specific path of their IL Asm executable.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event 
        /// data.</param>
        private void ilAsmPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                ilAsmPathTextBox.Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Handles the Click event of the ilDasmPathBrowseButton control.  Allows the user
        /// to set the specific path of their IL Dasm executable.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event 
        /// data.</param>
        private void ilDasmPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                ilDasmPathTextBox.Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Handles the Click event of the okButton control.  Persists the user settings
        /// to the preferences file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event 
        /// data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (PreferencesUpdated != null)
                PreferencesUpdated(this, new PreferencesUpdatedEventArgs(ilAsmPathTextBox.Text,
                    ilDasmPathTextBox.Text));

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Handles the Click event of the cancelButton control.  Closes the form without
        /// making any change.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event 
        /// data.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Occurs when the user has pressed the <see cref="okButton"/>.
        /// </summary>
        public event EventHandler<PreferencesUpdatedEventArgs> PreferencesUpdated;
    }
}