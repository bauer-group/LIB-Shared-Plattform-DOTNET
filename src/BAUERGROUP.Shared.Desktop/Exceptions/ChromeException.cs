using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAUERGROUP.Shared.Desktop.Exceptions
{
    public class ChromeException : Exception
    {
        public ChromeException() 
            : base()
        {

        }

        public ChromeException(String message)
            : base(message)
        {

        }

        public ChromeException(String message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
