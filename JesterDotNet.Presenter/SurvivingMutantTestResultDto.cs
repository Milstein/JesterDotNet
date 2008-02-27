using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class SurvivingMutantTestResultDto : TestResultDto
    {
        public SurvivingMutantTestResultDto(SurvivingMutantTestResult result, MutationDto mutation) 
            : base(result, mutation)
        {
        }
    }
}