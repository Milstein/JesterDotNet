using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Encapsulates the invocation of the MbUnit test runner.
    /// </summary>
    public class MbUnitTestRunner : ITestRunner
    {
        // TODO: This should be a directly inside of a Jester specific directory
        private static readonly string _reportFolder = Path.GetTempPath();
        private IEnumerable<TestResult> _testResults;
        readonly Preferences _preferences = PreferencesManager.Preferences;

        public IEnumerable<TestResult> TestResults
        {
            get
            {
                if (_testResults == null)
                {
                    _testResults = GetTestResults();
                }
                return _testResults;
            }
        }

        #region ITestRunner Members

        /// <summary>
        /// Invokes the test runner.
        /// </summary>
        public void Invoke(string testAssembly)
        {
            var invoker = new ProcessInvoker(_preferences.MbUnitPath,
                string.Format(Thread.CurrentThread.CurrentUICulture,
                @"/report-type:XML /report-folder:{0} {1}", 
                Utility.EncloseInQuotes(_reportFolder), 
                Utility.EncloseInQuotes(testAssembly)));

            int returnCode = invoker.Start();

            if (returnCode == Constants.UnderlyingProcessException)
                throw new ProcessException(Exceptions.ProcessException);
        }

        #endregion

        private IEnumerable<TestResult> GetTestResults()
        {
            var reportPath = GetMostRecentReport();
            
            IEnumerable<TestResult> testResults;
            using (var fileStream = new FileStream(reportPath, FileMode.Open))
            {
                var reader = new ReportReader(fileStream);
                reader.ReadReport();
                testResults = reader.TestResults;
            }

            return testResults;
        }

        private string GetMostRecentReport()
        {
            var tempDirectory = new DirectoryInfo(_reportFolder);
            var reportFiles = tempDirectory.GetFiles("mbunit*");

            var newestReport = reportFiles[0];
            foreach (var reportFile in reportFiles)
            {
                // Whichever report file was created most recently is the report file we want
                newestReport = (reportFile.CreationTime > newestReport.CreationTime) ?
                    reportFile : newestReport;
            }
            return newestReport.FullName;
        }
    }
}