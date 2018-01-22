using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="PreconditionFailedResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status412PreconditionFailed"/> response.
    /// </summary>
    public class PreconditionFailedResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionFailedResult"/> class.
        /// </summary>
        public PreconditionFailedResult() : base(StatusCodes.Status412PreconditionFailed) { }
    }
}
