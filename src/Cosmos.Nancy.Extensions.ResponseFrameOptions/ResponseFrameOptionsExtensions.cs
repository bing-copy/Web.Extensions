using System;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Response XFrame-Options extensions
    /// </summary>
    public static class ResponseFrameOptionsExtensions
    {
        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <returns></returns>
        public static void UseResponseFrameOptions(this IPipelines pipelines)
        {
            UseResponseFrameOptions(pipelines, ResponseFramesOptionsType.DENY, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="type"></param>
        public static void UseResponseFrameOptions(this IPipelines pipelines, ResponseFramesOptionsType type)
        {
            UseResponseFrameOptions(pipelines, type, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Pipelines
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        public static void UseResponseFrameOptions(this IPipelines pipelines, ResponseFramesOptionsType type, string domain)
        {
            if(pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx => Internal.ResponseHelper.UpdateHeader(ctx, type, domain));
        }
    }
}
