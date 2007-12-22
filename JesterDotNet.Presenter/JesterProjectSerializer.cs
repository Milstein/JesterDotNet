using System.Xml;
using System.Xml.Serialization;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Handles serialization of the Jester project files to and from disk.
    /// </summary>
    public class JesterProjectSerializer
    {
        private readonly XmlSerializer _xmlSerializer =
            new XmlSerializer(typeof (JesterProject));

        /// <summary>
        /// Serializes the specified project to the given location on disk.
        /// </summary>
        /// <param name="project">The project to be serialized.</param>
        /// <param name="path">The path where the project will be serialized to.</param>
        public void Serialize(JesterProject project, string path)
        {
            XmlWriter writer = XmlWriter.Create(path);
            _xmlSerializer.Serialize(writer, project);
            writer.Close();
        }

        /// <summary>
        /// Deserializes the project file found at the given path into a valid instance
        /// of <see cref="JesterProject"/>.
        /// </summary>
        /// <param name="path">The path of the project file.</param>
        /// <returns>A valid instance of <see cref="JesterProject"/> reconstituted from
        /// the given project file.</returns>
        public JesterProject Deserialize(string path)
        {
            XmlReader reader = XmlReader.Create(path);
            JesterProject project = (JesterProject)_xmlSerializer.Deserialize(reader);
            reader.Close();

            return project;
        }
    }
}