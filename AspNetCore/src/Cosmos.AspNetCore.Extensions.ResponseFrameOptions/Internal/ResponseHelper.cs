using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions.Internal {
    internal static class ResponseHelper {
        public static void UpdateHeader(HttpContext context, ResponseFrameOptionsType type, string domain = "") {
            switch (type) {
                case ResponseFrameOptionsType.DENY: {
                    context.Response.Headers.Add(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                    break;
                }

                case ResponseFrameOptionsType.SAMEORIGIN: {
                    context.Response.Headers.Add(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.SameOriginFrames);
                    break;
                }

                case ResponseFrameOptionsType.ALLOWFROM when !string.IsNullOrWhiteSpace(domain): {
                    context.Response.Headers.Add(FrameOptionsConstants.XFrameOptions, $"{FrameOptionsConstants.AllowFrom} {domain}");
                    break;
                }

                default: {
                    context.Response.Headers.Add(FrameOptionsConstants.XFrameOptions, FrameOptionsConstants.DenyFrames);
                    break;
                }
            }
        }
    }
}