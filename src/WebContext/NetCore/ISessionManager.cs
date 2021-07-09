﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace WebContext
{
    internal interface ISessionManager
    {
        HttpSessionStateBase GetState(string sessionId);

        int RemoveStaleSessions(TimeSpan age);
    }
}
