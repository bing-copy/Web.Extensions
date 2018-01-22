using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ContinueResult"/> that when executed will 
    /// produce a Continue (100) response.
    /// </summary>
    public class ContinueResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContinueResult"/> class.
        /// </summary>
        public ContinueResult() : base((int)HttpStatusCode.Continue) { }
    }
}
