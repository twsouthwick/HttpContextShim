// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Concurrent;

namespace WebContext
{
    internal class HttpSessionStateBase
    {
        private ConcurrentDictionary<string, object> _cache;

        public HttpSessionStateBase(string sessionId)
        {
            _cache = new ConcurrentDictionary<string, object>();
            Id = sessionId;
        }

        public string Id { get; }

        public object? this[string name]
        {
            get => _cache.TryGetValue(name, out var value) ? value : null;
            set
            {
                if (value is null)
                {
                    _cache.TryRemove(name, out _);
                }
                else
                {
                    _cache.TryAdd(name, value);
                }
            }
        }
    }
}
