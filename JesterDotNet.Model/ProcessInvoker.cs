using System.Diagnostics;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Encapsulates the ability to synchronously invoke a process and evaluate its return code.
    /// </summary>
    internal class ProcessInvoker
    {
        #region Fields (Private)

        private readonly ProcessStartInfo _info; 

        #endregion Fields (Private)

        #region Constructors (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessInvoker"/> class intended
        /// to run silently with minimal visuals.
        /// </summary>
        /// <param name="path">The path of the process to invoke.</param>
        /// <param name="arguments">The arguments to supply to the process being invoked.</param>
        public ProcessInvoker(string path, string arguments)
        {
            _info = new ProcessStartInfo(path);
            _info.Arguments = arguments;

            _info.UseShellExecute = false;
            _info.CreateNoWindow = true;

#if DEBUG
            _info.RedirectStandardError = true;
            _info.RedirectStandardOutput = true;
#endif


        } 

        #endregion Constructors (Public)

        #region Methods (Public)

        /// <summary>
        /// Starts this instance synchronously.  This method will block until the process
        /// completes.
        /// </summary>
        /// <returns>Returns a numeric value indicating the state of the completed process.
        /// </returns>
        public int Start()
        {
            var process = new Process { StartInfo = _info };
            process.Start();
            process.WaitForExit();

#if DEBUG
#pragma warning disable 168
            var stdError = process.StandardError.ReadToEnd();
            var stdOutput = process.StandardOutput.ReadToEnd();
#pragma warning restore 168
#endif

            return process.ExitCode;
        } 

        #endregion Methods (Public)
    }
}