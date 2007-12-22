using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class TestResultDto
    {
        private readonly TestResult _result;

        public TestResultDto(TestResult result)
        {
            _result = result;
        }

        public string Name
        {
            get { return _result.Name; }
        }
    }
}