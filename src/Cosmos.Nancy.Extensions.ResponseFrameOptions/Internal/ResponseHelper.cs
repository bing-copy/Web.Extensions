using Nancy;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class ResponseHelper
    {
        public static void UpdateHeader(NancyContext context, ResponseFramesOptionsType type, string domain = "")
        {
            UpdateHeader(context.Response, type, domain);
        }

        public static Response UpdateHeader(Response response, ResponseFramesOptionsType type, string domain = "")
        {
            switch (type)
            {
                case ResponseFramesOptionsType.DENY:
                    {
                        return response.WithHeader("X-Frames-Options", "DENY");
                    }

                case ResponseFramesOptionsType.SAMEORIGIN:
                    {
                        return response.WithHeader("X-Frames-Options", "SAMEORIGIN");
                    }

                case ResponseFramesOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
                    {
                        return response.WithHeader("X-Frames-Options", $"ALLOW-FROM {domain}");
                    }

                default:
                    {
                        return response.WithHeader("X-Frames-Options", "DENY");
                    }
            }
        }
    }
}
