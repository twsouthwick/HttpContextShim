// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace WebContext
{
    internal sealed partial class NetFrameworkHttpContext : IRequest
    {
        string IRequest.UserAgent => _context.Request.UserAgent;
    }
}
