// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Http;

namespace WebContext
{
    internal sealed partial class NetCoreHttpContext : IHttpContext
    {
        private readonly HttpContext _context;

        public NetCoreHttpContext(HttpContext context)
        {
            _context = context;
        }

        public IRequest Request => this;
    }
}
