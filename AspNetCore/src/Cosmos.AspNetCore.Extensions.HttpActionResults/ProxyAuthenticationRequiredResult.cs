using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="ProxyAuthenticationRequiredResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status407ProxyAuthenticationRequired"/> response.
    /// </summary>
    public class ProxyAuthenticationRequiredResult : StatusCodeResult
    {
        /// <summary>
        /// An <see cref="StatusCodeResult"/> that when executed will produce a
        /// Initializes a new instance of the <see cref="ProxyAuthenticationRequiredResult"/> class.
        /// </summary>
        /// <param name="proxyAuthenticate">Challenge applicable to the proxy for the requested resource.</param>
        public ProxyAuthenticationRequiredResult(string proxyAuthenticate) : base(StatusCodes.Status407ProxyAuthenticationRequired) => ProxyAuthenticate = proxyAuthenticate;

        /// <summary>
        /// Gets or sets a challenge applicable to the proxy for the requested resource
        /// </summary>
        public string ProxyAuthenticate { get; set; }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (!string.IsNullOrWhiteSpace(ProxyAuthenticate))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ProxyAuthenticate, new StringValues(ProxyAuthenticate));
            }

            return base.ExecuteResultAsync(context);
        }
    }
}
