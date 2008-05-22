using System;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Provides an functionality contract for the various implementations of preferences forms.
    /// </summary>
    public interface IPreferencesView
    {
        /// <summary>
        /// Occurs when the user has updated the preferences.
        /// </summary>
        event EventHandler<PreferencesUpdatedEventArgs> PreferencesUpdated;
    }
}