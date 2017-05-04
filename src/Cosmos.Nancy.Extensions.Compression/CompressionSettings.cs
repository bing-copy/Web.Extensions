using System.Collections.Generic;

namespace Cosmos.Nancy.Extensions.Compression
{
    /// <summary>
    /// Compression settingss
    /// </summary>
    public class CompressionSettings
    {
        /// <summary>
        /// minimum bytes
        /// </summary>
        public int MinimumBytes { get; set; } = 4096;

        /// <summary>
        /// mime types
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

        /// <summary>
        /// get default compression settings
        /// </summary>
        public static CompressionSettings Default => new CompressionSettings();
    }
}
