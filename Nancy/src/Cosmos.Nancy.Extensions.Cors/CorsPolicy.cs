using System;
using System.Collections.Generic;
using System.Linq;

/*
 * 本代码根据 Mocrosoft.AspNetCore.Cors 改写
 * https://github.com/aspnet/CORS/blob/dev/src/Microsoft.AspNetCore.Cors/Infrastructure/CorsPolicy.cs
 * */

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Defines the policy for CORS-Origin request based on the CORS specifications
    /// </summary>
    public class CorsPolicy
    {
        /// <summary>
        /// Get default cors policy
        /// </summary>
        public static CorsPolicy DefaultCorsPolicy => new CorsPolicy();

        private TimeSpan? _preflightMaxAge;

        /// <summary>
        /// Default contructor for a cors-policy
        /// </summary>
        public CorsPolicy()
        {
            IsOriginAllowed = DefaultIsOriginAllowed;
        }

        /// <summary>
        /// Gets a value indicating if all headers are allowed.
        /// </summary>
        public bool AllowAnyHeader => Headers != null && Headers.Count == 1 && (Headers.Count != 1 || Headers[0] == "*");

        /// <summary>
        /// Gets a value indicating if all methods are allowed.
        /// </summary>
        public bool AllowAnyMethod => Methods != null && Methods.Count == 1 && (Methods.Count != 1 || Methods[0] == "*");

        /// <summary>
        /// Gets a value indicating if all origins are allowed.
        /// </summary>
        public bool AllowAnyOrigin => Origins != null && Origins.Count == 1 && (Origins.Count != 1 || Origins[0] == "*");

        /// <summary>
        /// Gets or sets a function which evaluates whether an origin is allowed.
        /// </summary>
        public Func<string, bool> IsOriginAllowed { get; set; }

        /// <summary>
        /// expose headers
        /// </summary>
        public IList<string> ExposeHeaders { get; } = new List<string>();

        /// <summary>
        /// headers
        /// </summary>
        public IList<string> Headers { get; } = new List<string>();

        /// <summary>
        /// methods
        /// </summary>
        public IList<string> Methods { get; } = new List<string>();

        /// <summary>
        /// origins
        /// </summary>
        public IList<string> Origins { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the TimeSpan for which the result of a preflight request can be cached.
        /// </summary>
        public TimeSpan? PreflightMaxAge
        {
            get => _preflightMaxAge;
            set => _preflightMaxAge = value >= TimeSpan.Zero
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "PreflightMaxAge must be greater than or equal to 0.");
        }

        /// <summary>
        /// Gets or sets a value indicating whether the resource supports user credentials in the request.
        /// </summary>
        public bool SupportCredentials { get; set; }

        private bool DefaultIsOriginAllowed(string origin) => Origins.Contains(origin, StringComparer.Ordinal);

        /// <summary>
        /// Matched key
        /// </summary>
        public string MatchedKey { get; set; } = string.Empty;

        /// <summary>
        /// Matched value
        /// </summary>
        public string MatchedValue { get; set; } = string.Empty;
    }
}
