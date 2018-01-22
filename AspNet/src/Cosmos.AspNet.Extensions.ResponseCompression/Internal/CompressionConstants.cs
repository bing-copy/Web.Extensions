namespace Cosmos.AspNet.Extensions.Internal
{
    /// <summary>
    /// Response-Compression Constants
    /// </summary>
    public static class CompressionConstants
    {
        /// <summary>
        /// Gzip
        /// </summary>
        public static readonly string Gzip = "gzip";

        /// <summary>
        /// Deflate
        /// </summary>
        public static readonly string Deflate = "deflate";

        /// <summary>
        /// Accept-Encoding
        /// </summary>
        public static readonly string AcceptEncoding = "Accept-Encoding";

        /// <summary>
        /// Content-Length
        /// </summary>
        public static readonly string ContentLength = "Content-Length";

        /// <summary>
        /// Content-Encoding
        /// </summary>
        public static readonly string ContentEncoding = "Content-Encoding";
    }
}
