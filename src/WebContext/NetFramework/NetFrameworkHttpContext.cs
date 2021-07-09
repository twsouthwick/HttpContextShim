// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Web;

namespace WebContext
{
    internal sealed partial class NetFrameworkHttpContext : IHttpContext
    {
        private readonly HttpContextBase _context;

        public NetFrameworkHttpContext(HttpContextBase context)
        {
            _context = context;
        }

        public IRequest Request => this;
    }
}
