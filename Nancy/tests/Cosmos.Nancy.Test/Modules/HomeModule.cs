using System.Runtime.InteropServices.ComTypes;
using Cosmos.Nancy.Extensions;
using Nancy;

namespace Cosmos.Nancy.Test.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            //base.Before.UseAlipayBrowserOnly();
            //base.Before.UseWeChatBrowserOnly();
            //base.After.UseResponseFrameOptions();

            Get("/home/alipayonly", args => "Hello Alipay");

            Get("/home/wechatonly", args => "Hello Alipay");

            Get("home/framedemo", args => "X-Frame-Options: OK");

            Get("home/compression", args => "Compression: OK");

            Get("home/antixss", args => $"AntiXSS: {this.Request.Query["Parameters"]}");
        }
    }
}
