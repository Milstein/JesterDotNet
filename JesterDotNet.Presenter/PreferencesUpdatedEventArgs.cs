using System;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Contains the new information that the user has just updated.
    /// </summary>
    public class PreferencesUpdatedEventArgs : EventArgs
    {
        private readonly string _ILAsmPath;
        private readonly string _ILDasmPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferencesUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="ilAsmPath">The path of the ILAsm executable.</param>
        /// <param name="ilDasmPath">The path of the ILDasm executable.</param>
        public PreferencesUpdatedEventArgs(string ilAsmPath, string ilDasmPath)
        {
            _ILAsmPath = ilAsmPath;
            _ILDasmPath = ilDasmPath;
        }

        /// <summary>
        /// Gets the path of the ILAsm executable.
        /// </summary>
        /// <value>The path of the ILAsm executable.</value>
        public string ILAsmPath
        {
            get { return _ILAsmPath; }
        }

        /// <summary>
        /// Gets the path of the ILDasm executable.
        /// </summary>
        /// <value>The path of the ILDasm executable.</value>
        public string ILDasmPath
        {
            get { return _ILDasmPath; }
        }
    }
}