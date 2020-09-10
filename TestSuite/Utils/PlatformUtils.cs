using Enjin.SDK.Models;

namespace TestSuite.Utils
{
    public static class PlatformUtils
    {
        public const string Kovan = "kovan";
        public const string Mainnet = "mainnet";

        public static Platform CreateFakePlatform(string network)
        {
            var platform = new Platform();

            var networkProperty = platform.GetType().GetProperty("Network");
            networkProperty?.SetValue(platform, network);
            var notificationsProperty = platform.GetType().GetProperty("Notifications");
            notificationsProperty?.SetValue(platform, CreateNotifications());
            
            return platform;
        }

        private static Notifications CreateNotifications()
        {
            var notifications = new Notifications();
            
            var pusherProperty = notifications.GetType().GetProperty("Pusher");
            pusherProperty?.SetValue(notifications, CreatePusher());
            
            return notifications;
        }

        private static Pusher CreatePusher()
        {
            var pusher = new Pusher();

            var keyProperty = pusher.GetType().GetProperty("Key");
            keyProperty?.SetValue(pusher, "xyz");
            var namespaceProperty = pusher.GetType().GetProperty("Namespace");
            namespaceProperty?.SetValue(pusher, "xyz");
            var optionsProperty = pusher.GetType().GetProperty("Options");
            optionsProperty?.SetValue(pusher, CreatePusherOptions());
            
            return pusher;
        }

        private static PusherOptions CreatePusherOptions()
        {
            var options = new PusherOptions();

            var clusterProperty = options.GetType().GetProperty("Cluster");
            clusterProperty?.SetValue(options, "xyz");
            var encryptedProperty = options.GetType().GetProperty("Encrypted");
            encryptedProperty?.SetValue(options, true);
            
            return options;
        }
    }
}