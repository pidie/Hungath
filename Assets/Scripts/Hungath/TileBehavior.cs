using Hungath.Game;
using Hungath.UIManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hungath
{
    public class TileBehavior : MonoBehaviour
    {
        public TileType tileType;
        public Material tileImage, tileBackImage;
        public bool isFaceDown;
        public bool isGolden;
 
        public GameObject face;

        private void Awake()
        {
            isFaceDown = true;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            else
            {
                if (isFaceDown)
                {
                    isFaceDown = false;
                    transform.rotation = Quaternion.Euler(270f, 180f, 0);
                    Breeding.CheckForBirth();
                    Activate();
                    Starvation.CheckForStarvation();
                }
            }
        }

        private void Activate()
        {
            if (tileType == TileType.Berry)
            {
                int foodGain = Population.GathererPop;
                Food.AdjustFood(foodGain);
                BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertFoodGain, foodGain);
            }
            else if (tileType == TileType.Land)
            {
                Food.AdjustFood(-Population.TotalPop);
            }
            else if (tileType == TileType.Goat)
            {
                int foodGain = Population.HunterPop * 3;
                Food.AdjustFood(foodGain);
                BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertFoodGain, foodGain);
            }
            else if (tileType == TileType.Predator)
            {
                int popLost = 1;

                if (Population.HunterPop > 0)           Population.HunterPop -= popLost;
                else if (Population.GathererPop > 0)    Population.GathererPop -= popLost;
                else
                {
                    BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertGameOver);
                    return;
                }
                
                Population.TotalPop -= popLost;
                BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertPopulationDecreasePredator, popLost);
            }
        }
    }
}
