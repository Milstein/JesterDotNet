using System.Collections.Generic;

namespace JesterDotNet.Presenter
{
    public class MutationDto
    {
        private readonly ConditionalDefinitionDto _conditional;
        private readonly IList<TestResultDto> _testResults;

        public MutationDto(ConditionalDefinitionDto conditional, IList<TestResultDto> testResults)
        {
            _conditional = conditional;
            _testResults = testResults;
        }
        
        public ConditionalDefinitionDto Conditional
        {
            get { return _conditional; }
        }

        public IList<TestResultDto> TestResults
        {
            get { return _testResults; }
        }
    }
}