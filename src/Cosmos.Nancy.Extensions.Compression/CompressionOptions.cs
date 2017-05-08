using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Nancy.Extensions.Compression
{
    public class CompressionOptions
    {
        public CompressionScheme CompressionScheme { get; set; } = CompressionScheme.Gzip;

        public int MinimumBytes { get; set; } = 4096;

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
