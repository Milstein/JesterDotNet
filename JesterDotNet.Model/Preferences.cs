using System;
using System.IO;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Saves all of the users preferences and path information to disk.
    /// </summary>
    public class Preferences
    {
        public Preferences()
        {
            // Default the preferences based on best guesses
            TempPath = Path.GetTempPath();
            OutputILFileName = "Temp.il";
            OutputExeFileName = "Temp.exe";
            OutputDllFileName = "Temp.dll";
            MbUnitPath = @"C:\Program Files\MbUnit\bin";
        }

        /// <summary>
        /// Gets or sets the path to the ILDasm executable.
        /// </summary>
        /// <value>the path to the ILDasm executable.</value>
        public string ILDasmPath { get; set; }

        /// <summary>
        /// Gets or sets the path to the users temp directory, or where they would like
        /// temporary files stored.
        /// </summary>
        /// <value>the path to the users temp directory, or where they would like
        /// temporary files stored.</value>
        public string TempPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the temp IL file which will be generated.
        /// </summary>
        /// <value>The name of the temp IL file which will be generated.</value>
        public string OutputILFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the temp EXE file which will be generated.
        /// </summary>
        /// <value>the name of the temp EXE file which will be generated.</value>
        public string OutputExeFileName { get; set; }

        /// <summary>
        /// Gets or sets the path to the ILAsm executable.
        /// </summary>
        /// <value>The path to the ILAsm executable.</value>
        public string ILAsmPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the temp DLL file which will be generated.
        /// </summary>
        /// <value>The name of the temp DLL file which will be generated.</value>
        public string OutputDllFileName { get; set; }

        /// <summary>
        /// Gets or sets the path to the MbUnit console runner.
        /// </summary>
        /// <value>The path to the MbUnit console runner.</value>
        public string MbUnitPath { get; set; }
    }
}