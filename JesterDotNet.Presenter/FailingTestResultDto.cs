using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class FailingTestResultDto : TestResultDto
    {
        private readonly FailingTestResult _result;

        public FailingTestResultDto(FailingTestResult result) 
            : base(result)
        {
            _result = result;
        }

        public string Exception
        {
            get { return _result.Exception; }   
        }

        public string Message
        {
            get { return _result.Message; }
        }
    }
}