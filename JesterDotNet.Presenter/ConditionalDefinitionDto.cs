using JesterDotNet.Model;
using Mono.Cecil;

namespace JesterDotNet.Presenter
{
    public class ConditionalDefinitionDto
    {
        private readonly ConditionalDefinition _conditionalDefinition;

        public ConditionalDefinitionDto(ConditionalDefinition conditionalDefinition)
        {
            _conditionalDefinition = conditionalDefinition;
        }
        public ConditionalDefinitionDto(MethodDefinition methodDefinition, int instructionNumber)
        {
            _conditionalDefinition = new ConditionalDefinition(methodDefinition, instructionNumber);
        }

        public MethodDefinition MethodDefinition
        {
            get { return _conditionalDefinition.MethodDefinition; }
        }

        public int InstructionNumber
        {
            get { return _conditionalDefinition.InstructionNumber; }
        }
    }
}