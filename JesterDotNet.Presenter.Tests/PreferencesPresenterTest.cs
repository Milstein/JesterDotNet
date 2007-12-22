using JesterDotNet.Model;
using MbUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace JesterDotNet.Presenter.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="PreferencesPresenter"/> object.
    /// </summary>
    public class PreferencesPresenterTest
    {
        /// <summary>
        /// Ensures that the <see cref="PreferencesPresenter"/> can retrieve the path of ILDasm and 
        /// ILAsm from the <see cref="IPreferencesView"/>.
        /// </summary>
        [Test]
        public void Can_retrieve_ILAsm_and_ILDasm_path()
        {
            string ilAsmPath = @"C:\ILAsm.exe";
            string ilDasmPath = @"C:\ILDasm.exe";
            MockRepository repository = new MockRepository();
            IPreferencesView preferencesView = repository.CreateMock<IPreferencesView>();
            IEventRaiser viewPreferencesUpdatedEventRaiser;
            using (repository.Record())
            {
                preferencesView.PreferencesUpdated += null;
                LastCall.IgnoreArguments();
                viewPreferencesUpdatedEventRaiser = LastCall.GetEventRaiser();
            }
            using (repository.Playback())
            {
                PreferencesPresenter preferencesPresenter =
                    new PreferencesPresenter(preferencesView);
                Preferences preferences = PreferencesManager.Preferences;

                // Wipe out the preferences
                preferences.ILAsmPath = string.Empty;
                preferences.ILDasmPath = string.Empty;
                PreferencesManager.Save();

                // When the preferences presenter handles the update event, it should update the
                // Preferences object as well
                viewPreferencesUpdatedEventRaiser.Raise(this,
                                                        new PreferencesUpdatedEventArgs(ilAsmPath,
                                                                                        ilDasmPath));

                Assert.AreEqual(ilAsmPath, preferences.ILAsmPath,
                                "The expected ILAsm path was not retrieved from the presenter.");
                Assert.AreEqual(ilDasmPath, preferences.ILDasmPath,
                                "The expected ILDasm path was not retrieved from the presenter.");
            }
            repository.VerifyAll();
        }
    }
}