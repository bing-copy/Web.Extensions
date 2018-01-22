using Nancy;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class ResponseHelper
    {
        public static void UpdateHeader(NancyContext context, ResponseFrameOptionsType type, string domain = "")
        {
            UpdateHeader(context.Response, type, domain);
        }

        public static Response UpdateHeader(Response response, ResponseFrameOptionsType type, string domain = "")
        {
            switch (type)
            {
                case ResponseFrameOptionsType.DENY:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                    }

                case ResponseFrameOptionsType.SAMEORIGIN:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.SameOriginFrames);
                    }

                case ResponseFrameOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
                    {
                        return response.WithHeader(FrameOptionsConstants.XFrameOptions, $"{FrameOptionsConstants.AllowFrom} {domain}");
                    }

                default:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                    }
            }
        }
    }
}
