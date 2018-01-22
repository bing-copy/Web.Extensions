using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="MultipleChoicesResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.MultipleChoices"/> response.
    /// </summary>
    public class MultipleChoicesResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleChoicesResult"/> class.
        /// </summary>
        /// <param name="preferedChoiceUri">Preferred resource choice represented as an URI.</param>
        public MultipleChoicesResult(string preferedChoiceUri = null) : base(HttpStatusCode.MultipleChoices) => PreferedChoiceUri = preferedChoiceUri;

        /// <summary>
        /// Preferred resource choice represented as an URI.
        /// </summary>
        public string PreferedChoiceUri { get; set; }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Location, PreferedChoiceUri);

            base.ExecuteResult(context);
        }
    }
}
