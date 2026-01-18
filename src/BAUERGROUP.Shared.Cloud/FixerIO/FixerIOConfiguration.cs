using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.FixerIO
{
    /// <summary>
    /// Configuration settings for connecting to the Fixer.io API.
    /// </summary>
    public class FixerIOConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixerIOConfiguration"/> class.
        /// </summary>
        /// <param name="apiKey">The Fixer.io API key.</param>
        /// <param name="timeout">Request timeout in milliseconds. Defaults to 3000ms.</param>
        /// <param name="proxy">Optional web proxy for requests.</param>
        public FixerIOConfiguration(String apiKey, Int32 timeout = 3 * 1000, IWebProxy? proxy = null)
        {
            APIKey = apiKey;
            Proxy = proxy;
            Timeout = timeout;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixerIOConfiguration"/> class with empty credentials.
        /// </summary>
        public FixerIOConfiguration()
            : this(@"")
        {

        }

        /// <summary>
        /// Gets the Fixer.io API key.
        /// </summary>
        public String APIKey { get; private set; }

        /// <summary>
        /// Gets the request timeout in milliseconds.
        /// </summary>
        public Int32 Timeout { get; private set; }

        /// <summary>
        /// Gets the optional web proxy for API requests.
        /// </summary>
        public IWebProxy? Proxy { get; private set; }

        /// <summary>
        /// Gets the Fixer.io API base URL.
        /// </summary>
        public String URL => @"http://data.fixer.io/api/";
    }
}
