using System;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Anti-Xss Configure Extensions
    /// </summary>
    public static class AntiXssConfigureExtensions
    {
        /// <summary>
        /// Use AntiXss Module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <returns></returns>
        public static IPipelines UseAntiXss(this IPipelines pipelines)
        {
            return UseAntiXss(pipelines, null);
        }

        /// <summary>
        /// Use AntiXss Module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IPipelines UseAntiXss(this IPipelines pipelines, Action<AntiXssOptions> optionsAction)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            var options = new AntiXssOptions();
            optionsAction?.Invoke(options);

            Internal.InternalAntiXssManager.SetPolicyMap(options);

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                Internal.AntiXssCoreHelper.DoAntiXssForRequest(ctx);

                return null;
            });

            return pipelines;
        }


    }
}
