using System.Collections.Generic;

namespace ModernStore.Shared.Entities
{
    public abstract class Notification
    {
        private Dictionary<string, string> _notifications;

        public Notification()
        {
            _notifications = new Dictionary<string, string>();
        }

        public string Field { get; private set; }
        public string Message { get; private set; }
        public Dictionary<string, string> Notifications { get { return _notifications; } }

        public void AddNotification(string field, string message)
        {
            _notifications.Add(field, message);
        }

        public void AddNotification(Dictionary<string, string> notifications)
        {
            foreach (var item in notifications)
            {
                _notifications.Add(item.Key, item.Value);

            }
        }

        public bool IsValid() => Notifications.Count == 0;
    }
}

