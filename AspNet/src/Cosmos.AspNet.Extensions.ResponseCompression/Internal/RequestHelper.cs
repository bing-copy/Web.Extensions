using System.Web;

namespace Cosmos.AspNet.Extensions.Internal {
    internal static class RequestHelper {
        public static CompressionScheme GetPreferredEncoding(HttpRequestBase request) {
            return GetCompressionScheme(request.Headers[CompressionConstants.AcceptEncoding].ToLower());
        }

        public static CompressionScheme GetPreferredEncoding(HttpRequest request) {
            return GetCompressionScheme(request.Headers[CompressionConstants.AcceptEncoding].ToLower());
        }

        private static CompressionScheme GetCompressionScheme(string acceptableEncoding) {
            if (string.IsNullOrEmpty(acceptableEncoding)) {
                return CompressionScheme.Identity;
            }

            if (acceptableEncoding.Contains(CompressionConstants.Gzip)) {
                return CompressionScheme.Gzip;
            }

            if (acceptableEncoding.Contains(CompressionConstants.Deflate)) {
                return CompressionScheme.Deflate;
            }

            return CompressionScheme.Identity;
        }

        public static bool IsTextHtml(HttpRequestBase request) {
            var header = request.Headers[CompressionConstants.ContentType];
            return header.Contains("text/html");
        }
    }


}