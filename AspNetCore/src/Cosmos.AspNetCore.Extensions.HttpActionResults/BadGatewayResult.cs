using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="BadGatewayResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status502BadGateway"/> response.
    /// </summary>
    public class BadGatewayResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayResult"/> class.
        /// </summary>
        public BadGatewayResult(): base(StatusCodes.Status502BadGateway){}
    }
}
