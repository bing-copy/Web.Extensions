using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="SeeOtherObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status303SeeOther"/> response if negotiation and formatting succeed.
    /// </summary>
    public class SeeOtherObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeeOtherObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public SeeOtherObjectResult(object value) : base(value) => StatusCode = StatusCodes.Status303SeeOther;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SeeOtherObjectResult"/> class.
        /// </summary>
        /// <param name="location">Location to put in the response header.</param>
        /// <param name="value">The content to format into the entity body.</param>
        public SeeOtherObjectResult(string location, object value) : this(value) => Location = location;

        /// <summary>
        /// Gets or sets the location to put in the response header.
        /// </summary>
        public string Location { get; set; }

        /// <inheritdoc />
        public override void OnFormatting(ActionContext context)
        {
            base.OnFormatting(context);

            if (!string.IsNullOrEmpty(Location))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Location, new StringValues(Location));
            }
        }
    }
}
