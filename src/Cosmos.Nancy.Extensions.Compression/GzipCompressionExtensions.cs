using Cosmos.Nancy.Extensions.Compression.Internal;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions.Compression
{
    /// <summary>
    /// gzip comdression extensions
    /// </summary>
    public static class GzipCompressionExtensions
    {
        /// <summary>
        /// enable gzip compression
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="settings"></param>
        public static void EnableGzipCompression(this IPipelines pipelines, CompressionSettings settings)
        {
            GzipCompression.Settings = settings;
            pipelines.AfterRequest += GzipCompression.CheckForCompression;
        }

        /// <summary>
        /// enable gzip compression
        /// </summary>
        /// <param name="pipelines"></param>
        public static void EnableGzipCompression(this IPipelines pipelines)
        {
            EnableGzipCompression(pipelines, CompressionSettings.Default);
        }
    }
}
