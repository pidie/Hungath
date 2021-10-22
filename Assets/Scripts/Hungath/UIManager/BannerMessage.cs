using System;
using UnityEngine;

public enum BannerMessageType
{
    DebugBlank = 0,
    AlertPopulationGrowth = 16,
    AlertFoodGain = 17,
    AlertPopulationDecreasePredator = 18,
    AlertPopulationDecreaseDisease = 19,
    WarningGenericGameError = 48,
}
namespace Hungath.UIManager
{
    public static class BannerMessage
    {
        private static string _message;

        public static void CreateNewBannerMessage(BannerMessageType bannerMessageType, dynamic value1=null, dynamic value2=null)
        {
            switch (bannerMessageType)
            {
                case BannerMessageType.DebugBlank:
                    _message = "";
                    break;
                case BannerMessageType.AlertFoodGain:
                    _message = $"You gained {value1} food!";
                    break;
                case BannerMessageType.AlertPopulationGrowth:
                    _message = $"Your Population increased by {value1}!";
                    break;
                case BannerMessageType.AlertPopulationDecreasePredator:
                    _message = $"A predator has killed {value1} of your Population.";
                    break;
                case BannerMessageType.AlertPopulationDecreaseDisease:
                    _message = $"Disease has killed {value1} of your Population.";
                    break;
                case BannerMessageType.WarningGenericGameError:
                    _message = $"Oops, something went wrong!";
                    break;
                default:
                    throw new NotImplementedException();
            }

            int messageType;

            if ((int) bannerMessageType == 0) messageType = -1;
            else if ((int) bannerMessageType < 16) messageType = 0;
            else if ((int) bannerMessageType >= 48) messageType = 2;
            else messageType = 1;
            
            ActivateBanner(messageType);
        }

        private static void ActivateBanner(int messageType)
        {
            Banner banner = GameObject.FindObjectOfType<Banner>();

            if (messageType == -1)      banner.background.color = new Color(0, 0, 0, 0);
            else if (messageType == 0)  banner.background.color = Color.cyan;
            else if (messageType == 1)  banner.background.color = Color.black;
            else if (messageType == 2)  banner.background.color = Color.red;
            
            banner.bannerMessage.text = _message;
            banner.background.enabled = true;
        }
    }
}
