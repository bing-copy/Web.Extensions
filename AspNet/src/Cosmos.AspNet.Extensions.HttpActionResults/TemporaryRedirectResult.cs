using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="TemporaryRedirectResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.TemporaryRedirect"/> response.
    /// </summary>
    public class TemporaryRedirectResult : HttpStatusCodeResult
    {
        private string _temporaryUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemporaryRedirectResult"/> class.
        /// </summary>
        /// <param name="temporaryUri">The temporary URI of the requested resource resides.</param>
        public TemporaryRedirectResult(string temporaryUri) : base(HttpStatusCode.TemporaryRedirect) => TemporaryUri = temporaryUri;

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
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Location, TemporaryUri);

            if (!string.IsNullOrWhiteSpace(Expires))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Expires, Expires);
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.CacheControl, CacheControl);
            }

            base.ExecuteResult(context);
        }
    }
}
