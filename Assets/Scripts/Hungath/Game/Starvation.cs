using Hungath.UIManager;
using Random = System.Random;

namespace Hungath.Game
{
	public static class Starvation
	{
		private static Random _random;
		private static int _starved;
		
		public static void CheckForStarvation()
		{
			_random = new Random();
			if (Food.GetFood() < 1)
			{
				_starved = 1;
				Population.TotalPop -= _starved;
				if (_random.Next(0, 1) > 0) Population.GathererPop -= 1;
				else Population.HunterPop -= 1;
				BannerMessage.CreateNewBannerMessage(BannerMessageType.AlertPopulationDecreaseStarvation, _starved);
			}
		}
	}
}
