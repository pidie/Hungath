using Hungath.UIManager;

namespace Hungath.Game
{
    public static class Breeding
    {
        private static System.Random _random;

        public static void CheckForBirth()
        {
            _random = new System.Random();
            
            var foodPopRatio = Food.GetFood() / Population.TotalPop;
            var roll = _random.Next(1, 20);

            var children = 0;

            if (roll <= foodPopRatio)
            {
                children++;
                var messageType = BannerMessageType.AlertPopulationGrowth;
                int twinCheck = _random.Next(1, 20);
                if (twinCheck == 20)
                {
                    children++;
                    messageType = BannerMessageType.AlertPopulationGrowthTwin;
                }
                BannerMessage.CreateNewBannerMessage(messageType, children);
            }
            GiveBirth(children);
        }
        
        private static void GiveBirth(int amount) => Population.TotalPop += amount;
    }
}