using System;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Acts as a holding cell for all operators that are capable of being 
    /// flipped and perfoms the actual flipping. 
    /// </summary>
    public static class OperatorInversions
    {
        #region Methods (Public, Static)

        /// <summary>
        /// Inverts the given operator to its counterpart.
        /// </summary>
        /// <param name="op">The operator to flip.</param>
        /// <returns>The counterpart of the given operator.</returns>
        public static string Invert(string op)
        {
            string invertedOp;
            switch (op)
            {
                case "brtrue.s":
                    invertedOp = "brfalse.s";
                    break;
                case "brfalse.s":
                    invertedOp = "brtrue.s";
                    break;
                default:
                    throw new InvalidOperationException("You've requested an unflippable op");
            }
            return invertedOp;
        } 

        #endregion Methods (Public, Static)
    }
}