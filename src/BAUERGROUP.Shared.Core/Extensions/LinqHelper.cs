using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace BAUERGROUP.Shared.Core.Extensions
{
    public static class LinqHelper
    {
        public static string XMLString(this XElement element)
        {
            if (element == null)
                return @"";

            return element.Value;
        }

        public static Decimal XMLDecimal(this XElement element)
        {
            if (element == null)
                return 0m;

            return Convert.ToDecimal(element.Value);
        }

        public static String PropertyName<T>(this Expression<Func<T, Object>> field)
        {
            var lambda = (LambdaExpression)field;
            if (lambda.Body is UnaryExpression)
            {
                var ue = (UnaryExpression)(lambda.Body);
                var me = (MemberExpression)(ue.Operand);
                return ((PropertyInfo)me.Member).Name;
            }
            else
            {
                var me = (MemberExpression)(lambda.Body);
                return ((PropertyInfo)me.Member).Name;
            }
        }
    }
}
