using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //[AlipayBrowserOnly]
        public IActionResult AlipayOnly() => Content("哈哈哈，看到Alipay了");

        //[WeChatBrowserOnly]
        public IActionResult WeChatOnly() => Content("哈哈哈，看到微信页面了");

        //[AntiXss]
        public IActionResult AntiXssDemo(string parameters) => Content($"AntiXss: {parameters}");

        //[FrameOptions(FrameOptions = ResponseFrameOptionsType.DENY)]
        public IActionResult XFrameOptions() => Content("X-Frame-Options: OK");
    }
}
