using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions.ResponseCompression {
    public class ResponseGzipCompressMiddleware {
        private readonly RequestDelegate _next;

        public ResponseGzipCompressMiddleware(RequestDelegate next) {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context) {
            if (!context.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.AcceptEncoding].ToString().Contains("gzip")) {
                await _next(context);
                return;
            }

            var originalBody = context.Response.Body;
            var bufferStream = new MemoryStream();
            context.Response.Body = bufferStream;

            await _next(context);

            context.Response.Body = originalBody;
            bufferStream.Position = 0;

            context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.ContentEncoding] = "gzip";

            using (var compressionStream = new GZipStream(originalBody, CompressionMode.Compress, false)) {
                await bufferStream.CopyToAsync(compressionStream);
            }
        }
    }
}