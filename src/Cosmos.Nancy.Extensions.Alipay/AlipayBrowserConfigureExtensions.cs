using System;
using Nancy;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Alipay browser limited extensions
    /// </summary>
    public static class AlipayBrowserConfigureExtensions
    {
        /// <summary>
        /// Use alipay browser filter to a Nancy Bootstrap
        /// </summary>
        /// <param name="pipelines"></param>
        public static IPipelines UseAlipayBrowserOnly(this IPipelines pipelines)
        {
            return UseAlipayBrowserOnly(pipelines, null);
        }

        /// <summary>
        /// Use alipay browser filter to a Nancy Bootstrap
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionAction"></param>
        public static IPipelines UseAlipayBrowserOnly(this IPipelines pipelines, Action<AlipayBrowserOnlyOptions> optionAction)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            var options = new AlipayBrowserOnlyOptions();
            optionAction?.Invoke(options);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (!Internal.RequestHelper.IsAlipayBrowser(ctx.Request))
                {
                    return Internal.ResponseHelper.DoAlipayBrowserOnlyOption(ctx, options);
                }

                return null;
            });

            return pipelines;
        }

        /// <summary>
        /// Use alipay browser filter in a NancyController/NancyModule
        /// </summary>
        /// <param name="pipeline"></param>
        /// <returns></returns>
        public static BeforePipeline UseAlipayBrowserOnly(this BeforePipeline pipeline)
        {
            return UseAlipayBrowserOnly(pipeline, null);
        }

        /// <summary>
        /// Use alipay browser filter in a NancyController/NancyModule
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public static BeforePipeline UseAlipayBrowserOnly(this BeforePipeline pipeline, Action<AlipayBrowserOnlyOptions> optionAction)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            var options = new AlipayBrowserOnlyOptions();
            optionAction?.Invoke(options);

            pipeline.AddItemToEndOfPipeline(ctx =>
            {
                if (!Internal.RequestHelper.IsAlipayBrowser(ctx.Request))
                {
                    return Internal.ResponseHelper.DoAlipayBrowserOnlyOption(ctx, options);
                }

                return null;
            });

            return pipeline;
        }
    }
}
