using System;
using System.Collections.Generic;
using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class TestCompleteEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCompleteEventArgs"/> class.
        /// </summary>
        /// <param name="testResults">The results of the test.</param>
        public TestCompleteEventArgs(IEnumerable<TestResult> testResults)
        {
            TestResults = testResults;
        }

        /// <summary>
        /// Gets or sets the test results.
        /// </summary>
        /// <value>The test results.</value>
        public IEnumerable<TestResult> TestResults { get; set; }
    }
}