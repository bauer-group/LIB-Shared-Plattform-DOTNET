using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    /// <summary>
    /// Base class for Fixer.io API response data.
    /// </summary>
    [Serializable]
    public class FixerIODataBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the API request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public Boolean Success { get; set; }

        /// <summary>
        /// Gets or sets the error information if the request failed.
        /// </summary>
        [JsonPropertyName("error")]
        public ErrorInfo? Error { get; set; }

        /// <summary>
        /// Contains error details from the Fixer.io API.
        /// </summary>
        public class ErrorInfo
        {
            /// <summary>
            /// Gets or sets the error code.
            /// </summary>
            [JsonPropertyName("code")]
            public Int32 Code { get; set; }

            /// <summary>
            /// Gets or sets the error type identifier.
            /// </summary>
            [JsonPropertyName("type")]
            public String Type { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the human-readable error description.
            /// </summary>
            [JsonPropertyName("info")]
            public String Info { get; set; } = string.Empty;
        }
    }
}