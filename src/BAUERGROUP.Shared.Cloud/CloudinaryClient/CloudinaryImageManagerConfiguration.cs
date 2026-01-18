using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    /// <summary>
    /// Configuration settings for connecting to a Cloudinary account.
    /// </summary>
    public class CloudinaryImageManagerConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryImageManagerConfiguration"/> class with the specified credentials.
        /// </summary>
        /// <param name="name">The Cloudinary cloud name.</param>
        /// <param name="apiKey">The Cloudinary API key.</param>
        /// <param name="apiSecret">The Cloudinary API secret.</param>
        /// <param name="project">The project folder name for organizing resources.</param>
        public CloudinaryImageManagerConfiguration(String name, String apiKey, String apiSecret, String project)
        {
            Name = name;
            APIKey = apiKey;
            APISecret = apiSecret;

            Project = project;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryImageManagerConfiguration"/> class with empty credentials.
        /// </summary>
        public CloudinaryImageManagerConfiguration()
            : this(@"", @"", @"", @"")
        {

        }

        /// <summary>
        /// Gets or sets the Cloudinary cloud name.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the Cloudinary API key.
        /// </summary>
        public String APIKey { get; set; }

        /// <summary>
        /// Gets or sets the Cloudinary API secret.
        /// </summary>
        public String APISecret { get; set; }

        /// <summary>
        /// Gets or sets the project folder name for organizing uploaded resources.
        /// </summary>
        public String Project { get; set; }
    }
}
