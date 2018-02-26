using System.Text.RegularExpressions;

namespace Cosmos.AspNet.Extensions.Internal {
    internal static class MinifyHelper {
        internal static byte[] Compress(byte[] data) {
            var txt = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
            var pattern = @"\n+";

            var r = new Regex(pattern);
            var compressed = r.Replace(txt, "");

            pattern = @"\s+";
            r = new Regex(pattern);
            compressed = r.Replace(compressed, " ");

            return System.Text.Encoding.UTF8.GetBytes(compressed);
        }
    }
}