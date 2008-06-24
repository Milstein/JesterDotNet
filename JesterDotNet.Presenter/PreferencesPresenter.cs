using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Provides an intermediary layer between the UI and the model when dealing with application
    /// preferences.
    /// </summary>
    public class PreferencesPresenter
    {
        private readonly IPreferencesView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferencesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PreferencesPresenter(IPreferencesView view)
        {
            _view = view;
            _view.PreferencesUpdated += OnViewPreferencesUpdated;
        }

        /// <summary>
        /// Called when when the user has updated the preferences in the UI.  Allows the 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PreferencesUpdatedEventArgs"/> instance containing the 
        /// event data.</param>
        private static void OnViewPreferencesUpdated(object sender, PreferencesUpdatedEventArgs e)
        {
            // TODO: Update additional user settings here
            PreferencesManager.Save();
        }
    }
}