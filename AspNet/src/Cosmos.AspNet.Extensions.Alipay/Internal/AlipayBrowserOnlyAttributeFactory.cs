namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class AlipayBrowserOnlyAttributeFactory
    {
        public static AlipayBrowserOnlyAttribute Create(AlipayBrowserOnlyOptions options)
        {
            var ret = new AlipayBrowserOnlyAttribute
            {
                Message = options.Message,
                RedirectUrl = options.RedirectUrl
            };

            return ret;
        }
    }
}
