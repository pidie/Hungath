using System.Collections;
using System.Collections.Generic;
using Hungath.UIManager;
using UnityEngine;

namespace Hungath.Game
{
    public static class Breeding
    {
        private static System.Random _random;

        public static void CheckForBirth()
        {
            _random = new System.Random();
            
            float food = Food.GetFood();
            int pop = Population.TotalPop;

            float foodPopRatio = food / pop;
            int roll = _random.Next(1, 20);

            int children = 0;
            
            if (roll <= foodPopRatio * 2)
            {
                children++;
                int twinCheck = _random.Next(1, 20);
                if (twinCheck == 20)
                {
                    children++;
                }
            }
            
            GiveBirth(children);
        }
        
        private static void GiveBirth(int amount)
        {
            Population.TotalPop += amount;
        }
    }
}