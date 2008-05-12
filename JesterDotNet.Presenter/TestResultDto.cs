using System;
using JesterDotNet.Model;

namespace JesterDotNet.Presenter
{
    public class TestResultDto
    {
        private readonly TestResult _result;
        private readonly MutationDto _mutation;

        public TestResultDto(TestResult result, MutationDto mutation)
        {
            _result = result;
            _mutation = mutation;
        }

        public string Name
        {
            get { return _result.Name; }
        }

        public TestResult Result
        {
            get { return _result; }
        }
    }
}