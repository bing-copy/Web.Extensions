using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="NonAuthoritativeInformationResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.NonAuthoritativeInformation"/> response.
    /// </summary>
    public class NonAuthoritativeInformationResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonAuthoritativeInformationResult"/> class.
        /// </summary>
        public NonAuthoritativeInformationResult() : base(HttpStatusCode.NonAuthoritativeInformation) { }
    }
}
