using System.Web.Mvc;
using Cosmos.AspNet.Extensions;

namespace Cosmos.AspNet.Test.Controllers
{
    //[FrameOptions(FrameOptions = ResponseFrameOptionsType.DENY)]
    [AntiXss]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[AlipayBrowserOnly]
        public ActionResult AlipayOnly() => Content("哈哈哈，看到Alipay了");

        //[WeChatBrowserOnly]
        public ActionResult WeChatOnly() => Content("哈哈哈，看到微信页面了");

        //[Compression]
        public ActionResult CompressionDemo() => Content("Compression balabala~");

        //[FrameOptions(FrameOptions = ResponseFrameOptionsType.DENY)]
        public ActionResult FrameOptions() => Content("X-Frame-Options: OK");

        //[Cors]
        public ActionResult CorsDemo() => Content("CORS: OK");

        //[ValidateInput(false)]

        public ActionResult AntiXssDemo(string parameters) //=> Content($"AntiXSS: {parameters.ToSafeHtmlString()}");
        {
            var p1 = parameters;
            var p2 = HttpContext.Request["parameters"];

            return Content($"AntiXSS: {p2}");
        }
    }
}