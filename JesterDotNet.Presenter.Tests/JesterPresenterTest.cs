using System.Collections.Generic;
using JesterDotNet.Model;
using MbUnit.Framework;
using Mono.Cecil;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace JesterDotNet.Presenter.Tests
{
    /// <summary>
    /// Fully exercises the <see cref=" JesterPresenter"/> class.
    /// </summary>
    [TestFixture]
    public class JesterPresenterTest
    {
        /// <summary>
        /// Determines whether this instance can properly mutate and test a target 
        /// assembly.
        /// </summary>
        /// <remarks>I fixed this test on a plane!  Yeah!</remarks>
        [Test]
        public void Can_mutate_and_test_a_target_assembly()
        {
            string targetAssembly =
                Utility.UnpackManifestResourceStream(
                    "JesterDotNet.Presenter.Tests.SampleData.AnimalFarm.dll");
            string testAssembly =
                Utility.UnpackManifestResourceStream(
                    "JesterDotNet.Presenter.Tests.SampleData.AnimalFarm.Tests.dll");
            UnpackSupportingTestFrameworkFiles();

            MockRepository repository = new MockRepository();
            IJesterView view = repository.CreateMock<IJesterView>();
            IEventRaiser runEvent;
            IEnumerable<TestResultDto> testResults = null;
            using (repository.Record())
            {
                view.Run += null;
                runEvent = LastCall.IgnoreArguments().GetEventRaiser();
            }
            using (repository.Playback())
            {
                JesterPresenter presenter = new JesterPresenter(view);
                presenter.TestComplete +=
                    delegate(object sender, TestCompleteEventArgs e) { testResults = e.TestResults; };

                runEvent.Raise(presenter, new RunEventArgs(targetAssembly, testAssembly, GetConditionals(targetAssembly)));
            }

            int numberOfFailingTests = 0;
            foreach (TestResultDto result in testResults)
            {
                if (result is FailingTestResultDto)
                {
                    numberOfFailingTests++;
                }
            }
            Assert.AreEqual(3, numberOfFailingTests,
                "After the inversion, two of the tests should fail.");
        }

        /// <summary>
        /// Gets all conditionals found in the given assemlby.
        /// </summary>
        /// <param name="assemblyName">The assembly from which to retrieve the conditionals.</param>
        /// <returns>An enumeration of all conditionals found in the given assembly.</returns>
        private IEnumerable<ConditionalDefinition> GetConditionals(string assemblyName)
        {
            BranchingOpCodes codes = new BranchingOpCodes();
            IList<ConditionalDefinition> conditionals = new List<ConditionalDefinition>();

            AssemblyDefinition assembly = AssemblyFactory.GetAssembly(assemblyName);
            foreach (ModuleDefinition module in assembly.Modules)
                foreach (TypeDefinition type in module.Types)
                    foreach (MethodDefinition method in type.Methods)
                        if (method.HasBody)
                        {
                            for (int i = 0; i < method.Body.Instructions.Count; i++)
                                if (codes.ContainsKey(method.Body.Instructions[i].OpCode))
                                    conditionals.Add(new ConditionalDefinition(method, i));
                        }

            return conditionals;
        }

        /// <summary>
        /// The MbUnit framework needs its runtime assemblies copied locally to be used
        /// correctly.  This method will copy all of the required MbUnit files into the
        /// same directory as the sample test assemblies.
        /// </summary>
        private static void UnpackSupportingTestFrameworkFiles()
        {
            Utility.UnpackManifestResourceStream(
                "JesterDotNet.Presenter.Tests.SampleData.MbUnit.Framework.dll");
            Utility.UnpackManifestResourceStream(
                "JesterDotNet.Presenter.Tests.SampleData.QuickGraph.Algorithms.dll");
            Utility.UnpackManifestResourceStream(
                "JesterDotNet.Presenter.Tests.SampleData.QuickGraph.dll");
            Utility.UnpackManifestResourceStream(
                "JesterDotNet.Presenter.Tests.SampleData.Refly.dll");
            Utility.UnpackManifestResourceStream(
                "JesterDotNet.Presenter.Tests.SampleData.TestFu.dll");
        }
    }
}