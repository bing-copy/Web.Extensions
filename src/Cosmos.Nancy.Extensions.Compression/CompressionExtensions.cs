using System;
using Cosmos.Nancy.Extensions.Compression.Internal;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions.Compression
{
    public static class CompressionExtensions
    {
        public static void UseCompression(this IPipelines pipelines)
        {
            UseCompression(pipelines, null);
        }

        public static void UseCompression(this IPipelines pipelines, Action<CompressionOptions> optionAction)
        {
            var options = new CompressionOptions();
            optionAction?.Invoke(options);

            if (options.CompressionScheme == CompressionScheme.Gzip)
            {
                GzipCompression.Settings = new CompressionSettings(options);
                pipelines.AfterRequest += GzipCompression.CheckForCompression;
            }

            if (options.CompressionScheme == CompressionScheme.Deflate)
            {
                DeflateCompression.Settings = new CompressionSettings(options);
                pipelines.AfterRequest += DeflateCompression.CheckForCompression;
            }
        }
    }
}
