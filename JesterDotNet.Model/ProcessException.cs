using System;
using System.Runtime.Serialization;

namespace JesterDotNet.Model
{
    /// <summary>
    /// Occur when there has been an error in an invoked process.
    /// </summary>
    [Serializable]
    public class ProcessException : Exception
    {
        #region Constructors (Public)

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessException"/> class.
        /// </summary>
        public ProcessException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ProcessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ProcessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ProcessException(string message, Exception innerException)
            : base(message, innerException)
        {
        } 

        #endregion Constructors (Public)
    }
}