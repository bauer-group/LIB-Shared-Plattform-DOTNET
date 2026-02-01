using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    /// <summary>
    /// Represents errors that occur during Fixer.io API operations.
    /// </summary>
    public class FixerIOClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixerIOClientException"/> class.
        /// </summary>
        public FixerIOClientException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixerIOClientException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FixerIOClientException(String message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixerIOClientException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public FixerIOClientException(String message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
