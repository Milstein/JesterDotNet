using System.IO;
using System.Reflection;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Provides common utility methods.
    /// </summary>
    public static class Utility
    {
        private static readonly Preferences _preferences = PreferencesManager.Preferences;

        #region Methods (Public, Static)

        /// <summary>
        /// Writes the contents of the given stream to a location on disk.
        /// </summary>
        /// <param name="source">The stream containing the contents to be written.</param>
        /// <returns>The path to the file containing the contents of the stream.</returns>
        public static string CopyToDisk(Stream source)
        {
            string path = Path.Combine(_preferences.TempPath, Path.GetRandomFileName());
            StreamWriter streamWriter = new StreamWriter(path);
            using (BinaryWriter binaryWriter = new BinaryWriter(streamWriter.BaseStream))
            {
                using (BinaryReader binaryReader = new BinaryReader(source))
                {
                    binaryReader.BaseStream.Position = 0;
                    byte[] bytes = binaryReader.ReadBytes((int)source.Length);
                    binaryWriter.Write(bytes);
                }
            }

            // TODO: Figure out why we can't close this stream
            //streamWriter.Dispose();

            return path;
        } 

        /// <summary>
        /// Locates and copies the specified manifest resource stream to disk.  The path
        /// to the newly copied resource is returned.
        /// </summary>
        /// <param name="resourceName">The name of the resource to unpack.</param>
        /// <returns>The location on disk where the resource is unpacked to.</returns>
        public static string UnpackManifestResourceStream(string resourceName)
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            Stream resourceStream = callingAssembly.GetManifestResourceStream(resourceName);

            string randomlyGeneratedFileName = CopyToDisk(resourceStream);
            string[] tokens = resourceName.Split('.');

            string newFilePath;
            if (tokens[tokens.Length - 2] == "Tests")
            {
                // This is a unit test assembly, per our naming convention
                newFilePath = Path.Combine(
                    Path.GetDirectoryName(randomlyGeneratedFileName),
                    tokens[tokens.Length - 3] + ".Tests." + tokens[tokens.Length - 1]);
            }
            else
            {
                // This is a standard logic assembly
                newFilePath = Path.Combine(
                    Path.GetDirectoryName(randomlyGeneratedFileName),
                    tokens[tokens.Length - 2] + '.' + tokens[tokens.Length - 1]);
            }

            if (File.Exists(newFilePath))
                File.Delete(newFilePath);

            File.Move(randomlyGeneratedFileName, newFilePath);

            return newFilePath;
        }

        /// <summary>
        /// Encloses the given string in quotes.  For example, 'car' becomes '"car"'.
        /// </summary>
        /// <param name="str">The string to enclose in quotes.</param>
        /// <returns>The given string, enclosed in quotes.</returns>
        public static string EncloseInQuotes(string str)
        {
            str = str.Insert(0, "\"");
            str = str.Insert(str.Length - 1, "\"");

            return str;
        }

        #endregion Methods (Public, Static)
    }
}