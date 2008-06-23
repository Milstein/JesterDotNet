using MbUnit.Framework;

namespace JesterDotNet.Model.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="Preferences"/> object.
    /// </summary>
    [TestFixture]
    public class PreferencesTest
    {
        private readonly string ILAsmPath =
            @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\ilasm.exe";
        private readonly string ILDasmPath =
            @"C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\ildasm.exe";
        private readonly string MbUnitPath = @"C:\Program Files\MbUnit\MbUnit.Cons.exe";
        private readonly string OutputDllFileName = @"output.dll";
        private readonly string OutputExeFileName = @"output.exe";
        private readonly string OutputILFileName = @"output.il";
        private readonly string TempPath = @"C:\WINDOWS\Temp\";

        /// <summary>
        /// Ensures that settings can be properly saved to and then reconstituted from the 
        /// on disk XML file.
        /// </summary>
        [Test]
        public void Can_save_and_reconstitute_settings_from_the_Preferences_file()
        {
            Preferences originalPreferences = PreferencesManager.Preferences;
            originalPreferences.ILDasmPath = ILDasmPath;
            originalPreferences.TempPath = TempPath;
            originalPreferences.OutputILFileName = OutputILFileName;
            originalPreferences.ILAsmPath = ILAsmPath;
            originalPreferences.OutputExeFileName = OutputExeFileName;
            originalPreferences.OutputDllFileName = OutputDllFileName;
            originalPreferences.MbUnitPath = MbUnitPath;

            PreferencesManager.Save();
            Preferences reconstitutedPreferences = PreferencesManager.Preferences;

            Assert.AreEqual(originalPreferences.ILDasmPath, reconstitutedPreferences.ILDasmPath);
            Assert.AreEqual(originalPreferences.TempPath, reconstitutedPreferences.TempPath);
            Assert.AreEqual(originalPreferences.OutputILFileName,
                            reconstitutedPreferences.OutputILFileName);
            Assert.AreEqual(originalPreferences.ILAsmPath, reconstitutedPreferences.ILAsmPath);
            Assert.AreEqual(originalPreferences.OutputExeFileName,
                            reconstitutedPreferences.OutputExeFileName);
            Assert.AreEqual(originalPreferences.OutputDllFileName,
                            reconstitutedPreferences.OutputDllFileName);
            Assert.AreEqual(originalPreferences.MbUnitPath, reconstitutedPreferences.MbUnitPath);
        }
    }
}