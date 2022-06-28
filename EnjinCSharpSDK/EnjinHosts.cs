/* Copyright 2021 Enjin Pte. Ltd.
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
    /// The network hosts used by the Enjin Platform.
    /// </summary>
    [PublicAPI]
    public class EnjinHosts
    {
        /// <summary>
        /// The URI for the Enjin Platform on the Goerli test network.
        /// </summary>
        public static readonly Uri GOERLI = new Uri("https://goerli.cloud.enjin.io/");

        /// <summary>
        /// The URI for the Enjin Platform on the main network.
        /// </summary>
        public static readonly Uri MAIN_NET = new Uri("https://cloud.enjin.io/");

        /// <summary>
        /// The URI for the Enjin Platform on the JumpNet network.
        /// </summary>
        public static readonly Uri JUMP_NET = new Uri("https://jumpnet.cloud.enjin.io/");
    }
}