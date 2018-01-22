using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="NotAcceptableObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status406NotAcceptable"/> response if negotiation and formatting succeed.
    /// </summary>
    public class NotAcceptableObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotAcceptableObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public NotAcceptableObjectResult(object value) : base(value) => StatusCode = StatusCodes.Status406NotAcceptable;
    }
}
