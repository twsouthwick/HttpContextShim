// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace WebContext
{
    /// <summary>
    /// A framework-independent abstraction of a request object.
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Gets the request UserAgent string.
        /// </summary>
        string UserAgent { get; }
    }
}
