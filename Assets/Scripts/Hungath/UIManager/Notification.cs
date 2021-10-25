using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.UIManager
{
    public class Notification : MonoBehaviour
    {
        public TMP_Text notificationMessage;
        public Image background;
        public Transform spawnPoint;

        private void Awake()
        {
            notificationMessage = GetComponentInChildren<TMP_Text>();
            background = GetComponentInChildren<Image>();
            spawnPoint = GameObject.Find("NotificationSpawnPoint").transform;
            // StartCoroutine(ThreeSecondKillSwitch());
        }

        private void Update() => PositionNotification();

        private void PositionNotification()
        {
            // transform.position = spawnPoint.position;
            var position = spawnPoint.position;
            var notificationOffset = 0f;
            foreach (Transform notification in spawnPoint)
            {
                notification.position = new Vector3(position.x, position.y - notificationOffset, position.z);
                notificationOffset += Screen.height * 0.110f;
            }
        }

        //called by Event Trigger in inspector (on background)
        public void OnPointerClickNotification() => background = background; //FadeNotificationMessage();

        public void FadeNotificationMessage() => StartCoroutine(nameof(FadeNotificationMessageCoroutine));

        public IEnumerator FadeNotificationMessageCoroutine()
        {
            while (background.color != Color.clear)
            {
                background.color = Color.Lerp(background.color, Color.clear, .02f);
                notificationMessage.color = Color.Lerp(notificationMessage.color, Color.clear, .02f);
                
                if (background.color.a < 0.1) Destroy(gameObject);
                yield return null;
            }
        }

        public IEnumerator ThreeSecondKillSwitch()
        {
            yield return new WaitForSeconds(3f);
            StartCoroutine(FadeNotificationMessageCoroutine());
        }
    }
}
