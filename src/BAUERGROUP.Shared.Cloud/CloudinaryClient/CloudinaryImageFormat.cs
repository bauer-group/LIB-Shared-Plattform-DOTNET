using System;
using System.Collections.Generic;
using System.Text;

namespace BAUERGROUP.Shared.Cloud.CloudinaryClient
{
    /// <summary>
    /// Specifies the output format for Cloudinary image transformations.
    /// </summary>
    public enum CloudinaryImageFormat
    {
        /// <summary>
        /// Keep the original image format.
        /// </summary>
        Original = 0,

        /// <summary>
        /// Convert the image to PNG format.
        /// </summary>
        PNG = 1,

        /// <summary>
        /// Convert the image to JPEG format.
        /// </summary>
        JPEG = 2
    }
}
