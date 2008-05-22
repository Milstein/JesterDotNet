using System;
using System.IO;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Provides commonly used constants in use throughout the model.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// An error occurred in the underlying process.
        /// </summary>
        public static int UnderlyingProcessException = -3;

        /// <summary>
        /// The directory path where user specific settings for Jester.NET are stored.
        /// </summary>
        public static string JesterDotNetDirectoryName = 
            Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Jester.NET");

        /// <summary>
        /// The location on disk where the Jester preferences information is stored.
        /// </summary>
        public static string PreferencesFilePath =
            Path.Combine(JesterDotNetDirectoryName, "Settings.jester");
    }
}