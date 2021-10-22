using Hungath.Game;
using Hungath.UIManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hungath
{
    public class TileBehavior : MonoBehaviour
    {
        public TileType tileType;
        public Material tileImage;
        public Material tileBackImage;
        public bool isFaceDown;
        public bool isGolden;
 
        public GameObject face;
        private System.Random random;

        private void Awake()
        {
            isFaceDown = true;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else
            {
                if (isFaceDown)
                {
                    isFaceDown = false;
                    transform.rotation = Quaternion.Euler(270f, 180f, 0);
                    Breeding.CheckForBirth();
                    Activate();
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
                Population.HunterPop -= popLost;
                Population.TotalPop -= popLost;
                BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertPopulationDecreasePredator, popLost);
            }
        }
    }
}
