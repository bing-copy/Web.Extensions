using Nancy;
using Cosmos.Nancy.Extensions.Compression.Internal.Utils;


namespace Cosmos.Nancy.Extensions.Compression.Internal
{
    internal static class DeflateCompression
    {
        internal static CompressionSettings Settings { get; set; }

        internal static void CheckForCompression(NancyContext context)
        {
            if (!RequestHelper.IsDeflateCompatible(context.Request))
            {
                return;
            }

            if (context.Response.StatusCode != HttpStatusCode.OK)
            {
                return;
            }

            if (!ResponseHelper.IsCompatibleMimeType(context.Response, settings: Settings))
            {
                return;
            }

            if (ResponseHelper.ContentLengthIsTooSmall(context.Response, settings: Settings))
            {
                return;
            }

            ResponseHelper.CompressDeflateResponse(context.Response);
        }
    }
}
