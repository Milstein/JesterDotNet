using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Mono.Cecil;

namespace JesterDotNet.Model
{
    public class ReportReader
    {
        private readonly ICollection<TestResult> _testResults = new List<TestResult>();
        private readonly XmlReader _reader;

        public ReportReader(Stream input)
        {
            _reader = XmlReader.Create(input);
            _reader.Read();
        }

        public IEnumerable<TestResult> TestResults
        {
            get { return _testResults; }
        }

        public void ReadReport()
        {
            ReadTestResults();
        }

        private void ReadTestResults()
        {
            while (!(_reader.EOF))
            {
                MoveToElement("run");

                if (!(_reader.EOF))
                {
                    while (_reader.NodeType == XmlNodeType.EndElement)
                        _reader.Read();
                    MoveToElement("run");

                    TestResult testResult = ReadTestResult();
                    if (testResult != null)
                        _testResults.Add(testResult);
                }
            }
        }

        private void MoveToElement(string elementName)
        {
            if ((_reader.Name == elementName) || _reader.EOF)
            {
                if (_reader.IsStartElement())
                {
                    return;
                }
                else
                {
                    _reader.Read();
                    return;
                }
            }
            else
            {
                _reader.Read();
                MoveToElement(elementName);
            }
        }

        private TestResult ReadTestResult()
        {
            try
            {
                _reader.MoveToAttribute("name");
                string name = _reader.Value;

                _reader.MoveToAttribute("result");
                string result = _reader.Value;
                if (result == "success")
                {
                    return new SurvivingMutantTestResult(name);
                }
                else // result == "failure"
                {
                    MoveToElement("exception");
                    _reader.MoveToAttribute("type");
                    string exception = _reader.Value;

                    MoveToElement("message");
                    string message = _reader.ReadElementContentAsString();

                    return new KilledMutantTestResult(name, exception, message, null);
                }
            }
            catch (InvalidOperationException )
            {
                // We were unable to read the element content.
                // There are no more tests in this file
                return null;
            }
        }
    }
}