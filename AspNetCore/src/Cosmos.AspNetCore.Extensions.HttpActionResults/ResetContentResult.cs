using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ResetContentResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status205ResetContent"/> response.
    /// </summary>
    public class ResetContentResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetContentResult"/> class.
        /// </summary>
        public ResetContentResult() : base(StatusCodes.Status205ResetContent) { }
    }
}
