namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// AntiXss Sanitizer extensions
    /// </summary>
    public static class AntiXssSanitizeExtensions
    {
        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this string originHtmlString)
            => AntiXssSanitizer.Sanitize(originHtmlString);

        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this string originHtmlString, string policyName)
            => AntiXssSanitizer.Sanitize(originHtmlString, policyName);

        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this string originHtmlString, AntiXssPolicy policy)
            => AntiXssSanitizer.Sanitize(originHtmlString, policy);
    }
}
