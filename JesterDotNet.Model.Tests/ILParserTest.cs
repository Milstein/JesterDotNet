using System.IO;
using JesterDotNet.Model;
using MbUnit.Framework;

namespace JesterDotNet.Model.Tests
{
    /// <summary>
    /// Fully exercises the <see cref="ILParser"/> object.
    /// </summary>
	[TestFixture]
	public class ILParserTest
	{
        #region Tests (Public)

        /// <summary>
        /// Determines whether this instance can successfully open a <see 
        /// cref="Stream"/> containing an IL file.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.SampleDll.il")]
        public void CanOpenILFile()
        {
            ILParser ilParser = new ILParser(ExtractResourceAttribute.Stream);

            Assert.IsNotEmpty(ilParser.Code,
                "This should be a fully populated string of IL code.");
        }

        /// <summary>
        /// Determines whether this instance can successfully invert the
        /// conditionals found in the IL code.
        /// </summary>
        [Test]
        [ExtractResource("JesterDotNet.Model.Tests.SampleData.DemoAppWithConditionals.il")]
        public void CanInvertConditionals()
        {
            string[] conditionals = { "brtrue.s", "brfalse.s" };

            ILParser parser = new ILParser(ExtractResourceAttribute.Stream);
            string originalCode = parser.Code;
            parser.InvertConditionals(conditionals);

            Assert.AreNotEqual(originalCode, parser.Code);

            // If the parser is truly inverted all of the operators to their 
            // counterparts then REinverting the newly inverted file should return
            // it back to its original state
            parser.InvertConditionals(conditionals);
            Assert.AreEqual(originalCode, parser.Code);
        } 

        #endregion Tests (Public)
	}
}

