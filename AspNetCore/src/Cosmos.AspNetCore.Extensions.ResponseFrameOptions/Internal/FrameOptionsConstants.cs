namespace Cosmos.AspNetCore.Extensions.Internal
{
    /// <summary>
    /// X-FramesOptions Constants
    /// </summary>
    public static class FrameOptionsConstants
    {
        /// <summary>
        /// X-Frame-Options
        /// </summary>
        public static readonly string XFrameOptions = "X-Frame-Options";

        /// <summary>
        /// The page cannot be displayed in a frame, regardless of the site attempting to do so.
        /// </summary>
        public static readonly string DenyFrames = "DENY";

        /// <summary>
        /// The page can only be displayed in a frame on the same origin as the page itself.
        /// </summary>
        public static readonly string SameOriginFrames = "SAMEORIGIN";

        /// <summary>
        /// The page can only be displayed in a frame on the specified origin.
        /// </summary>
        public static readonly string AllowFrom = "ALLOW-FROM";
    }
}
