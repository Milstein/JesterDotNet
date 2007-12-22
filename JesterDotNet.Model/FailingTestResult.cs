namespace JesterDotNet.Model
{
    public class FailingTestResult : TestResult
    {
        private readonly string _exception;
        private readonly string _message;

        public FailingTestResult(string name, string exception, string message)
            : base(name)
        {
            _exception = exception;
            _message = message;
        }

        public string Exception
        {
            get { return _exception; }
        }

        public string Message
        {
            get { return _message; }
        }
    }
}