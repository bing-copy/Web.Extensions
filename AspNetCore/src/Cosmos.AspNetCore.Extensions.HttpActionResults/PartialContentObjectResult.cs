using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="PartialContentObjectResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status206PartialContent"/> response if negotiation and formatting succeed.
    /// </summary>
    public class PartialContentObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialContentObjectResult"/> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public PartialContentObjectResult(object value) : base(value) => StatusCode = StatusCodes.Status206PartialContent;

        /// <summary>
        /// Indicates where in a full body message a partial message belongs.
        /// </summary>
        public string ContentRange { get; set; }

        /// <summary>
        /// An identifier for a specific version of a resource.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Indicates an alternate location for the returned data.
        /// </summary>
        public string ContentLocation { get; set; }

        /// <summary>
        /// Contains the date/time after which the response is considered stale.
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// Specifies directive for caching mechanisms in the responses.
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Determines how to match future request headers to decide whether a cached response can be used rather than requesting a fresh one from the origin server. 
        /// </summary>
        public string Vary { get; set; }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Date, new StringValues(DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            ValidateContentHeaders(context);

            if (!string.IsNullOrEmpty(ContentRange))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ContentRange, new StringValues(ContentRange));
            }

            if (!string.IsNullOrWhiteSpace(ETag))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ETag, new StringValues(ETag));
            }

            if (!string.IsNullOrWhiteSpace(ContentLocation))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ContentLocation, new StringValues(ContentLocation));
            }

            if (!string.IsNullOrWhiteSpace(Expires))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Expires, new StringValues(Expires));
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.CacheControl, new StringValues(CacheControl));
            }

            if (!string.IsNullOrWhiteSpace(Vary))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Vary, new StringValues(Vary));
            }

            return base.ExecuteResultAsync(context);
        }

        private void ValidateContentHeaders(ActionContext context)
        {
            var hasMultipartHeader = context.HttpContext.Response.Headers.Any(x => x.Key == HeaderNames.ContentType && x.Value == "multipart/byteranges");

            if (!hasMultipartHeader && string.IsNullOrWhiteSpace(ContentRange))
            {
                throw new InvalidOperationException(@"The response must contain either a Content-Range header field indicating the range included with this response, or a multipart/byteranges Content-Type including Content-Range fields for each part.");
            }
        }
    }
}
