using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="GatewayTimeoutResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.GatewayTimeout"/> response.
    /// </summary>
    public class GatewayTimeoutResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayTimeoutResult"/> class.
        /// </summary>
        public GatewayTimeoutResult() : base(HttpStatusCode.GatewayTimeout) { }
    }
}
