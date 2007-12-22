using System.IO;
using System.Reflection;
using MbUnit.Framework;

namespace JesterDotNet.Model.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="MbUnitTestRunner"/> class.
    /// </summary>
    [TestFixture]
    public class MbUnitTestRunnerTest
    {
        /// <summary>
        /// Ensures that this instance can successfully run unit tests.
        /// </summary>
        [Test]
        public void Can_invoke_unit_test_runner()
        {
            // MbUnit needs a file that ends with DLL so we have to extract this manually.
            // Utility.CopyTo Disk() returns us a randomly generated extension
            Assembly assembly = Assembly.GetExecutingAssembly();
            string path =
                Utility.CopyToDisk(
                    assembly.GetManifestResourceStream(
                        "JesterDotNet.Model.Tests.SampleData.SampleDll.Tests.dll"));
            string renamedPath = Path.ChangeExtension(path, ".dll");
            File.Move(path, renamedPath);

            ITestRunner runner = new MbUnitTestRunner();
            runner.Invoke(renamedPath);
        }

        /// <summary>
        /// Ensures that the failing test information returned in the XML report from 
        /// MbUnit.Console.exe can be presented in a user friendly way.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.SampleMbUnitReport.xml")]
        public void Can_sucessfully_process_the_failing_tests()
        {
            ReportReader reader = new ReportReader(ExtractResourceAttribute.Stream);
            reader.ReadReport();

            // Count the resulting entries
            int failingTests = 0;
            foreach (TestResult test in reader.TestResults)
                failingTests++;

            Assert.AreEqual(4, failingTests);
        }
    }
}