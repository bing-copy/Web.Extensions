using System;
using Cosmos.Nancy.Extensions.Compression.Internal;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions.Compression
{
    /// <summary>
    /// Compression extensions
    /// </summary>
    public static class CompressionExtensions
    {
        /// <summary>
        /// Use Compression Module
        /// </summary>
        /// <param name="pipelines"></param>
        public static void UseCompression(this IPipelines pipelines)
        {
            UseCompression(pipelines, null);
        }

        /// <summary>
        /// Use Compression Module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionAction"></param>
        public static void UseCompression(this IPipelines pipelines, Action<CompressionOptions> optionAction)
        {
            var options = new CompressionOptions();
            optionAction?.Invoke(options);

            if (options.CompressionScheme == CompressionScheme.Gzip)
            {
                GzipCompression.Options = options;
                pipelines.AfterRequest += GzipCompression.CheckForCompression;
            }

            if (options.CompressionScheme == CompressionScheme.Deflate)
            {
                DeflateCompression.Options = options;
                pipelines.AfterRequest += DeflateCompression.CheckForCompression;
            }
        }
    }
}
