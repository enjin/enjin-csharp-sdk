using System.Runtime.CompilerServices;
using Enjin.SDK.Models;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    internal sealed class ProjectChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _projectId;
        
        public ProjectChannel(Platform platform, int projectId)
        {
            _platform = platform;
            _projectId = projectId;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.project.{_projectId}";
    }
    
    internal sealed class PlayerChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _projectId;
        private readonly string _playerId;
        
        public PlayerChannel(Platform platform, int projectId, string playerId)
        {
            _platform = platform;
            _projectId = projectId;
            _playerId = playerId;
        }
        
        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.project.{_projectId}.player.{_playerId}";
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

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.asset.{_assetId}";
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

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.wallet.{_ethAddress}";
    }
}