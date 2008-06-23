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
            
            // Need to make this work for Console views 
            //IList<MutationDto> mutations = new List<MutationDto>();
            //foreach (ConditionalDefinitionDto conditional in targetAssemblyTreeView.SelectedConditionals)
            //    mutations.Add(new MutationDto(conditional, new List<TestResultDto>()));
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