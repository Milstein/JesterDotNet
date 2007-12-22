using System.IO;
using JesterDotNet.Model;
using MbUnit.Framework;

namespace JesterDotNet.Model.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="ILDasm"/> object.
    /// </summary>
	[TestFixture]
	public class ILDasmTest
	{
        #region Fields (Private)

        private static readonly Preferences _preferences = PreferencesManager.Preferences;
        private readonly string _expectedOutputFile = _preferences.TempPath + _preferences.OutputILFileName; 

        #endregion Fields (Private)

        #region SetUp and TearDown Methods (Public)

        /// <summary>
        /// Performs setup immediately preceeding the execution of each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            if (File.Exists(_expectedOutputFile))
            {
                File.Delete(_expectedOutputFile);
            }
        }

        /// <summary>
        /// Performs cleanup immediately following the execution of each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        } 

        #endregion SetUp and TearDown Methods (Public)

        #region Tests (Public)

        /// <summary>
        /// Determines whether this instance can successfully open a <see 
        /// cref="Stream"/> containing a valid PE file.w
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.HelloWorld.exe")]
        public void CanInvokeIldasm()
        {
            ILDasm ildasm = new ILDasm(ExtractResourceAttribute.Stream);
            ildasm.Invoke();

            FileAssert.Exists(_expectedOutputFile);
        } 

        #endregion Tests (Public)
	}
}
