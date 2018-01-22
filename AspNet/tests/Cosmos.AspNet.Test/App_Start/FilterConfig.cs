using System.Web.Mvc;
using Cosmos.AspNet.Extensions;

namespace Cosmos.AspNet.Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //filters.AddAlipayBrowserFilter();
            //filters.AddWeChatBrowserFilter();

            //filters.AddResponseCompressionFilter();
            //filters.AddResponseFrameOptionsFilter();

            //filters.AddCorsFilter(options =>
            //{
            //    options.AddPolicy("MyFirstCorsFilter", builder => builder.AllowAnyOrigin());
            //    options.AddPolicy("MySecondCorsFilter", builder => builder.AllowAnyMethod());

            //    options.DefaultPolicyName = "MyFirstCorsFilter";
            //    options.EnableGlobalCors = true;
            //    //options.GlobalCorsPolicyName = "MyFirstCorsFilter";
            //});

            filters.AddAntiXssFilter(options =>
            {
                options.AddPolicy("MyFirstAntiXssPolicy", builder => builder.WithUriAttributes("parameters"));
                options.DefaultPolicyName = "MyFirstAntiXssPolicy";
            });
        }
    }
}
