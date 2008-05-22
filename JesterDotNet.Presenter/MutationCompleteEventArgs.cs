using System;
using System.Collections.Generic;

namespace JesterDotNet.Presenter
{
    public class MutationCompleteEventArgs : EventArgs
    {
        private readonly IEnumerable<MutationDto> _mutationResults;

        public MutationCompleteEventArgs(IEnumerable<MutationDto> mutationResults)
        {
            _mutationResults = mutationResults;
        }

        public IEnumerable<MutationDto> MutationResults
        {
            get { return _mutationResults; }
        }
    }
}