using System;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Response XFrame-Options extensions
    /// </summary>
    public static class ResponseFrameConfigureExtensions
    {
        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <returns></returns>
        public static IPipelines UseResponseFrameOptions(this IPipelines pipelines)
        {
            return UseResponseFrameOptions(pipelines, ResponseFrameOptionsType.DENY, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="type"></param>
        public static IPipelines UseResponseFrameOptions(this IPipelines pipelines, ResponseFrameOptionsType type)
        {
            return UseResponseFrameOptions(pipelines, type, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        public static IPipelines UseResponseFrameOptions(this IPipelines pipelines, ResponseFrameOptionsType type, string domain)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx => Internal.ResponseHelper.UpdateHeader(ctx, type, domain));

            return pipelines;
        }
    }
}
