using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="HttpVersionNotSupportedResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="HttpStatusCode.HttpVersionNotSupported"/> response if negotiation and formatting succeed.
    /// </summary>
    public class HttpVersionNotSupportedResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpVersionNotSupportedResult"/> class.
        /// </summary>
        public HttpVersionNotSupportedResult() : base(HttpStatusCode.HttpVersionNotSupported) { }
    }
}
