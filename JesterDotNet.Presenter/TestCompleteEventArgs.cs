using System;
using System.Collections.Generic;

namespace JesterDotNet.Presenter
{
    public class TestCompleteEventArgs : EventArgs
    {
        private readonly IEnumerable<TestResultDto> _testResults;

        public TestCompleteEventArgs(IEnumerable<TestResultDto> testResults)
        {
            _testResults = testResults;
        }

        public IEnumerable<TestResultDto> TestResults
        {
            get { return _testResults; }
        }
    }
}