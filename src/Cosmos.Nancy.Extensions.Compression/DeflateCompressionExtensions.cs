using Cosmos.Nancy.Extensions.Compression.Internal;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions.Compression
{
    /// <summary>
    /// deflate comdression extensions
    /// </summary>
    public static class DeflateCompressionExtensions
    {
        /// <summary>
        /// enable deflate compression
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="settings"></param>
        public static void EnableDeflateCompression(this IPipelines pipelines, CompressionSettings settings)
        {
            GzipCompression.Settings = settings;
            pipelines.AfterRequest += DeflateCompression.CheckForCompression;
        }

        /// <summary>
        /// enable deflate compression
        /// </summary>
        /// <param name="pipelines"></param>
        public static void EnableDeflateCompression(this IPipelines pipelines)
        {
            EnableDeflateCompression(pipelines, CompressionSettings.Default);
        }
    }
}
