using System;
using Hungath.Game;
using Hungath.AudioManager;
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
        private AudioSource _audioSource;
 
        public GameObject face;

        private void Awake()
        {
            isFaceDown = true;
            transform.rotation = Quaternion.Euler(90, 0, 0);
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (!isFaceDown) return;
            
            isFaceDown = false;
            transform.rotation = Quaternion.Euler(270f, 180f, 0);
            Breeding.CheckForBirth();
            AudioController.PlaySfx(AudioClipBank.SfxTileFlip, _audioSource);
            Activate();
            Starvation.CheckForStarvation();
        }

        private void Activate()
        {
            switch (tileType)
            {
                case TileType.Berry:
                    var foodGain = Population.GathererPop;
                    Food.AdjustFood(foodGain);
                    NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertFoodGain, foodGain);
                    break;
                case TileType.Goat:
                    foodGain = Population.HunterPop * 3;
                    Food.AdjustFood(foodGain);
                    NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertFoodGain, foodGain);
                    break;
                case TileType.Fish:
                    foodGain = Population.HunterPop * 4;
                    Food.AdjustFood(foodGain);
                    NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertFoodGain, foodGain);
                    break;
                case TileType.Herd:
                    foodGain = Population.HunterPop * 6;
                    Food.AdjustFood(foodGain);
                    NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertFoodGain, foodGain);
                    break;
                case TileType.Land:
                    Food.AdjustFood(-Population.TotalPop);
                    break;
                case TileType.Predator:
                    const int popLost = 1;      //this is only temporarily a constant
                    var popTypeLost = "";

                    if (Population.HunterPop > 0)
                    {
                        Population.HunterPop -= popLost;
                        popTypeLost = "Hunter";
                    }
                    else if (Population.GathererPop > 0)
                    {
                        Population.GathererPop -= popLost;
                        popTypeLost = "Gatherer";
                    }
                    else
                    {
                        NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertGameOver);
                        return;
                    }
                
                    Population.TotalPop -= popLost;
                    NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertPopulationDecreasePredator, popLost, popTypeLost);
                    break;
                default:
                    throw new NotImplementedException("No tile!");
            }
        }
    }
}
