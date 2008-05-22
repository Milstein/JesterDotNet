using System;
using System.IO;
using JesterDotNet.Model;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Acts as the primary middle layer between the UI and the business objects.
    /// </summary>
    public class JesterPresenter
    {
        #region Fields (Private)
        private readonly Preferences _preferences = PreferencesManager.Preferences;
        private readonly IJesterView _view;
        #endregion Fields (Private)

        #region Events (Private)
        private event EventHandler<MutationCompleteEventArgs> _mutationComplete;
        private event EventHandler<EventArgs> _testComplete;
        #endregion Events (Private)

        #region Constructors (Public)
        /// <summary>
        /// Initializes a new instance of the <see cref="JesterPresenter"/> class.
        /// </summary>
        /// <param name="view">The view that the presenter is interacting with.</param>
        public JesterPresenter(IJesterView view)
        {
            _view = view;
            _view.Run += OnViewRun;
        }
        #endregion Constructors (Public)

        #region Events (Public)
        public event EventHandler<MutationCompleteEventArgs> MutationComplete
        {
            add { _mutationComplete += value; }
            remove { _mutationComplete -= value; }
        }

        public event EventHandler<EventArgs> TestComplete
        {
            add { _testComplete += value; }
            remove { _testComplete -= value; }
        }
        #endregion Events (Public)

        #region Event Handlers (Private)
        /// <summary>
        /// Called when <see cref="IJesterView.Run"/> event is fired.  Performs the 
        /// mutation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="JesterDotNet.Presenter.RunEventArgs"/> instance 
        /// containing the event data.</param>
        private void OnViewRun(object sender, RunEventArgs e)
        {
            // TODO: We can probably tighten up this for loop if we take a closer look at this loop
            BranchingOpCodes opCodes = new BranchingOpCodes();
            foreach (MutationDto mutation in e.SelectedMutations)
            {
                // If the user has cancelled this since the last test, bail out
                if (_view.CancellationPending)
                    break;

                string outputFile = GetOutputAssemblyFileName(e.InputAssembly);

                for (int i = 0; i < mutation.Conditional.MethodDefinition.Body.Instructions.Count; i++)
                {
                    Instruction instruction = mutation.Conditional.MethodDefinition.Body.Instructions[i];
                    if (opCodes.Contains(instruction.OpCode))
                    {
                        if (i == mutation.Conditional.InstructionNumber)
                        {
                            instruction.OpCode = opCodes.Invert(instruction.OpCode);
                        }
                    }
                }

                // Replace the original target assembly with the mutated assembly
                File.Delete(e.InputAssembly);
                AssemblyFactory.SaveAssembly(mutation.Conditional.MethodDefinition.DeclaringType.Module.Assembly, outputFile);
                File.Copy(outputFile, e.InputAssembly);

                // Run the unit tests again, this time against the mutated assembly
                MbUnitTestRunner runner = new MbUnitTestRunner();
                runner.Invoke(e.TestAssembly);

                foreach (TestResult result in runner.TestResults)
                    if (result is SurvivingMutantTestResult)
                        mutation.TestResults.Add(new SurvivingMutantTestResultDto((SurvivingMutantTestResult)result, mutation));

                    else
                        mutation.TestResults.Add(new KilledMutantTestResultDto((KilledMutantTestResult)result, mutation));

                if (_testComplete != null)
                    _testComplete(this, EventArgs.Empty);
            }

            if (_mutationComplete != null)
                _mutationComplete(this, new MutationCompleteEventArgs(e.SelectedMutations));
        }

        /// <summary>
        /// Returns the name of the output file, taking into account the extension of the
        /// given input assembly name.
        /// </summary>
        /// <param name="inputAssemblyName">The name of the input assembly.  The extension
        /// of this assembly will determine the extension of the output assembly.</param>
        /// <returns>The name of the output assembly as determined by the extension of
        /// the given input assemlby.</returns>
        /// <exception cref="ApplicationException">An unknown extension was found on the
        /// <paramref name="inputAssemblyName"/>.</exception>
        private string GetOutputAssemblyFileName(string inputAssemblyName)
        {
            string outputFileName;
            if (string.Compare(Path.GetExtension(inputAssemblyName), ".DLL", true) == 0)
                outputFileName = Path.Combine(_preferences.TempPath, _preferences.OutputDllFileName);
            else if (string.Compare(Path.GetExtension(inputAssemblyName), ".EXE", true) == 0)
                outputFileName = Path.Combine(_preferences.TempPath, _preferences.OutputExeFileName);
            else
                throw new ApplicationException("Unknown input assembly exception encountered.");

            return outputFileName;
        }
        #endregion Event Handlers (Private)
    }
}