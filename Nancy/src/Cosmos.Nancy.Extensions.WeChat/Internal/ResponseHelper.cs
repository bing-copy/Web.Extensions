using Nancy;
using Nancy.Extensions;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class ResponseHelper
    {
        public static Response DoWeChatBrowserOnlyOption(NancyContext context, WeChatBrowserOnlyOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.RedirectUrl))
            {
                return context.GetRedirect(options.RedirectUrl);
            }

            Response response = options.Message;
            response.StatusCode = options.StatusCode;
            response.ReasonPhrase = options.Message;
            return response;
        }
    }
}
