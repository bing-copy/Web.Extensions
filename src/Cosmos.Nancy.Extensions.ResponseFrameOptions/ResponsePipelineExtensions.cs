using System;
using Nancy;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Nancy Response Extensions
    /// </summary>
    public static class ResponsePipelineExtensions
    {
        /// <summary>
        /// Add a head to the response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Response WithResponseFrameOptions(this Response response)
        {
            return WithResponseFrameOptions(response, ResponseFramesOptionsType.DENY, string.Empty);
        }

        /// <summary>
        /// Add a head to the response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Response WithResponseFrameOptions(this Response response, ResponseFramesOptionsType type)
        {
            return WithResponseFrameOptions(response, type, string.Empty);
        }

        /// <summary>
        /// Add a head to the response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static Response WithResponseFrameOptions(this Response response, ResponseFramesOptionsType type, string domain)
        {
            if(response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            return Internal.ResponseHelper.UpdateHeader(response, type, domain);
        }
    }
}
