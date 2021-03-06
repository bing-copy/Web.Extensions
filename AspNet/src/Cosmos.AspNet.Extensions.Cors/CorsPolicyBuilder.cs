﻿using System;
using System.Linq;
using Cosmos.AspNet.Extensions.Internal;

/*
 * 本代码根据 Mocrosoft.AspNetCore.Cors 改写
 * https://github.com/aspnet/CORS/blob/dev/src/Microsoft.AspNetCore.Cors/Infrastructure/CorsPolicyBuilder.cs
 * */

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// Cors Policy Builder
    /// </summary>
    public class CorsPolicyBuilder
    {
        private readonly CorsPolicy _policy = new CorsPolicy();

        /// <summary>
        /// Creates a new instance of the <see cref="CorsPolicyBuilder"/>.
        /// </summary>
        /// <param name="origins">list of origins which can be added.</param>
        public CorsPolicyBuilder(params string[] origins)
        {
            WithOrigins(origins);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CorsPolicyBuilder"/>.
        /// </summary>
        /// <param name="policy">The policy which will be used to intialize the builder.</param>
        public CorsPolicyBuilder(CorsPolicy policy)
        {
            Combine(policy);
        }

        /// <summary>
        /// Adds the specified <paramref name="origins"/> to the policy.
        /// </summary>
        /// <param name="origins">The origins that are allowed.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder WithOrigins(params string[] origins)
        {
            foreach (var req in origins)
            {
                _policy.Origins.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="headers"/> to the policy.
        /// </summary>
        /// <param name="headers">The headers which need to be allowed in the request.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder WithHeaders(params string[] headers)
        {
            foreach (var req in headers)
            {
                _policy.Headers.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="exposedHeaders"/> to the policy.
        /// </summary>
        /// <param name="exposedHeaders">The headers which need to be exposed to the client.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder WithExposedHeaders(params string[] exposedHeaders)
        {
            foreach (var req in exposedHeaders)
            {
                _policy.ExposeHeaders.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="methods"/> to the policy.
        /// </summary>
        /// <param name="methods">The methods which need to be added to the policy.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder WithMethods(params string[] methods)
        {
            foreach (var req in methods)
            {
                _policy.Methods.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Sets the policy to allow credentials.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder AllowCredentials()
        {
            _policy.SupportCredentials = true;
            return this;
        }

        /// <summary>
        /// Sets the policy to not allow credentials.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder DisallowCredentials()
        {
            _policy.SupportCredentials = false;
            return this;
        }

        /// <summary>
        /// Ensures that the policy allows any origin.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder AllowAnyOrigin()
        {
            _policy.Origins.Clear();
            _policy.Origins.Add(CorsConstants.AnyOrigin);
            return this;
        }

        /// <summary>
        /// Ensures that the policy allows any method.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder AllowAnyMethod()
        {
            _policy.Methods.Clear();
            _policy.Methods.Add("*");
            return this;
        }

        /// <summary>
        /// Ensures that the policy allows any header.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder AllowAnyHeader()
        {
            _policy.Headers.Clear();
            _policy.Methods.Add("*");
            return this;
        }

        /// <summary>
        /// Sets the preflightMaxAge for the underlying policy.
        /// </summary>
        /// <param name="preflightMaxAge">A positive <see cref="TimeSpan"/> indicating the time a preflight
        /// request can be cached.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder SetPreflightMaxAge(TimeSpan preflightMaxAge)
        {
            _policy.PreflightMaxAge = preflightMaxAge;
            return this;
        }

        /// <summary>
        /// Sets the specified <paramref name="isOriginAllowed"/> for the underlying policy.
        /// </summary>
        /// <param name="isOriginAllowed">The function used by the policy to evaluate if an origin is allowed.</param>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder SetIsOriginAllowed(Func<string, bool> isOriginAllowed)
        {
            _policy.IsOriginAllowed = isOriginAllowed;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="CorsPolicy.IsOriginAllowed"/> property of the policy to be a function
        /// that allows origins to match a configured wildcarded domain when evaluating if the 
        /// origin is allowed.
        /// </summary>
        /// <returns>The current policy builder.</returns>
        public CorsPolicyBuilder SetIsOriginAllowedToAllowWildcardSubdomains()
        {
            _policy.IsOriginAllowed = _policy.IsOrginAnAllowedSubdomain;
            return this;
        }

        /// <summary>
        /// Build cors-policy
        /// </summary>
        /// <returns></returns>
        public CorsPolicy Build()
        {
            return _policy;
        }

        private CorsPolicyBuilder Combine(CorsPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            WithOrigins(policy.Origins.ToArray());
            WithHeaders(policy.Headers.ToArray());
            WithExposedHeaders(policy.ExposeHeaders.ToArray());
            WithMethods(policy.Methods.ToArray());
            SetIsOriginAllowed(policy.IsOriginAllowed);

            if (policy.PreflightMaxAge.HasValue)
            {
                SetPreflightMaxAge(policy.PreflightMaxAge.Value);
            }

            if (policy.SupportCredentials)
            {
                AllowCredentials();
            }
            else
            {
                DisallowCredentials();
            }

            return this;
        }
    }
}
