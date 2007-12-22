using System;
using System.IO;
using System.Windows.Forms;
using JesterDotNet.Presenter;

namespace JesterDotNet.Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (EnsurePreferencesArePopulated())
            {
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// Checks to see if the settings file has been created on disk.  If it hasn't then we 
        /// assume that this is a new installation and show the preferences dialog to the user
        /// so that they can set their preferences before continuing.
        /// </summary>
        /// <returns><c>true</c> if the user has successfully created their preferences; otherwise
        /// <c>true</c>.</returns>
        private static bool EnsurePreferencesArePopulated()
        {
            if (!(File.Exists(Constants.PreferencesPath)))
            {
                using (PreferencesForm preferencesForm = new PreferencesForm())
                {
                    if (preferencesForm.ShowDialog() == DialogResult.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }
    }
}