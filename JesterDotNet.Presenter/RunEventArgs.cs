using System;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Encapsulates all information necessary to run the process.
    /// </summary>
    public class RunEventArgs : EventArgs
    {
        #region Fields (Private)

        private readonly string _inputAssembly;
        private readonly string _testAssembly;

        #endregion Fields (Private)

        #region Constructors (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="RunEventArgs"/> class.
        /// </summary>
        /// <param name="inputAssembly">The assembly to mutate.</param>
        /// <param name="testAssembly">The assembly which contains the tests to run.</param>
        public RunEventArgs(string inputAssembly, string  testAssembly)
        {
            _inputAssembly = inputAssembly;
            _testAssembly = testAssembly;
        }

        #endregion Constructors (Public)

        #region Properties (Public)

        /// <summary>
        /// Gets the assembly to mutate.
        /// </summary>
        /// <value>The assembly to mutate.</value>
        public string InputAssembly
        {
            get { return _inputAssembly; }
        }

        /// <summary>
        /// Gets the assembly which contains the tests.
        /// </summary>
        /// <value>The assembly which contains the tests.</value>
        public string TestAssembly
        {
            get { return _testAssembly; }
        }

        #endregion Properties (Public)
    }
}