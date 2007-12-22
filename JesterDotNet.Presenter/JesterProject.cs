namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Represents a composite object containing all objects necessary to perform 
    /// mutation.
    /// </summary>
    public class JesterProject
    {
        private string _targetAssemblyPath;
        private string _testAssemblyPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="JesterProject"/> class.
        /// </summary>
        public JesterProject()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JesterProject"/> class.
        /// </summary>
        /// <param name="targetAssemblyPath">The path of the target assembly.</param>
        /// <param name="testAssemblyPath">The path of the test assembly.</param>
        public JesterProject(string targetAssemblyPath, string testAssemblyPath)
        {
            _targetAssemblyPath = targetAssemblyPath;
            _testAssemblyPath = testAssemblyPath;
        }

        /// <summary>
        /// Gets the path of the target assembly.
        /// </summary>
        /// <value>The target assembly path.</value>
        public string TargetAssemblyPath
        {
            get { return _targetAssemblyPath; }
            set { _targetAssemblyPath = value; }
        }

        /// <summary>
        /// Gets the path of the test assembly.
        /// </summary>
        /// <value>The test assembly path.</value>
        public string TestAssemblyPath
        {
            get { return _testAssemblyPath; }
            set { _testAssemblyPath = value; }
        }
    }
}