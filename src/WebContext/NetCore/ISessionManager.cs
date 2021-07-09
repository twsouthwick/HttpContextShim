// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace WebContext
{
    /// <summary>
    /// A generalized session manager.
    /// </summary>
    internal interface ISessionManager
    {
        /// <summary>
        /// Gets a session state.
        /// </summary>
        /// <param name="sessionId">The session id.</param>
        /// <returns>The current session.</returns>
        HttpSessionStateBase GetState(string sessionId);

        /// <summary>
        /// Removes a session.
        /// </summary>
        /// <param name="age">Timespan.</param>
        /// <returns>How many were removed.</returns>
        int RemoveStaleSessions(TimeSpan age);
    }
}
