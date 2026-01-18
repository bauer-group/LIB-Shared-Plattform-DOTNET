using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    /// <summary>
    /// Represents available currency symbols from the Fixer.io API.
    /// </summary>
    [Serializable]
    public class FixerIODataSymbols : FixerIODataBase
    {
        /// <summary>
        /// Gets or sets the dictionary of currency codes to currency names.
        /// </summary>
        [JsonPropertyName("symbols")]
        public Dictionary<String, String> Symbols { get; set; } = new();
    }
}
