using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="RequestTimeoutResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status408RequestTimeout"/> response.
    /// </summary>
    public class RequestTimeoutResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutResult"/> class.
        /// </summary>
        public RequestTimeoutResult() : base(StatusCodes.Status408RequestTimeout) { }
    }
}
