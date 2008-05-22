using System;
using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class KilledMutantTestResultDto : TestResultDto
    {
        private readonly KilledMutantTestResult _result;
        private readonly MutationDto _mutation;

        public KilledMutantTestResultDto(KilledMutantTestResult result, MutationDto mutation) 
            : base(result, mutation)
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

        public ConditionalDefinitionDto ConditionalDefinition
        {
            get { return new ConditionalDefinitionDto(_result.ConditionalDefinition); }
        }
    }
}