using System.Linq;
using Nancy;

namespace Cosmos.Nancy.Extensions.Compression.Internal.Utils
{
    internal static class RequestHelper
    {
        internal static bool IsDeflateCompatible(Request request)
        {
            return request.Headers.AcceptEncoding.Any(x => x.Contains("deflate"));
        }

        internal static bool IsGzipCompatible(Request request)
        {
            return request.Headers.AcceptEncoding.Any(x => x.Contains("gzip"));
        }
    }
}
