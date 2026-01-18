using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    /// <summary>
    /// Specifies the type of content stored in Cloudinary.
    /// </summary>
    public enum CloudinaryContentType
    {
        /// <summary>
        /// Image content (photos, graphics, etc.).
        /// </summary>
        Image = 0,

        /// <summary>
        /// Video content.
        /// </summary>
        Video = 1
    }
}
