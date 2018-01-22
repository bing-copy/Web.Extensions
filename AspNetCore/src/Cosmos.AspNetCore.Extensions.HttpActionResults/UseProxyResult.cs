using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="UseProxyResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status305UseProxy"/> response.
    /// </summary>  
    public class UseProxyResult : StatusCodeResult
    {
        private string _proxyUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="UseProxyResult"/> class.
        /// </summary>
        /// <param name="proxyUri">A proxy through which the requested resource must be accessed.</param>
        public UseProxyResult(string proxyUri) : base(StatusCodes.Status305UseProxy) => ProxyUri = proxyUri;

        /// <summary>
        /// A proxy through which the requested resource must be accessed.
        /// </summary>
        public string ProxyUri
        {
            get => _proxyUri;
            set => _proxyUri = CheckHelper.SetterCheckingWhetherArgumentOutOfRangeOrNot(value);
        }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Location, new StringValues(ProxyUri));

            return base.ExecuteResultAsync(context);
        }
    }
}
