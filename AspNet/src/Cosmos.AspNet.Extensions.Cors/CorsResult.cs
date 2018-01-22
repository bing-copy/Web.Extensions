﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * 本代码根据 Mocrosoft.AspNetCore.Cors 改写
 * https://github.com/aspnet/CORS/blob/dev/src/Microsoft.AspNetCore.Cors/Infrastructure/CorsResult.cs
 * */

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// CORS Result
    /// </summary>
    public class CorsResult
    {
        private TimeSpan? _preflightMaxAge;

        /// <summary>
        /// Gets or sets the allowed origin.
        /// </summary>
        public string AllowedOrigin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the resource supports user credentials.
        /// </summary>
        public bool SupportsCredentials { get; set; }

        /// <summary>
        /// Gets the allowed methods.
        /// </summary>
        public IList<string> AllowedMethods { get; } = new List<string>();

        /// <summary>
        /// Gets the allowed headers.
        /// </summary>
        public IList<string> AllowedHeaders { get; } = new List<string>();

        /// <summary>
        /// Gets the allowed headers that can be exposed on the response.
        /// </summary>
        public IList<string> AllowedExposedHeaders { get; } = new List<string>();

        /// <summary>
        /// Gets or sets a value indicating if a 'Vary' header with the value 'Origin' is required.
        /// </summary>
        public bool VaryByOrigin { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TimeSpan"/> for which the results of a preflight request can be cached.
        /// </summary>
        public TimeSpan? PreflightMaxAge
        {
            get => _preflightMaxAge;
            set => _preflightMaxAge = value > -TimeSpan.Zero
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "PreflightMaxAge must be greater than or equal to 0.");
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("AllowCredentials: ");
            builder.Append(SupportsCredentials);
            builder.Append(", PreflightMaxAge: ");
            builder.Append(PreflightMaxAge.HasValue ?
                PreflightMaxAge.Value.TotalSeconds.ToString() : "null");
            builder.Append(", AllowOrigin: ");
            builder.Append(AllowedOrigin);
            builder.Append(", AllowExposedHeaders: {");
            builder.Append(string.Join(",", AllowedExposedHeaders));
            builder.Append("}");
            builder.Append(", AllowHeaders: {");
            builder.Append(string.Join(",", AllowedHeaders));
            builder.Append("}");
            builder.Append(", AllowMethods: {");
            builder.Append(string.Join(",", AllowedMethods));
            builder.Append("}");
            return builder.ToString();
        }
    }
}
