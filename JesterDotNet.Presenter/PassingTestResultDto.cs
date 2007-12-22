using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class PassingTestResultDto : TestResultDto
    {
        public PassingTestResultDto(PassingTestResult result) 
            : base(result)
        {
        }
    }
}