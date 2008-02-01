using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace JesterDotNet.Presenter
{
    /// <summary>
    /// Provides a repository of all <see cref="OpCode">OpCodes</see> and their associated inverted <see cref="OpCode"/>.
    /// </summary>
    public class BranchingOpCodes : Dictionary<OpCode, OpCode>
    {
        // TODO: This could be a pretty expensive class to create...should we make this a monostate?

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchingOpCodes"/> class.
        /// </summary>
        public BranchingOpCodes()
        {
            PopulateBranchingOpCodes();
        }

        /// <summary>
        /// Determines whether the current object contains the given <see cref="opCode"/>.
        /// </summary>
        /// <param name="opCode">The OpCode to search for.</param>
        /// <returns>
        /// <c>true</c> if the current object contains the given OpCode; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(OpCode opCode)
        {
            return ContainsKey(opCode);
        }

        /// <summary>
        /// Returns the inversion of the given <see cref="opCode"/>.
        /// </summary>
        /// <param name="opCode">The OpCode to invert.</param>
        /// <returns>The inversion of the given <see cref="opCode"/>.</returns>
        public OpCode Invert(OpCode opCode)
        {
            return this[opCode];
        }

        /// <summary>
        /// Populates our collection of branching OpCodes so that we know which Op codes we're 
        /// looking for and what they're corresponding counterpart is.
        /// </summary>
        private void PopulateBranchingOpCodes()
        {
            Add(OpCodes.Beq, OpCodes.Bne_Un);
            Add(OpCodes.Beq_S, OpCodes.Bne_Un_S);
            Add(OpCodes.Bge, OpCodes.Blt);
            Add(OpCodes.Bge_S, OpCodes.Blt_S);
            Add(OpCodes.Bge_Un, OpCodes.Bgt_Un);
            Add(OpCodes.Bge_Un_S, OpCodes.Bgt_Un_S);
            Add(OpCodes.Bgt, OpCodes.Ble);
            Add(OpCodes.Bgt_S, OpCodes.Ble_S);
            Add(OpCodes.Bgt_Un, OpCodes.Ble_Un);
            Add(OpCodes.Bgt_Un_S, OpCodes.Ble_Un_S);
            Add(OpCodes.Ble, OpCodes.Bgt);
            Add(OpCodes.Ble_S, OpCodes.Bgt_S);
            Add(OpCodes.Ble_Un, OpCodes.Bgt_Un);
            Add(OpCodes.Ble_Un_S, OpCodes.Bgt_Un_S);
            Add(OpCodes.Blt, OpCodes.Bge);
            Add(OpCodes.Blt_S, OpCodes.Bge_S);
            Add(OpCodes.Blt_Un, OpCodes.Bge_Un);
            Add(OpCodes.Blt_Un_S, OpCodes.Bge_Un_S);
            Add(OpCodes.Bne_Un, OpCodes.Beq);
            Add(OpCodes.Bne_Un_S, OpCodes.Beq_S);
            Add(OpCodes.Brfalse, OpCodes.Brtrue);
            Add(OpCodes.Brfalse_S, OpCodes.Brtrue_S);
            Add(OpCodes.Brtrue, OpCodes.Brfalse);
            Add(OpCodes.Brtrue_S, OpCodes.Brfalse_S);
        }
        
    }
}