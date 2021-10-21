using UnityEngine;

namespace Hungath.Game
{
	public class GameManager : MonoBehaviour
	{
		private static System.Random random = new System.Random();

		public static int[] GetMapSize(int population)
		{
			float value = Mathf.Sqrt(population / 2.0f);
			float fValue = Mathf.Floor(value);

			if (fValue < Globals.MapDimensionMin)
			{
				return new int[] {Globals.MapDimensionMin, Globals.MapDimensionMin};
			}

			if (value > Globals.MapDimensionMax)
			{
				return new int[] {Globals.MapDimensionMax, Globals.MapDimensionMax};
			}

			if (value == fValue)
			{
				return new int[] {(int) fValue, (int) fValue};
			}
			else if (value - fValue < 0.5)
			{ 
				return new int[] {(int) fValue + 1, (int) fValue};
			}
			else
			{
				return new int[] {(int) fValue + 1, (int) fValue + 1};
			}
		}
	}
}
