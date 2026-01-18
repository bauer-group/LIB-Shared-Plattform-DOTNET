using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    /// <summary>
    /// Extension methods for Cloudinary types.
    /// </summary>
    public static class CloudinaryExtensions
    {
        /// <summary>
        /// Gets the absolute URL of a Cloudinary resource.
        /// </summary>
        /// <param name="resource">The Cloudinary resource.</param>
        /// <returns>The absolute URI string of the resource.</returns>
        public static String GetURL(this Resource resource)
        {
            return resource.Url.AbsoluteUri;
        }
    }
}
