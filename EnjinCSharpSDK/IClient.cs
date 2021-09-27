﻿/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Interface for client implementation.
    /// </summary>
    [PublicAPI]
    public interface IClient : IDisposable
    {
        /// <summary>
        /// Represents whether the client is authenticated.
        /// </summary>
        /// <value>Whether the client is authenticated.</value>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Represents whether the client is closed.
        /// </summary>
        /// <value>Whether the client is closed.</value>
        bool IsClosed { get; }
        
        /// <summary>
        /// Authenticates the client with the given token.
        /// </summary>
        /// <param name="token">The auth token.</param>
        void Auth(string? token);
    }
}