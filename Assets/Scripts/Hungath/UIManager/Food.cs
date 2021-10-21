using System;
using TMPro;
using UnityEngine;

namespace Hungath.UIManager
{
    public class Food : MonoBehaviour
    {
        private static float food;
        private static bool starvation;
        [SerializeField] private TMP_Text foodText; 

        public static float GetFood()
        {
            return food;
        }
        
        public static void AdjustFood(int amount)
        {
            food += amount;
        }

        private void Awake()
        {
            food = 50f;
        }

        private void Update()
        {
            CheckForStarvation();
            int rubberFood = (int) Mathf.Floor(food);
            foodText.text = $"Food: {rubberFood.ToString()}";
        }

        private void CheckForStarvation()
        {
            if (food < 1)
            {
                starvation = true;
            }

            if (starvation && food > 1)
            {
                starvation = false;
            }
        }
    }
}
