using System.Collections.Generic;

namespace Cosmos.Nancy.Extensions.Compression
{
    /// <summary>
    /// Compression options
    /// </summary>
    public class CompressionOptions
    {
        /// <summary>
        /// Compression Scheme
        /// </summary>
        public CompressionScheme CompressionScheme { get; set; } = CompressionScheme.Gzip;

        /// <summary>
        /// Minimum bytes
        /// </summary>
        public int MinimumBytes { get; set; } = 4096;

        /// <summary>
        /// Mime types
        /// </summary>
        public IList<string> MimeTypes { get; set; } = new List<string>
        {
            "text/plain",
            "text/html",
            "text/xml",
            "text/css",
            "application/json",
            "application/x-javascript",
            "application/atom+xml",
        };
    }
}
