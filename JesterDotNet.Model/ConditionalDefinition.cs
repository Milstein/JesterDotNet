using Mono.Cecil;

namespace JesterDotNet.Model
{
    public class ConditionalDefinition
    {
        private readonly int _instructionNumber;
        private readonly MethodDefinition _methodDefinition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalDefinition"/> class.
        /// </summary>
        /// <param name="methodDefinition">The method containing the object.</param>
        /// <param name="instructionNumber">The zero-based index of the instruction statement 
        /// inside of the method body.</param>
        public ConditionalDefinition(MethodDefinition methodDefinition, int instructionNumber)
        {
            _methodDefinition = methodDefinition;
            _instructionNumber = instructionNumber;
        }

        /// <summary>
        /// Gets the <see cref="MethodDefinition"/> object representing the method containing the
        /// conditional.
        /// </summary>
        /// <value>The <see cref="MethodDefinition"/> object representing the method containing the
        /// conditional.</value>
        public MethodDefinition MethodDefinition
        {
            get { return _methodDefinition; }
        }

        /// <summary>
        /// Gets the zero-based index of the conditional statement inside of its method body.
        /// </summary>
        /// <value>The zero-based index of the conditional statement inside of its method body.</value>
        public int InstructionNumber
        {
            get { return _instructionNumber; }
        }
    }
}