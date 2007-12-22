using System;
using System.Windows.Forms;
using JesterDotNet.Presenter;

namespace JesterDotNet.Forms
{
    /// <summary>
    /// Appears when a user decides to create a new <see cref="JesterProject"/> from
    /// existing assemblies.
    /// </summary>
    public partial class NewProjectFileForm : Form
    {
        private string _projectFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewProjectFileForm"/> class.
        /// </summary>
        public NewProjectFileForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the path to new instance of <see cref="JesterProject"/> that the user has
        /// created.  This value will be <c>null</c> if no project was created.
        /// </summary>
        /// <value>The path to the new instance of <see cref="JesterProject"/>.</value>
        public string ProjectFilePath
        {
            get { return _projectFilePath; }
        }

        /// <summary>
        /// Handles the Click event of the browseTargetAssemblyButton control.  Allows the
        /// user to choose a target assembly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void browseTargetAssemblyButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                targetAssemblyTextBox.Text = openFileDialog.FileName;
                okButton.Enabled = OKButtonCanBeEnabled();
            }
        }

        /// <summary>
        /// Tests if the <see cref="okButton"/> is allowed to be enabled.  This button
        /// may only be enabled if all necessary information has been gathered from the
        /// user.
        /// </summary>
        /// <returns></returns>
        private bool OKButtonCanBeEnabled()
        {
            return ((targetAssemblyTextBox.Text.Length != 0) &&
                    (testAssemblyTextBox.Text.Length != 0) &&
                    (saveAsTextBox.Text.Length != 0));
        }

        /// <summary>
        /// Handles the Click event of the browseTestAssemblyButton control.  Allows the
        /// user to choose a test assembly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void browseTestAssemblyButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                testAssemblyTextBox.Text = openFileDialog.FileName;
                okButton.Enabled = OKButtonCanBeEnabled();
            }
        }

        /// <summary>
        /// Handles the Click event of the okButton control.  Sets the <see 
        /// cref="ProjectFilePath"/> property to the location of the new <see 
        /// cref="JesterProject"/> that the user has created.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            JesterProject project = new JesterProject(targetAssemblyTextBox.Text,
                                         testAssemblyTextBox.Text);
            _projectFilePath = saveAsTextBox.Text;

            JesterProjectSerializer serializer = new JesterProjectSerializer();
            serializer.Serialize(project, _projectFilePath);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Handles the Click event of the cancelButton control.  Closes the form and 
        /// resets the <see cref="ProjectFilePath"/> property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            _projectFilePath = null;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Handles the Click event of the saveAsButton control.  Allows the user to choose
        /// where to save the new project file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                saveAsTextBox.Text = saveFileDialog.FileName;
                okButton.Enabled = OKButtonCanBeEnabled();
            }
        }
    }
}