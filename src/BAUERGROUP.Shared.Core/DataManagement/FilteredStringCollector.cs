using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BAUERGROUP.Shared.Core.DataManagement
{
    public class FilteredStringCollector
    {
        private HashSet<String> _RecordsRead;

        private String? FilterRegExPattern { get; set; }

        public FilteredStringCollector(String? filterRegEx = null)
        {
            _RecordsRead = new HashSet<String>();
            FilterRegExPattern = filterRegEx;
        }

        public Boolean Add(String entry)
        {
            //Check for Empty Data
            if (String.IsNullOrWhiteSpace(entry))
                return false;

            //Do Processing of Data
            _RecordsRead.Add(entry);

            //Fire Event
            var isMatch = FilterRegExPattern == null ? true : Regex.IsMatch(entry, FilterRegExPattern);
            OnRecordAdded(entry, isMatch);

            return true;
        }

        public Int32 AllRecordsCount => _RecordsRead.Count;
        public IEnumerable<String> AllRecords => _RecordsRead;
        public String? FirstRecord => AllRecords.FirstOrDefault();
        public String? LastRecord => AllRecords.LastOrDefault();

        public Int32 MatchingRecordsCount => (FilterRegExPattern == null) ? _RecordsRead.Count() : _RecordsRead.Count(p => Regex.IsMatch(p, FilterRegExPattern));
        public IEnumerable<String> MatchingRecords => (FilterRegExPattern == null) ? _RecordsRead : _RecordsRead.Where(p => Regex.IsMatch(p, FilterRegExPattern));
        public String? FirstMatchingRecord => MatchingRecords.FirstOrDefault();
        public String? LastMatchingRecord => MatchingRecords.LastOrDefault();

        public Boolean Contains(String entry)
        {
            return _RecordsRead.Contains(entry);
        }

        public void Clear()
        {
            _RecordsRead.Clear();
            _RecordsRead.TrimExcess();
        }

        public event EventHandler<FilteredStringCollectorEventArgs>? RecordAdded;

        protected void OnRecordAdded(FilteredStringCollectorEventArgs eventArgs) => RecordAdded?.Invoke(this, eventArgs);

        protected void OnRecordAdded(String entry, Boolean match) => RecordAdded?.Invoke(this, new FilteredStringCollectorEventArgs(entry, match));
    }
}
