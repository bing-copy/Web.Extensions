using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="MultipleChoicesObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status300MultipleChoices"/> response if negotiation and formatting succeed.
    /// </summary>
    public class MultipleChoicesObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleChoicesObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        /// <param name="preferedChoiceUri">Preferred resource choice represented as an URI.</param>
        public MultipleChoicesObjectResult(object value, string preferedChoiceUri = null) : base(value)
        {
            StatusCode = StatusCodes.Status300MultipleChoices;
            PreferedChoiceUri = preferedChoiceUri;
        }

        /// <summary>
        /// Preferred resource choice represented as an URI.
        /// </summary>
        public string PreferedChoiceUri { get; set; }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (!string.IsNullOrEmpty(PreferedChoiceUri))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Location, new StringValues(PreferedChoiceUri));
            }

            return base.ExecuteResultAsync(context);
        }
    }
}
