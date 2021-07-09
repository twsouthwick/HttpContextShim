// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http;

namespace WebContext
{
    /// <summary>
    /// An abstraction to generate a session id.
    /// </summary>
    internal interface ISystemWebSessionIdFactory
    {
        /// <summary>
        /// Generate a session id for a given <see cref="HttpContext"/>.
        /// </summary>
        /// <param name="context">A context.</param>
        /// <returns>A session id.</returns>
        string GetSessionId(HttpContext context);
    }
}
