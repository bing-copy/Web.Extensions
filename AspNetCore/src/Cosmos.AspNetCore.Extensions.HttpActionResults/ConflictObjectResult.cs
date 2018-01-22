using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="ConflictObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status409Conflict"/> response if negotiation and formatting succeed.
    /// </summary>
    public class ConflictObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public ConflictObjectResult(object value) : base(value) => StatusCode = StatusCodes.Status409Conflict;
    }
}
