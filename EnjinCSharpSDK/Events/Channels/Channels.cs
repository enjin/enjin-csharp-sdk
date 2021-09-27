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

using System.Runtime.CompilerServices;
using Enjin.SDK.Models;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    internal sealed class ProjectChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _projectUuid;
        
        public ProjectChannel(Platform platform, string projectUuid)
        {
            _platform = platform;
            _projectUuid = projectUuid;
        }

        public string Channel() => $"enjincloud.{_platform.Network!.ToLower()}.project.{_projectUuid}";
    }
    
    internal sealed class PlayerChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _projectUuid;
        private readonly string _playerId;
        
        public PlayerChannel(Platform platform, string projectUuid, string playerId)
        {
            _platform = platform;
            _projectUuid = projectUuid;
            _playerId = playerId;
        }
        
        public string Channel() => $"enjincloud.{_platform.Network!.ToLower()}.project.{_projectUuid}.player.{_playerId}";
    }

    internal sealed class AssetChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _assetId;

        public AssetChannel(Platform platform, string assetId)
        {
            _platform = platform;
            _assetId = assetId;
        }

        public string Channel() => $"enjincloud.{_platform.Network!.ToLower()}.asset.{_assetId}";
    }
    
    internal sealed class WalletChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _ethAddress;

        public WalletChannel(Platform platform, string ethAddress)
        {
            _platform = platform;
            _ethAddress = ethAddress;
        }

        public string Channel() => $"enjincloud.{_platform.Network!.ToLower()}.wallet.{_ethAddress}";
    }
}