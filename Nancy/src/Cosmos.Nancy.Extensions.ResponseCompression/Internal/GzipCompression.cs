﻿using Nancy;
using Cosmos.Nancy.Extensions.Internal.Utils;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class GzipCompression
    {
        internal static CompressionOptions Options { get; set; }

        internal static void CheckForCompression(NancyContext context)
        {
            if (!RequestHelper.IsGzipCompatible(context.Request))
            {
                return;
            }

            if (context.Response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }

            if (!ResponseHelper.IsCompatibleMimeType(context.Response, options: Options))
            {
                return;
            }

            if (ResponseHelper.ContentLengthIsTooSmall(context.Response, options: Options))
            {
                return;
            }

            ResponseHelper.CompressGzipResponse(context.Response);
        }
    }
}
