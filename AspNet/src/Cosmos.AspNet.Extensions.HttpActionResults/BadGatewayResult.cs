using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="BadGatewayResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.BadGateway"/> response.
    /// </summary>
    public class BadGatewayResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayResult"/> class.
        /// </summary>
        public BadGatewayResult() : base(HttpStatusCode.BadGateway) { }
    }
}
