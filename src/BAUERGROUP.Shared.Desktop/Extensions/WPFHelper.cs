using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BAUERGROUP.Shared.Desktop.Extensions
{
    public static class WPFHelper
    {
        public static T? CloneWPFObject<T>(this T? wpfObject) where T : class
        {
            if (wpfObject == null)
                return null;

            Object? cloned = null;

            using (var stream = new MemoryStream())
            {
                XamlWriter.Save(wpfObject, stream);
                stream.Seek(0, SeekOrigin.Begin);
                cloned = XamlReader.Load(stream);
            }

            if (cloned is T)
                return (T)cloned;

            return null;
        }
    }
}
