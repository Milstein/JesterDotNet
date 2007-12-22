using System.IO;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Provides a gateway to the underlying ILAsm implementation.
    /// </summary>
    public class ILAsm
    {
        #region Fields (Private)

        private readonly string _inputFile;
        private readonly Preferences _preferences = PreferencesManager.Preferences;

        #endregion Fields (Private)

        #region Constructor (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="ILAsm"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public ILAsm(Stream source)
        {
            // ILAsm can only use files on disk, so we have to write this out to
            // disk first
            _inputFile = Utility.CopyToDisk(source);
        }

        #endregion Constructor (Public)

        #region Methods (Public)

        /// <summary>
        /// Invokes the underlying instance of ILAsm.
        /// </summary>
        /// <exception cref="ProcessException">Occurs when the underlying process has returned
        /// an error code.</exception>
        public void Invoke()
        {
            string arguments = _inputFile;
            if ((File.ReadAllText(_inputFile).Contains(".entrypoint")))
            {
                // This is an exe
                arguments += " " + @"/output=" + _preferences.TempPath + _preferences.OutputExeFileName;
            }
            else
            {
                // This is a DLL
                arguments += " /dll " + @"/output=" + _preferences.TempPath + _preferences.OutputDllFileName;
            }

            ProcessInvoker invoker = new ProcessInvoker(_preferences.ILAsmPath, arguments);
            int returnCode = invoker.Start();

            if (returnCode == Constants.UnderlyingProcessException)
                throw new ProcessException(Exceptions.ProcessException);
        }

        #endregion Methods (Public)
    }
}