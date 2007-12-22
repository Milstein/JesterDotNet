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
        /// Occurs when the user has requested to cancel the process.
        /// </summary>
        event EventHandler<EventArgs> Cancel; 

        #endregion Events
    }
}