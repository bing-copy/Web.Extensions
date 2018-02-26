using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions.ResponseCompression {
    public class ResponseMinifyCompressMiddleware {
        private readonly RequestDelegate _next;

        public ResponseMinifyCompressMiddleware(RequestDelegate next) {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context) {
            var originalBody = context.Response.Body;
            var bufferStream = new MemoryStream();
            context.Response.Body = bufferStream;

            await _next(context);

            if (!context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.ContentType].ToString().Contains("text/html")) {
                return;
            }

            var buf = bufferStream.ToArray();
            var compresedData = Internal.MinifyHelper.Compress(buf);
            await originalBody.WriteAsync(compresedData, 0, compresedData.Length);

            context.Response.Body = originalBody;
            bufferStream.Position = 0;

        }
    }
}