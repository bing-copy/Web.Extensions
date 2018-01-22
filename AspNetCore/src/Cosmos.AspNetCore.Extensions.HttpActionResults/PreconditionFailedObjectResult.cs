using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="PreconditionFailedObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status412PreconditionFailed"/> response if negotiation and formatting succeed.
    /// </summary>
    public class PreconditionFailedObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionFailedObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public PreconditionFailedObjectResult(object value) : base(value) => StatusCode = StatusCodes.Status412PreconditionFailed;

    }
}
