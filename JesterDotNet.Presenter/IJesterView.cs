using System;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Acts as the main interface between the user and the presentation layer.
    /// </summary>
    public interface IJesterView
    {
        #region Events

        /// <summary>
        /// Occurs when the user has initiated the full mutation and test process.
        /// </summary>
        event EventHandler<RunEventArgs> Run;

        /// <summary>
        /// Gets a value indicating whether user has cancelled the mutation.
        /// </summary>
        /// <value><c>true</c> if the user has cancelled the mutation; otherwise, <c>false</c>.</value>
        bool CancellationPending { get; }

        #endregion Events
    }
}