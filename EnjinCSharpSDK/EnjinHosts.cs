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
    /// The networks hosts used by the Enjin Cloud.
    /// </summary>
    [PublicAPI]
    public class EnjinHosts
    {
        /// <summary>
        /// The URI for the kovan Enjin Cloud.
        /// </summary>
        public static readonly Uri KOVAN = new Uri("https://kovan.cloud.enjin.io/");
        
        /// <summary>
        /// The URI for the main Enjin Cloud.
        /// </summary>
        public static readonly Uri MAIN_NET = new Uri("https://cloud.enjin.io/");

        /// <summary>
        /// The URI for the JumpNet network.
        /// </summary>
        public static readonly Uri JUMP_NET = new Uri("https://jumpnet.cloud.enjin.io/");
    }
}