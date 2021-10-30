using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
    public class Notification : MonoBehaviour
    {
        public TMP_Text notificationMessage;
        public Image background;
        public GameObject container;
        private static int _currentNotifications;

        private void Awake()
        {
            notificationMessage = GetComponentInChildren<TMP_Text>();
            background = GetComponentInChildren<Image>();
            container = GameObject.Find("NotificationContainer");
        }

        private void Update() => PositionNotification();

        private void PositionNotification()
        {
            if (_currentNotifications != NotificationCounter.GetNotifications())
            {
                var position = transform.position;
                var notificationOffset = 0f;
                foreach (Transform notification in container.transform)
                {
                    if (notification.name != "NotificationSpawnPoint")
                    {
                        notification.position = new Vector3(position.x, position.y - notificationOffset, position.z);
                        notificationOffset += notification.GetComponent<RectTransform>().sizeDelta[1] * 1.11f;
                    }
                }

                _currentNotifications = NotificationCounter.GetNotifications();
            }
        }
    }
}
