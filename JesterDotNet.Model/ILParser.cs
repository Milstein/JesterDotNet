using System.IO;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Responsible for the parsing of the actual IL file into a series of usable
    /// tokens.
    /// </summary>
    public class ILParser
    {
        #region Fields (Private)

        private readonly StreamReader _streamReader;
        private string _code;

        #endregion Fields (Private)

        #region Constructor (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="ILParser"/> class.
        /// </summary>
        /// <param name="source">A stream containing the IL to parse.</param>
        public ILParser(Stream source)
        {
            _streamReader = new StreamReader(source);
            _code = _streamReader.ReadToEnd();
        }

        #endregion Constructor (Public)

        #region Methods (Public)

        /// <summary>
        /// Gets string containing the code of the IL file.
        /// </summary>
        /// <value>A string containing the code of the IL file.</value>
        public string Code
        {
            get { return _code; }
        }

        /// <summary>
        /// Locates the given conditionals in the IL code and replaces them with
        /// their appropriate counterparts.
        /// </summary>
        /// <param name="operators">The operators to be inverted.</param>
        public void InvertConditionals(string[] operators)
        {
            foreach (string op in operators)
            {
                _code = _code.Replace(op, OperatorInversions.Invert(op));
            }
        }

        #endregion Methods (Public)
    }
}