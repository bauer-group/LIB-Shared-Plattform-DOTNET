using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Core.Files
{  
    public class FileProcessingException : Exception
    {
        public FileProcessingException() :
            base()
        {

        }

        public FileProcessingException(String message) :
            base(message)
        {

        }

        public FileProcessingException(String message, Exception innerException) :
            base(message, innerException)
        {

        }
    }
}
