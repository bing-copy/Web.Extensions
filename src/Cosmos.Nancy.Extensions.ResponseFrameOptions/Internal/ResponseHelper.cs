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
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, FrameOptionsConstants.DenyFrames);
                    }

                case ResponseFramesOptionsType.SAMEORIGIN:
                    {
                        return response.WithHeader(FrameOptionsConstants.XFramesOptions, FrameOptionsConstants.SameOriginFrames);
                    }

                case ResponseFramesOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
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
