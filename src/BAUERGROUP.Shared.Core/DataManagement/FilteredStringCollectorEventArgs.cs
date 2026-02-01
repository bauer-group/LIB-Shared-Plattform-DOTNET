using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Core.DataManagement
{
    public class FilteredStringCollectorEventArgs : EventArgs
    {
        public FilteredStringCollectorEventArgs(String entry, Boolean match)
        {
            Entry = entry;
            Match = match;
        }

        public String Entry { get; set; }
        public Boolean Match { get; set; }
    }
}
