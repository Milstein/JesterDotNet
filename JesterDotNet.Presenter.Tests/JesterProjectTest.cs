using System.IO;
using JesterDotNet.Model;
using JesterDotNet.Presenter;
using MbUnit.Framework;

namespace JesterDotNet.Presenter.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="JesterProject"/> class.
    /// </summary>
    [TestFixture]
    public class JesterProjectTest
    {
        /// <summary>
        /// Ensures that a Jester project file can successfully be saved to disk.
        /// </summary>
        [Test]
        public void Can_save_project_to_disk()
        {
            JesterProject project = 
                new JesterProject("targetAssembly.dll", "testAssembly.dll");

            string savedFile = Path.GetTempFileName();

            JesterProjectSerializer serializer = new JesterProjectSerializer();
            serializer.Serialize(project, savedFile);

            FileAssert.Exists(savedFile);
        }

        /// <summary>
        /// Ensures that a valid instance of <see cref="JesterProject"/> can be created
        /// from a valid project file.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Presenter.Tests.SampleData.SampleProject.jst")]
        public void Can_reconstitute_a_saved_project_from_disk()
        {
            string sampleProjectFile = 
                Utility.CopyToDisk(ExtractResourceAttribute.Stream);

            JesterProjectSerializer serializer = new JesterProjectSerializer();
            JesterProject project = serializer.Deserialize(sampleProjectFile);

            Assert.AreEqual(project.TargetAssemblyPath, "AnimalFarm.dll", 
                "The expected value for the target assembly was not found.");
            Assert.AreEqual(project.TestAssemblyPath, "AnimalFarm.Tests.dll", 
                "The expected value for the test assembly was not found.");
        }

        /// <summary>
        /// Ensures that the target assembly path can be properly saved in and retrieved 
        /// from the project.
        /// </summary>
        [Test]
        public void Can_save_target_assembly_path_in_project_file()
        {
            JesterProject project = 
                new JesterProject("targetAssembly.dll", "testAssembly.dll");

            Assert.AreEqual("targetAssembly.dll", project.TargetAssemblyPath);
        }

        /// <summary>
        /// Ensures that the test assembly path can be properly saved in and retrieved 
        /// from the project.
        /// </summary>
        [Test]
        public void Can_save_test_assembly_path_in_project_file()
        {
            JesterProject project =
                new JesterProject("targetAssembly.dll", "testAssembly.dll");

            Assert.AreEqual("testAssembly.dll", project.TestAssemblyPath);
        }
    }
}