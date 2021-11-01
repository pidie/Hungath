using Hungath.UIManager;
using Hungath.UIManager.Notifications;
using Random = System.Random;

namespace Hungath.Main
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

				var popTypeLost = "";
				var lostHunter = false;
				var lostHunters = 0;
				var lostGatherer = false;
				var lostGatherers = 0;

				for (int i = 0; i < _starved; i++)
				{
					if (_random.Next(0, 1) > 0)
					{
						Population.GathererPop -= _starved;
						popTypeLost = "Gatherer";
						lostGatherer = true;
						lostGatherers++;
					}
					else
					{
						Population.HunterPop -= _starved;
						popTypeLost = "Hunter";
						lostHunter = true;
						lostHunters++;
					}
				}

				if (_starved > 1) popTypeLost += "s";
				if (lostGatherer && lostHunter) NotificationMessage.CreateNewNotificationMessage(
					NotificationMessageType.AlertPopulationDecreaseStarvationBothTypes, lostGatherers, "Gatherers", lostHunters, "Hunters");
				else NotificationMessage.CreateNewNotificationMessage(NotificationMessageType.AlertPopulationDecreaseStarvationOneType, _starved, popTypeLost);
			}
		}
	}
}
