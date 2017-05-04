using System;
using System.IO.Compression;
using System.Linq;
using Nancy;

namespace Cosmos.Nancy.Extensions.Compression.Internal.Utils
{
    internal static class ResponseHelper
    {
        internal static bool IsCompatibleMimeType(Response response, CompressionSettings settings)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return settings.MimeTypes.Any(x => x == response.ContentType || response.ContentType.StartsWith($"{x};"));
        }

        internal static bool ContentLengthIsTooSmall(Response response, CompressionSettings settings)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (response.Headers.TryGetValue("Content-Length", out string contentLength))
            {
                var length = long.Parse(contentLength);
                if (length < settings.MinimumBytes)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void CompressGzipResponse(Response response)
        {
            response.Headers["Content-Encoding"] = "gzip";

            var contents = response.Contents;
            response.Contents = responseStream =>
            {
                using (var compression = new GZipStream(responseStream, CompressionMode.Compress))
                {
                    contents(compression);
                }
            };
        }

        internal static void CompressDeflateResponse(Response response)
        {
            response.Headers["Content-Encoding"] = "deflate";

            var contents = response.Contents;
            response.Contents = responseStream =>
            {
                using (var compression = new DeflateStream(responseStream, CompressionMode.Compress))
                {
                    contents(compression);
                }
            };
        }
    }
}
