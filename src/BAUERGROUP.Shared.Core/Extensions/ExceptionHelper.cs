using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAUERGROUP.Shared.Core.Extensions
{
    public static class ExceptionHelper
    {
        public static string GetExceptionDetails(this Exception exception)
        {
            var exceptionProperties = exception.GetType().GetProperties();

            var fieldList = exceptionProperties
                             .Select(exceptionProperty => new
                             {
                                 Name = exceptionProperty.Name,
                                 Value = exceptionProperty.GetValue(exception, null)
                             })
                             .Select(x => String.Format(
                                 "{0} = {1}",
                                 x.Name,
                                 x.Value != null ? x.Value.ToString() : String.Empty
                             ));

            var typeName = $"Type = {exception.GetType().Name}";
            return typeName + Environment.NewLine + String.Join(Environment.NewLine, fieldList);
        }
    }
}
