// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WebContext;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class WebContextExtensions
    {
        public static SystemWebShimBuilder AddSystemWebShim(this IServiceCollection services)
            => new SystemWebShimBuilder(services);

        public static SystemWebShimBuilder AddHttpContextCurrent(this SystemWebShimBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddHttpContextAccessor();

            return builder;
        }

        public static SystemWebShimBuilder AddDefaults(this SystemWebShimBuilder services) => services
            .AddHttpContextCurrent()
            .AddSession()
            .AddAuthentication();

        public static SystemWebShimBuilder AddAuthentication(this SystemWebShimBuilder services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Services.AddAuthentication();

            return services;
        }

        public static SystemWebShimBuilder AddSession(this SystemWebShimBuilder builder, Action<SessionShimOptions>? configure = null)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.TryAddSingleton<ISystemWebSessionIdFactory, SystemWebCookieSessionIdFactory>();
            builder.Services.TryAddSingleton<ISessionManager, SessionManager>();
            builder.Services.AddHostedService<SessionBackgroundService>();

            var options = builder.Services.AddOptions<SessionShimOptions>();

            if (configure is not null)
            {
                options.Configure(configure);
            }

            return builder;
        }
    }
}
