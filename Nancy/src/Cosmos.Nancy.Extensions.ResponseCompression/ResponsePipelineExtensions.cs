using Nancy;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Response extensions
    /// </summary>
    public static class ResponsePipelineExtensions
    {
        /// <summary>
        /// Compress response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Response WithCompression(this Response response)
        {
            return WithCompression(response, CompressionScheme.Gzip);
        }

        /// <summary>
        /// Compress response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="scheme"></param>
        /// <returns></returns>
        public static Response WithCompression(this Response response, CompressionScheme scheme)
        {
            switch (scheme)
            {
                case CompressionScheme.Gzip:
                    {
                        Internal.Utils.ResponseHelper.CompressGzipResponse(response);
                        break;
                    }

                case CompressionScheme.Deflate:
                    {
                        Internal.Utils.ResponseHelper.CompressDeflateResponse(response);
                        break;
                    }

                default:
                    {
                        Internal.Utils.ResponseHelper.CompressGzipResponse(response);
                        break;
                    }
            }

            return response;
        }
    }
}
