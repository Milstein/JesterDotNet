using System.IO;

namespace JesterDotNet.UI.Utility
{
    public static class Utilities
    {
        /// <summary>
        /// Copies the given assmembly to an area where it can be accessed.
        /// </summary>
        /// <param name="fileName">The assembly to be copied.</param>
        /// <returns>The path of the newly copied assembly.</returns>
        public static string ShadowCopyAssembly(string fileName)
        {
            string destination =
                Path.Combine(Path.GetTempPath(), Path.GetFileName(fileName));
            File.Copy(fileName, destination, true);

            return destination;
        }
    }
}