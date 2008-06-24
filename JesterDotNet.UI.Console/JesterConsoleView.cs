using System;
using JesterDotNet.Presenter;

namespace JesterDotNet.UI.Console
{
    internal class JesterConsoleView : IJesterView
    {
        /// <summary>
        /// Occurs when the user has initiated the full mutation and test process.
        /// </summary>
        public event EventHandler<RunEventArgs> Run;

        /// <summary>
        /// Gets a value indicating whether user has cancelled the mutation.
        /// </summary>
        /// <value><c>true</c> if the user has cancelled the mutation; otherwise, <c>false</c>.</value>
        public bool CancellationPending
        {
            get { return false; }
        }

        public void RunMutation(string targetAssembly, string testAssembly)
        {
            if (Run != null)
                Run(this, new RunEventArgs(targetAssembly, testAssembly, null));
        }
    }
}