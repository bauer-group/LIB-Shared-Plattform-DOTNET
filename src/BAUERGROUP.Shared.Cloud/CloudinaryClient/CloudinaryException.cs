using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    public class CloudinaryException : Exception
    {
        public CloudinaryException()
            : base()
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public CloudinaryException(String message)
            : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public CloudinaryException(String message, Exception innerException)
            : base(message, innerException)
        {

        }

        public CloudinaryException(HttpStatusCode statusCode, String message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public CloudinaryException(HttpStatusCode statusCode)
            : base()
        {
            StatusCode = statusCode;
        }

        public CloudinaryException(HttpStatusCode statusCode, String message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
