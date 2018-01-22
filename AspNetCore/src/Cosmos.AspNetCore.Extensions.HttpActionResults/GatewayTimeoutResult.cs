using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="GatewayTimeoutResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status504GatewayTimeout"/> response.
    /// </summary>
    public class GatewayTimeoutResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GatewayTimeoutResult"/> class.
        /// </summary>
        public GatewayTimeoutResult() : base(StatusCodes.Status504GatewayTimeout) { }
    }
}
