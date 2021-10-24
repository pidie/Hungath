using System;
using UnityEngine;

public enum BannerMessageType
{
    DebugBlank = 0,
    AlertPopulationGrowth = 16,
    AlertFoodGain = 17,
    AlertPopulationDecreasePredator = 18,
    AlertPopulationDecreaseDisease = 19,
    AlertPopulationDecreaseStarvation = 20,
    AlertGameOver = 21,
    AlertPopulationGrowthTwin = 22,
    WarningGenericGameError = 48,
}
namespace Hungath.UIManager
{
    public static class BannerMessage
    {
        private static string _message;

        //todo: banners are being created one tile behind
        public static void CreateNewBannerMessage(BannerMessageType bannerMessageType, dynamic value1=null, 
            dynamic value2=null)
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
                    _message = $"Your Population has grown by {value1}!";
                    break;
                case BannerMessageType.AlertPopulationDecreasePredator:
                    _message = $"A predator has killed {value1} of your Population.";
                    break;
                case BannerMessageType.AlertPopulationDecreaseDisease:
                    _message = $"Disease has killed {value1} of your Population.";
                    break;
                case BannerMessageType.AlertPopulationDecreaseStarvation:
                    _message = $"You have lost {value1} Population due to Starvation!";
                    break;
                case BannerMessageType.AlertGameOver:
                    _message = "Your Population is dead! Game Over";
                    break;
                case BannerMessageType.AlertPopulationGrowthTwin:
                    _message = $"Your Population has had twins, and grown by {value1}!";
                    break;
                case BannerMessageType.WarningGenericGameError:
                    _message = "Oops, something went wrong!";
                    break;
                default:
                    throw new NotImplementedException("This BannerMessageType has not yet been implemented.");
            }
            
            ActivateBanner((int) bannerMessageType);
        }

        private static void ActivateBanner(int messageType)
        {
            var banner = Resources.Load<Banner>("Prefabs/Banner");
            MonoBehaviour.Instantiate(banner, GameObject.Find("BannerSpawnPoint").transform);
            banner.name = messageType.ToString();
            
            if      (messageType == 0)  banner.background.color = Color.clear;
            else if (messageType < 16)  banner.background.color = Color.cyan;
            else if (messageType < 48)  banner.background.color = Color.black;
            else                        banner.background.color = Color.red;
            
            banner.bannerMessage.color = Color.white;
            banner.bannerMessage.text = _message;
            banner.background.enabled = true;
        }
    }
}
