using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum NotificationMessageType
{
    DebugBlank = 0,
    AlertPopulationGrowth = 16,
    AlertFoodGain = 17,
    AlertPopulationDecreasePredator = 18,
    AlertPopulationDecreaseDisease = 19,
    AlertPopulationDecreaseStarvationOneType = 20,
    AlertGameOver = 21,
    AlertPopulationGrowthTwin = 22,
    AlertPopulationDecreaseStarvationBothTypes = 23,
    WarningGenericGameError = 48,
}
namespace Hungath.UIManager
{
    public static class NotificationMessage
    {
        private static string _message;
        private static GameObject _notificationContainer = GameObject.Find("NotificationContainer");

        public static void CreateNewNotificationMessage(NotificationMessageType notificationMessageType, dynamic value1=null, 
            dynamic value2=null, dynamic value3=null, dynamic value4=null, dynamic value5=null)
        {
            _message = notificationMessageType switch
            {
                NotificationMessageType.DebugBlank => "",
                NotificationMessageType.AlertFoodGain => $"You gained {value1} food!",
                NotificationMessageType.AlertPopulationGrowth => $"Your Population has grown by {value1}!",
                NotificationMessageType.AlertPopulationDecreasePredator =>
                    $"A predator has killed {value1} of your {value2}s.",
                NotificationMessageType.AlertPopulationDecreaseDisease => $"Disease has killed {value1} of your Population.",
                NotificationMessageType.AlertPopulationDecreaseStarvationOneType =>
                    $"You have lost {value1} {value2} due to Starvation!",
                NotificationMessageType.AlertGameOver => "Your Population is dead! Game Over",
                NotificationMessageType.AlertPopulationGrowthTwin => $"Your Population has had twins, and grown by {value1}!",
                NotificationMessageType.AlertPopulationDecreaseStarvationBothTypes => 
                    $"You have lost {value1} {value2} and {value3} {value4} due to Starvation!",
                NotificationMessageType.WarningGenericGameError => "Oops, something went wrong!",
                _ => throw new NotImplementedException("This NotificationMessageType has not yet been implemented.")
            };

            ActivateNotification((int) notificationMessageType);
        }

        private static void ActivateNotification(int messageType)
        {
            var notification = Resources.Load<Notification>("Prefabs/Notification");
            notification.name = messageType.ToString();
            
            if      (messageType == 0)  notification.background.color = Color.clear;
            else if (messageType < 16)  notification.background.color = new Color32(0, 255, 255, 175);
            else if (messageType < 48)  notification.background.color = new Color32(24, 24, 24, 175);
            else                        notification.background.color = new Color32(255, 0, 0, 175);
            
            notification.notificationMessage.color = Color.white;
            notification.notificationMessage.text = _message;
            notification.background.enabled = true;
            Object.Instantiate(notification, _notificationContainer.transform);
        }
    }
}
