using Autofac;
using Cosmos.Nancy.Extensions;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace Cosmos.Nancy.Test
{
    public class MockBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            //pipelines.UseAlipayBrowserOnly();
            //pipelines.UseWeChatBrowserOnly();
            //pipelines.UseResponseFrameOptions();
            //pipelines.UseResponseCompression(options => options.CompressionScheme = CompressionScheme.Deflate);

            //pipelines.UseCors(options =>
            //{
            //    options.AddPolicy("MyFirstCorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod());

            //    options.DefaultPolicyName = "MyFirstCorsPolicy";
            //    options.EnableGlobalCors = true;
            //    options.GlobalCorsPolicyName = "MyFirstCorsPolicy";
            //});

            pipelines.UseAntiXss(options =>
            {
                options.AddPolicy("MyFirstAntiXSSPolicy", builder => builder.WithUriQueryKeys("Parameters"));

                options.DefaultPolicyName = "MyFirstAntiXSSPolicy";
            });
        }
    }
}
