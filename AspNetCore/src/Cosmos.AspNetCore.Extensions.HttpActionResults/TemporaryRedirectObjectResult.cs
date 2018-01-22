using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="TemporaryRedirectObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status307TemporaryRedirect"/> response if negotiation and formatting succeed.
    /// </summary>
    public class TemporaryRedirectObjectResult : ObjectResult
    {
        private string _temporaryUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemporaryRedirectObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        /// <param name="temporaryUri">The temporary URI of the requested resource resides.</param>
        public TemporaryRedirectObjectResult(object value, string temporaryUri) : base(value)
        {
            StatusCode = StatusCodes.Status307TemporaryRedirect;
            TemporaryUri = temporaryUri;
        }

        /// <summary>
        /// The temporary URI of the requested resource resides.
        /// </summary>
        public string TemporaryUri
        {
            get => _temporaryUri;
            set => _temporaryUri = CheckHelper.SetterCheckingWhetherArgumentOutOfRangeOrNot(value);
        }

        /// <summary>
        /// Contains the date/time after which the response is considered stale.
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// Specifies directive for caching mechanisms in the responses.
        /// </summary>
        public string CacheControl { get; set; }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Location, new StringValues(TemporaryUri));

            if (!string.IsNullOrWhiteSpace(Expires))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Expires, new StringValues(Expires));
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.CacheControl, new StringValues(CacheControl));
            }

            return base.ExecuteResultAsync(context);
        }
    }
}
