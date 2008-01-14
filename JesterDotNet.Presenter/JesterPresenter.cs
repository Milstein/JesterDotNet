using System;
using System.Collections.Generic;
using System.IO;
using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Acts as the primary middle layer between the UI and the business objects.
    /// </summary>
    public class JesterPresenter
    {
        #region Fields (Private)

        private readonly IJesterView _view;
        private readonly Preferences _preferences = PreferencesManager.Preferences;

        #endregion Fields (Private)

        #region Events (Private)

        private event EventHandler<TestCompleteEventArgs> _testComplete;

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

        public event EventHandler<TestCompleteEventArgs> TestComplete
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
            IList<TestResultDto> resultDtos = new List<TestResultDto>();
            foreach (ConditionalDefinition conditionalDefinition in e.SelectedConditionals)
            {
                string ilFile = Path.Combine(_preferences.TempPath, _preferences.OutputILFileName);
                string outputFile = GetOutputAssemblyFileName(e.InputAssembly);

                // Disassemble the target assembly
                using (FileStream stream = new FileStream(e.InputAssembly, FileMode.Open))
                {
                    ILDasm ilDasm = new ILDasm(stream);
                    ilDasm.Invoke();
                }
                // Invert the conditionals in that file
                // TODO: This code currently invokes all conditionals found, we need to adjust this
                // to invoke only the current selected conditional.
                // We'll just repeat this code once for each selected conditional...yeah, this will
                // take a while, but mutation testers are expected to take a while
                using (FileStream stream = new FileStream(ilFile, FileMode.Open))
                {
                    string[] conditionals = {"brtrue.s"};
                    ILParser parser = new ILParser(stream);
                    parser.InvertConditionals(conditionals);

                    // Reassemble the mutated file into an assembly
                    string invertedConditionals = Path.GetTempFileName();
                    using (FileStream fileStream = new FileStream(invertedConditionals,
                                                                  FileMode.OpenOrCreate))
                    {
                        foreach (char theChar in parser.Code)
                            fileStream.WriteByte((byte)theChar);

                        ILAsm ilAsm = new ILAsm(fileStream);
                        ilAsm.Invoke();
                    }
                }

                // Replace the original target assembly with the mutated assembly
                File.Delete(e.InputAssembly);
                File.Copy(outputFile, e.InputAssembly);

                // Run the unit tests again, this time against the mutated assembly
                MbUnitTestRunner runner = new MbUnitTestRunner();
                runner.Invoke(e.TestAssembly);

                foreach (TestResult result in runner.TestResults)
                    if (result is PassingTestResult)
                        resultDtos.Add(new PassingTestResultDto((PassingTestResult)result));
                    else
                        resultDtos.Add(new FailingTestResultDto((FailingTestResult)result));
            }

            if (_testComplete != null)
                _testComplete(this, new TestCompleteEventArgs(resultDtos));
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

        /// <summary>
        /// Extracts the common IL conditional operations from the given stream.
        /// </summary>
        /// <param name="ilStream">The IL stream containing the conditional operations.
        /// </param>
        /// <returns>An array of the conditional operations found in the given IL stream.
        /// </returns>
        public string[] ExtractConditionals(Stream ilStream)
        {
            // TODO: This may not be needed - we seem to only be using it from a unit test
            string[] foundConditionals;
            using (StreamReader reader = new StreamReader(ilStream))
            {
                string[] conditionals = {"brtrue.s", "brfalse.s"};
                string ilString = reader.ReadToEnd();
                string[] tokens = ilString.Split(new char[] {' '},
                                                 StringSplitOptions.RemoveEmptyEntries);

                foundConditionals = 
                    Array.FindAll(tokens,
                        delegate(string tok)
                            {
                                 return ((tok == conditionals[0]) || (tok == conditionals[1]));
                            });
            }
            return foundConditionals;
        }
    }
}