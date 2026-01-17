using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BAUERGROUP.Shared.Core.Extensions
{
    public static class EmailHelper
    {
        public static Boolean IsEmailAddressValid(this String email)
        {
            if (String.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
