using System;
using Nancy;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// WeChat browser limited extensions
    /// </summary>
    public static class WeChatBrowserLimitedExtensions
    {
        /// <summary>
        /// Use wechat browser filter to a Nancy Bootstrap
        /// </summary>
        /// <param name="pipelines"></param>
        public static void UseWeChatBrowserOnly(this IPipelines pipelines)
        {
            UseWeChatBrowserOnly(pipelines, null);
        }

        /// <summary>
        /// Use wechat browser filter to a Nancy Bootstrap
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionAction"></param>
        public static void UseWeChatBrowserOnly(this IPipelines pipelines, Action<WeChatBrowserOnlyOptions> optionAction)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            var options = new WeChatBrowserOnlyOptions();
            optionAction?.Invoke(options);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (!Internal.RequestHelper.IsWeChatBrowser(ctx.Request))
                {
                    return Internal.ResponseHelper.DoWeChatBrowserOnlyOption(ctx, options);
                }

                return null;
            });
        }

        /// <summary>
        /// Use wechat browser filter in a NancyController/NancyModule
        /// </summary>
        /// <param name="pipeline"></param>
        /// <returns></returns>
        public static BeforePipeline UseWeChatBrowserOnly(this BeforePipeline pipeline)
        {
            return UseWeChatBrowserOnly(pipeline, null);
        }

        /// <summary>
        /// Use wechat browser filter in a NancyController/NancyModule
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public static BeforePipeline UseWeChatBrowserOnly(this BeforePipeline pipeline, Action<WeChatBrowserOnlyOptions> optionAction)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            var options = new WeChatBrowserOnlyOptions();
            optionAction?.Invoke(options);

            pipeline.AddItemToEndOfPipeline(ctx =>
            {
                if (!Internal.RequestHelper.IsWeChatBrowser(ctx.Request))
                {
                    return Internal.ResponseHelper.DoWeChatBrowserOnlyOption(ctx, options);
                }

                return null;
            });

            return pipeline;
        }
    }
}
