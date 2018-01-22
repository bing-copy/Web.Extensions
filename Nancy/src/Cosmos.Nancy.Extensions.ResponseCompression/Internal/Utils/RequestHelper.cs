using System.Linq;
using Nancy;

namespace Cosmos.Nancy.Extensions.Internal.Utils
{
    internal static class RequestHelper
    {
        internal static bool IsDeflateCompatible(Request request)
        {
            return request.Headers.AcceptEncoding.Any(x => x.Contains(CompressionConstants.Deflate));
        }

        internal static bool IsGzipCompatible(Request request)
        {
            return request.Headers.AcceptEncoding.Any(x => x.Contains(CompressionConstants.Gzip));
        }
    }
}
