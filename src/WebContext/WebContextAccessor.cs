// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NETFRAMEWORK
using System.Web;
#else
using Microsoft.AspNetCore.Http;
#endif

namespace WebContext
{
    /// <summary>
    /// A container for web related context.
    /// </summary>
    public static class WebContextAccessor
    {
#if NETCOREAPP
        private static readonly HttpContextAccessor _accessor = new();
#endif

        /// <summary>
        /// Get an <see cref="IHttpContext"/> instance from <see cref="HttpContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/> instance.</param>
        /// <returns>An abstraction for the context.</returns>
        public static IHttpContext ToWebHttpContext(this HttpContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

#if NETFRAMEWORK
            return new NetFrameworkHttpContext(new HttpContextWrapper(context));
#else
            return new NetCoreHttpContext(context);
#endif
        }

#if NETFRAMEWORK
        /// <summary>
        /// Get an <see cref="IHttpContext"/> instance from <see cref="HttpContextBase"/>.
        /// </summary>
        /// <param name="context">A <see cref="HttpContextBase"/> instance.</param>
        /// <returns>An abstraction for the context.</returns>
        public static IHttpContext ToWebHttpContext(this HttpContextBase context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new NetFrameworkHttpContext(context);
        }
#endif

        /// <summary>
        /// Gets the current <see cref="IHttpContext"/>.
        /// </summary>
        public static IHttpContext? Current
        {
            get
            {
#if NETFRAMEWORK
                var current = HttpContext.Current;
#else
                var current = _accessor.HttpContext;
#endif

                if (current is null)
                {
                    return null;
                }

                return current.ToWebHttpContext();
            }
        }
    }
}
