using System.Net;
using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="SwitchingProtocolsResult"/> that when executed will 
    /// produce a Switching Protocols (101) response.
    /// </summary>
    public class SwitchingProtocolsResult : StatusCodeResult
    {
        private string _upgradeTo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchingProtocolsResult"/> class.
        /// </summary>
        /// <param name="upgradeTo">Value to put in the response "Upgrade" header.</param>
        public SwitchingProtocolsResult(string upgradeTo) : base((int)HttpStatusCode.SwitchingProtocols) => UpgradeTo = upgradeTo;

        /// <summary>
        /// Gets or sets the value to put in the response  <see cref="HeaderNames.Upgrade"/> header.
        /// </summary>
        public string UpgradeTo
        {
            get => _upgradeTo;
            set => _upgradeTo = CheckHelper.SetterCheckingWhetherArgumentNullOrNot(value);
        }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Connection, "upgrade");
            context.HttpContext.Response.Headers.Add(HeaderNames.Upgrade, new StringValues(UpgradeTo));

            return base.ExecuteResultAsync(context);
        }
    }
}
