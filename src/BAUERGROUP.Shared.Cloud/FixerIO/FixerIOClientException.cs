using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    public class FixerIOClientException : Exception
    {
        public FixerIOClientException()
            : base()
        {

        }

        public FixerIOClientException(String message)
            : base(message)
        {

        }

        public FixerIOClientException(String message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
