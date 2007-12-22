namespace JesterDotNet.Model
{
    /// <summary>
    /// Encapsulates the invocation and management of an xUnit test runner.
    /// </summary>
    internal interface ITestRunner
    {
        /// <summary>
        /// Invokes the test runner on the given assembly. 
        /// </summary>
        /// <param name="testAssembly">The assembly to test.</param>
        void Invoke(string testAssembly);
    }
}