using System;
using Cosmos.Nancy.Extensions.Internal;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Response compression extensions
    /// </summary>
    public static class ResponseCompressionExtensions
    {
        /// <summary>
        /// Use Compression Module
        /// </summary>
        /// <param name="pipelines"></param>
        public static void UseResponseCompression(this IPipelines pipelines)
        {
            UseResponseCompression(pipelines, null);
        }

        /// <summary>
        /// Use Compression Module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionAction"></param>
        public static void UseResponseCompression(this IPipelines pipelines, Action<CompressionOptions> optionAction)
        {
            if(pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

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
