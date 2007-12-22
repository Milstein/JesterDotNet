using System.IO;
using JesterDotNet.Model;
using MbUnit.Framework;

namespace JesterDotNet.Model.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="ILAsm"/> object.
    /// </summary>
    [TestFixture]
    public class ILAsmTest
    {
        #region Fields (Private)

        private static readonly Preferences _preferences = PreferencesManager.Preferences;
        private readonly string _expectedOutputExeFile = _preferences.TempPath +
                                     _preferences.OutputExeFileName;
        private readonly string _expectedOutputDllFile = _preferences.TempPath +
                                     _preferences.OutputDllFileName; 

        #endregion Fields (Private)

        #region SetUp and TearDown Methods (Public)

        /// <summary>
        /// Performs setup immediately preceeding each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            if (File.Exists(_expectedOutputExeFile))
            {
                File.Delete(_expectedOutputExeFile);
            }
            if (File.Exists(_expectedOutputDllFile))
            {
                File.Delete(_expectedOutputDllFile);
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
        /// Determines whether this instance can successfully compile an IL 
        /// file when the IL represents a DLL file.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.SampleDll.il")]
        public void CanCompileTheILWhenTheILIsALibrary()
        {
            ILAsm asm = new ILAsm(ExtractResourceAttribute.Stream);
            asm.Invoke();

            FileAssert.Exists(_expectedOutputDllFile);
        }

        /// <summary>
        /// Determines whether this instance can successfully compile the mutated
        /// IL created by the <see cref="ILParser"/> when the IL represents an
        /// EXE file.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.SampleExe_Mutated.il")]
        public void CanCompileTheMutatedILWhenTheILIsAnExecutable()
        {
            ILAsm asm = new ILAsm(ExtractResourceAttribute.Stream);
            asm.Invoke();

            FileAssert.Exists(_expectedOutputExeFile);
        }

        #endregion Tests (Public)
    }
}