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
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, FrameOptionsConstants.DenyFrames);
                    }

                case ResponseFrameOptionsType.SAMEORIGIN:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, FrameOptionsConstants.SameOriginFrames);
                    }

                case ResponseFrameOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
                    {
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, $"{FrameOptionsConstants.AllowFrom} {domain}");
                    }

                default:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, FrameOptionsConstants.DenyFrames);
                    }
            }
        }
    }
}
