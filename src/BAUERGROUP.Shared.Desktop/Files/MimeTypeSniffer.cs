using System;
using System.ComponentModel;

namespace BAUERGROUP.Shared.Desktop.Files
{
    /// <summary>
    /// Cross-platform MIME type detection based on file magic bytes.
    /// </summary>
    /// <remarks>
    /// This class has been moved to <see cref="BAUERGROUP.Shared.Core.Files.MimeTypeSniffer"/>.
    /// This forwarding class is provided for backward compatibility.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use BAUERGROUP.Shared.Core.Files.MimeTypeSniffer instead. This class will be removed in a future version.")]
    public static class MimeTypeSniffer
    {
        /// <summary>
        /// Returns the MIME type for the specified file header bytes.
        /// </summary>
        /// <param name="header">The file header bytes to examine.</param>
        /// <returns>The detected MIME type or "unknown/unknown" if not recognized.</returns>
        public static string GetMime(byte[] header)
            => Core.Files.MimeTypeSniffer.GetMime(header);

        /// <summary>
        /// Returns the MIME type for the specified file header bytes.
        /// Returns application/octet-stream instead of unknown/unknown for unrecognized types.
        /// </summary>
        /// <param name="header">The file header bytes to examine.</param>
        /// <returns>The detected MIME type.</returns>
        public static string GetMimeOrDefault(byte[] header)
            => Core.Files.MimeTypeSniffer.GetMimeOrDefault(header);
    }
}
