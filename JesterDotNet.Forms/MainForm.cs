using System;
using System.IO;
using System.Windows.Forms;
using JesterDotNet.Presenter;

namespace JesterDotNet.Forms
{
    /// <summary>
    /// Acts as the main UI for the end user.
    /// </summary>
    public partial class MainForm : Form, IJesterView
    {
        private string _shadowedTargetAssembly;
        private string _shadowedTestAssembly;
        
        #region Constructors (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            JesterPresenter presenter = new JesterPresenter(this);
            presenter.TestComplete += presenter_TestComplete;
            presenter.MutationComplete += presenter_MutationComplete;
        }

        #endregion Constructors (Public)

        #region IJesterView Members

        /// <summary>
        /// Occurs when the user has initiated the full mutation and test process.
        /// </summary>
        public event EventHandler<RunEventArgs> Run;

        /// <summary>
        /// Occurs when the user has requested to cancel the process.
        /// </summary>
        public event EventHandler<EventArgs> Cancel;

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the Click event of the openToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectOpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string fileName in projectOpenFileDialog.FileNames)
                {
                    LoadProjectFile(fileName);
                }
                runButton.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the MutationComplete event of the presenter control.  Populates the list 
        /// view with the results of the mutation test.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MutationCompleteEventArgs"/> instance containing 
        /// the event data.</param>
        void presenter_MutationComplete(object sender, MutationCompleteEventArgs e)
        {
            foreach (TestResultDto result in e.TestResults)
            {
                FailingTestResultDto failingTestResult = result as FailingTestResultDto;
                if (failingTestResult != null)
                {
                    mutationErrorsListView.Items.Add("", 0);
                    mutationErrorsListView.Items[mutationErrorsListView.Items.Count - 1].
                        SubItems.Add(failingTestResult.Name);
                    mutationErrorsListView.Items[mutationErrorsListView.Items.Count - 1].
                        SubItems.Add(failingTestResult.Exception);
                    mutationErrorsListView.Items[mutationErrorsListView.Items.Count - 1].
                        SubItems.Add(failingTestResult.Message);
                }
            }
            foreach (ColumnHeader columnHeader in mutationErrorsListView.Columns)
                columnHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void presenter_TestComplete(object sender, EventArgs e)
        {
            progressBar.Value++;
        }

        /// <summary>
        /// Handles the Click event of the RunButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Copies the given assmembly to an area where it can be accessed.
        /// </summary>
        /// <param name="fileName">The assembly to be copied.</param>
        /// <returns>The path of the newly copied assembly.</returns>
        private static string ShadowCopyAssembly(string fileName)
        {
            string destination =
                Path.Combine(Path.GetTempPath(), Path.GetFileName(fileName));
            File.Copy(fileName, destination, true);

            return destination;
        }

        /// <summary>
        /// Handles the Click event of the newToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewProjectFileForm form = new NewProjectFileForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProjectFile(form.ProjectFilePath);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the optionsToolStripMenuItem control.  Displays the
        /// <see cref="PreferencesForm"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PreferencesForm preferencesForm = new PreferencesForm())
            {
                preferencesForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Handles the Click event of the aboutToolStripMenuItem control.  Displays the
        /// <see cref="AboutBoxForm"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the 
        /// event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm aboutBoxForm = new AboutBoxForm())
            {
                aboutBoxForm.ShowDialog(this);
            }
        }
        #endregion Event Handlers

        /// <summary>
        /// Reconstitutes the project file from the given path and populates the 
        /// application with the referenced items. 
        /// </summary>
        /// <param name="fileName">The path of the project containing the desired 
        /// project.</param>
        private void LoadProjectFile(string fileName)
        {
            JesterProjectSerializer serializer = new JesterProjectSerializer();
            JesterProject project = serializer.Deserialize(fileName);

            targetAssemblyTreeView.LoadAssemblies(new string[] { project.TargetAssemblyPath });

            _shadowedTargetAssembly = ShadowCopyAssembly(project.TargetAssemblyPath);
            _shadowedTestAssembly = ShadowCopyAssembly(project.TestAssemblyPath);
        }

        private void ClearProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = targetAssemblyTreeView.SelectedConditionals.Count;
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ClearProgressBar();
            bool locked = true;
            SetUILock(locked);

            if (Run != null)
                Run(this, new RunEventArgs(_shadowedTargetAssembly, _shadowedTestAssembly,
                    targetAssemblyTreeView.SelectedConditionals));
        }

        private void SetUILock(bool locked)
        {
            runButton.Enabled = !(locked);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            bool locked = false;
            SetUILock(locked);
        }
    }
}