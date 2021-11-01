namespace Hungath.UIManager.Notifications
{
    public static class NotificationCounter
    {
        private static int _notifications;

        public static int GetNotifications()
        {
            return _notifications;
        }

        public static void UptickNotifications()
        {
            _notifications++;
        }
    }
}
