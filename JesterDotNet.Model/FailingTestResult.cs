namespace JesterDotNet.Model
{
    public class FailingTestResult : TestResult
    {
        private readonly string _exception;
        private readonly string _message;
        private readonly ConditionalDefinition _conditionalDefinition;

        public FailingTestResult(string name, string exception, string message, ConditionalDefinition conditionalDefinition)
            : base(name)
        {
            _exception = exception;
            _message = message;
            _conditionalDefinition = conditionalDefinition;
        }

        public string Exception
        {
            get { return _exception; }
        }

        public string Message
        {
            get { return _message; }
        }

        public ConditionalDefinition ConditionalDefinition
        {
            get { return _conditionalDefinition; }
        }
    }
}