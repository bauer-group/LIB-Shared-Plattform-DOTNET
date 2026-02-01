using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    /// <summary>
    /// Represents exchange rate data from the Fixer.io API.
    /// </summary>
    [Serializable]
    public class FixerIODataRates : FixerIODataBase
    {
        /// <summary>
        /// Gets or sets the Unix timestamp when the rates were collected.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public Int32 Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the base currency code for the rates.
        /// </summary>
        [JsonPropertyName("base")]
        public String Base { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the exchange rates.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of currency codes to exchange rates.
        /// </summary>
        [JsonPropertyName("rates")]
        public Dictionary<String, Decimal> Rates { get; set; } = new();
    }
}
