namespace JesterDotNet.Model
{
    /// <summary>
    /// Saves all of the users preferences and path information to disk.
    /// </summary>
    public class Preferences
    {
        private string _ILAsmPath;
        private string _ILDasmPath;
        private string _MbUnitPath;
        private string _OutputDllFileName;
        private string _OutputExeFileName;
        private string _OutputILFileName;
        private string _TempPath;

        /// <summary>
        /// Gets or sets the path to the ILDasm executable.
        /// </summary>
        /// <value>the path to the ILDasm executable.</value>
        public string ILDasmPath
        {
            get { return _ILDasmPath; }
            set { _ILDasmPath = value; }
        }

        /// <summary>
        /// Gets or sets the path to the users temp directory, or where they would like
        /// temporary files stored.
        /// </summary>
        /// <value>the path to the users temp directory, or where they would like
        /// temporary files stored.</value>
        public string TempPath
        {
            get { return _TempPath; }
            set { _TempPath = value; }
        }

        /// <summary>
        /// Gets or sets the name of the temp IL file which will be generated.
        /// </summary>
        /// <value>The name of the temp IL file which will be generated.</value>
        public string OutputILFileName
        {
            get { return _OutputILFileName; }
            set { _OutputILFileName = value; }
        }

        /// <summary>
        /// Gets or sets the name of the temp EXE file which will be generated.
        /// </summary>
        /// <value>the name of the temp EXE file which will be generated.</value>
        public string OutputExeFileName
        {
            get { return _OutputExeFileName; }
            set { _OutputExeFileName = value; }
        }

        /// <summary>
        /// Gets or sets the path to the ILAsm executable.
        /// </summary>
        /// <value>The path to the ILAsm executable.</value>
        public string ILAsmPath
        {
            get { return _ILAsmPath; }
            set { _ILAsmPath = value; }
        }

        /// <summary>
        /// Gets or sets the name of the temp DLL file which will be generated.
        /// </summary>
        /// <value>The name of the temp DLL file which will be generated.</value>
        public string OutputDllFileName
        {
            get { return _OutputDllFileName; }
            set { _OutputDllFileName = value; }
        }

        /// <summary>
        /// Gets or sets the path to the MbUnit console runner.
        /// </summary>
        /// <value>The path to the MbUnit console runner.</value>
        public string MbUnitPath
        {
            get { return _MbUnitPath; }
            set { _MbUnitPath = value; }
        }
    }
}