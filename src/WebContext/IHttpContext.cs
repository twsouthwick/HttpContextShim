// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace WebContext
{
    /// <summary>
    /// An abstraction of an HttpContext that has similar behavior on ASP.NET and ASP.NET Core.
    /// </summary>
    public interface IHttpContext
    {
        IRequest Request { get; }
    }
}
