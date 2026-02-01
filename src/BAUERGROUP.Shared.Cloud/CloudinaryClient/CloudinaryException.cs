using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    /// <summary>
    /// Represents errors that occur during Cloudinary operations.
    /// </summary>
    public class CloudinaryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a default InternalServerError status.
        /// </summary>
        public CloudinaryException()
            : base()
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CloudinaryException(String message)
            : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public CloudinaryException(String message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a specified HTTP status code and message.
        /// </summary>
        /// <param name="statusCode">The HTTP status code returned by Cloudinary.</param>
        /// <param name="message">The message that describes the error.</param>
        public CloudinaryException(HttpStatusCode statusCode, String message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a specified HTTP status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code returned by Cloudinary.</param>
        public CloudinaryException(HttpStatusCode statusCode)
            : base()
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryException"/> class with a status code, message, and inner exception.
        /// </summary>
        /// <param name="statusCode">The HTTP status code returned by Cloudinary.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public CloudinaryException(HttpStatusCode statusCode, String message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the Cloudinary error.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
