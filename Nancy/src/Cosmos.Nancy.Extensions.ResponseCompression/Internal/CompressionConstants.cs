namespace Cosmos.Nancy.Extensions.Internal
{
    /// <summary>
    /// Response-Compression Constants
    /// </summary>
    public static class CompressionConstants
    {
        public static readonly string Gzip = "gzip";
        public static readonly string Deflate = "deflate";
        public static readonly string ContentLength = "Content-Length";
        public static readonly string ContentEncoding = "Content-Encoding";
    }
}
