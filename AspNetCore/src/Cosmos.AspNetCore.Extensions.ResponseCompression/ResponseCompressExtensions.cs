using System;
using Cosmos.AspNetCore.Extensions.ResponseCompression;
using Microsoft.AspNetCore.Builder;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection {
    public static class ResponseCompressExtensions {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGzipResponseCompress(this IApplicationBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return builder.UseMiddleware<ResponseGzipCompressMiddleware>();
        }

        public static IApplicationBuilder UseMinifyResponseCompress(this IApplicationBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return builder.UseMiddleware<ResponseMinifyCompressMiddleware>();
        }
    }
}