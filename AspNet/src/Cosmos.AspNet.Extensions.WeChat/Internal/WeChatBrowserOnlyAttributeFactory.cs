namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class WeChatBrowserOnlyAttributeFactory
    {
        public static WeChatBrowserOnlyAttribute Create(WeChatBrowserOnlyOptions options)
        {
            var ret = new WeChatBrowserOnlyAttribute
            {
                Message = options.Message,
                RedirectUrl = options.RedirectUrl
            };

            return ret;
        }
    }
}
