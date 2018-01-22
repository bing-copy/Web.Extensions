using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="MultipleChoicesResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status300MultipleChoices"/> response.
    /// </summary>
    public class MultipleChoicesResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleChoicesResult"/> class.
        /// </summary>
        /// <param name="preferedChoiceUri">Preferred resource choice represented as an URI.</param>
        public MultipleChoicesResult(string preferedChoiceUri = null) : base(StatusCodes.Status300MultipleChoices) => PreferedChoiceUri = preferedChoiceUri;

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
