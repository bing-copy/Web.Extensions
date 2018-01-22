using System.Web;

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class ResponseHelper
    {
        public static void UpdateHeader(HttpResponse response, ResponseFrameOptionsType type, string domain)
        {
            switch (type)
            {
                case ResponseFrameOptionsType.DENY:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                        break;
                    }

                case ResponseFrameOptionsType.SAMEORIGIN:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.SameOriginFrames);
                        break;
                    }

                case ResponseFrameOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, $"{FrameOptionsConstants.AllowFrom} {domain}");
                        break;
                    }

                default:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                        break;
                    }
            }
        }


        public static void UpdateHeader(HttpResponseBase response, ResponseFrameOptionsType type, string domain)
        {
            switch (type)
            {
                case ResponseFrameOptionsType.DENY:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                        break;
                    }

                case ResponseFrameOptionsType.SAMEORIGIN:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.SameOriginFrames);
                        break;
                    }

                case ResponseFrameOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain):
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, $"{FrameOptionsConstants.AllowFrom} {domain}");
                        break;
                    }

                default:
                    {
                        response.AppendHeader(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                        break;
                    }
            }
        }
    }
}
