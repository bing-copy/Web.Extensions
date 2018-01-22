using System.Collections.Generic;
using AngleSharp;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// AntiXss Policy
    /// </summary>
    public class AntiXssPolicy
    {
        /// <summary>
        /// Get default cors policy
        /// </summary>
        public static AntiXssPolicy DefaultAntiXssPolicy => new AntiXssPolicy();

        /// <summary>
        /// Allowed tags
        /// </summary>
        public IList<string> AllowedTags { get; set; } = new List<string>();

        /// <summary>
        /// Allowed schemes
        /// </summary>
        public IList<string> AllowedSchemes { get; set; } = new List<string>();

        /// <summary>
        /// Allowed attributes
        /// </summary>
        public IList<string> AllowedAttributes { get; set; } = new List<string>();

        /// <summary>
        /// Uri attributes
        /// </summary>
        public IList<string> UriAttributes { get; set; } = new List<string>();

        /// <summary>
        /// Allowed css properties
        /// </summary>
        public IList<string> AllowedCssProperties { get; set; } = new List<string>();

        /// <summary>
        /// Base url
        /// </summary>
        public string BaseUrl { get; set; } = "";

        /// <summary>
        /// Output markup formatter
        /// </summary>
        public IMarkupFormatter OutputFormatter { get; set; } = null;

        /// <summary>
        /// The values of keys in uri need to sanitize.
        /// </summary>
        public IList<string> UriQueryKeys { get; set; } = new List<string>();
    }
}
