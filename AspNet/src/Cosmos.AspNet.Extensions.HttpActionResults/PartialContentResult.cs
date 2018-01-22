using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="PartialContentResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.PartialContent"/> response.
    /// </summary>
    public class PartialContentResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialContentResult"/> class.
        /// </summary>
        public PartialContentResult() : base(HttpStatusCode.PartialContent) { }

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
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Date, DateTime.Now.ToString(CultureInfo.InvariantCulture));

            ValidateContentHeaders(context);

            if (!string.IsNullOrEmpty(ContentRange))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ContentRange, ContentRange);
            }

            if (!string.IsNullOrWhiteSpace(ETag))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ETag, ETag);
            }

            if (!string.IsNullOrWhiteSpace(ContentLocation))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ContentLocation, ContentLocation);
            }

            if (!string.IsNullOrWhiteSpace(Expires))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Expires, Expires);
            }

            if (!string.IsNullOrWhiteSpace(CacheControl))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.CacheControl, (CacheControl));
            }

            if (!string.IsNullOrWhiteSpace(Vary))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Vary, Vary);
            }

            base.ExecuteResult(context);
        }

        private void ValidateContentHeaders(ControllerContext context)
        {
            var hasMultipartHeader = context.HttpContext.Response.Headers.AllKeys.Contains(HeaderNames.ContentType)
                && context.HttpContext.Response.Headers[HeaderNames.ContentType] == "multipart/byteranges";

            if (!hasMultipartHeader && string.IsNullOrWhiteSpace(ContentRange))
            {
                throw new InvalidOperationException(@"The response must contain either a Content-Range header field indicating the range included with this response, or a multipart/byteranges Content-Type including Content-Range fields for each part.");
            }
        }
    }
}
