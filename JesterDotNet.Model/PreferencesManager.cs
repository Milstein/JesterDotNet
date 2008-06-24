using System.IO;
using System.Xml.Serialization;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Responsible for the saving and reconstituting of <see cref="Preferences"/> files 
    /// to and from disk.
    /// </summary>
    public static class PreferencesManager
    {
        private static Preferences _preferences;
              
        /// <summary>
        /// Initializes a new instance of the <see cref="PreferencesManager"/> class.
        /// </summary>
        static PreferencesManager()
        {
            // This class will be one of the first objects to be instantiated, it should
            // make sure that the application settings directory was created on install
            if (!(Directory.Exists(Constants.JesterDotNetDirectoryName)))
                Directory.CreateDirectory(Constants.JesterDotNetDirectoryName);
        }

        /// <summary>
        /// Gets the current <see cref="Preferences"/> object in use by the system.
        /// </summary>
        /// <value>The current <see cref="Preferences"/> object in use by the system.</value>
        public static Preferences Preferences
        {
            get
            {
                if (_preferences == null)
                    _preferences = Retrieve();
                return _preferences;
            }
        }

        /// <summary>
        /// Saves the given <see cref="Preferences"/> object to a file on disk.
        /// </summary>
        public static void Save()
        {
            using (var stream = new FileStream(Constants.PreferencesFilePath, 
                FileMode.OpenOrCreate))
            {
                var preferencesSerializer = new XmlSerializer(typeof(Preferences));
                preferencesSerializer.Serialize(stream, _preferences);
            }
        }

        /// <summary>
        /// Retrieves the preferences saved on disk and returns them as a <see 
        /// cref="Preferences"/> object.  If no preference file exists on disk yet, a new 
        /// preferences file is created. 
        /// </summary>
        /// <returns>A valid <see cref="Preferences"/> object contains the settings saved
        /// from the last session.</returns>
        private static Preferences Retrieve()
        {
            Preferences reconstitutedPreferences;
            if (File.Exists(Constants.PreferencesFilePath))
            {
                using (var stream = new FileStream(Constants.PreferencesFilePath, FileMode.Open))
                {
                    var preferencesSerializer = new XmlSerializer(typeof(Preferences));
                    reconstitutedPreferences = (Preferences)preferencesSerializer.Deserialize(stream);
                }
            }
            else
            {
                reconstitutedPreferences = new Preferences();
            }
            return reconstitutedPreferences;
        }
    }
}