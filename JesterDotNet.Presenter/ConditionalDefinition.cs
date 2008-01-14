using System;
using Mono.Cecil;

namespace JesterDotNet.Presenter
{
    public class ConditionalDefinition
    {
        private readonly int _conditionalNumber;
        private readonly MethodDefinition _methodDefinition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalDefinition"/> class.
        /// </summary>
        /// <param name="methodDefinition">The method containing the object.</param>
        /// <param name="conditionalNumber">The zero-based index of the conditional statement 
        /// inside of the method.</param>
        public ConditionalDefinition(MethodDefinition methodDefinition, int conditionalNumber)
        {
            _methodDefinition = methodDefinition;
            _conditionalNumber = conditionalNumber;
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
        /// Gets the zero-based index of the conditional statement inside of its method.
        /// </summary>
        /// <value>The zero-based index of the conditional statement inside of its method.</value>
        public int ConditionalNumber
        {
            get { return _conditionalNumber; }
        }
    }
}