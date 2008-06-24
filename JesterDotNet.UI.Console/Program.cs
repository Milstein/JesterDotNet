using JesterDotNet.Presenter;

namespace JesterDotNet.UI.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleView = new JesterConsoleView();
            var presenter = new JesterPresenter(consoleView);
            presenter.MutationComplete += OnPresenterMutationComplete;
            presenter.TestComplete += OnPresenterTestComplete;
         
            consoleView.RunMutation(args[0], args[1]);
        }

        static void OnPresenterTestComplete(object sender, System.EventArgs e)
        {
        }

        static void OnPresenterMutationComplete(object sender, MutationCompleteEventArgs e)
        {
        }
    }
}