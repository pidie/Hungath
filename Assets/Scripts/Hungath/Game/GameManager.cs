using UnityEngine;
using UnityEngine.UI;

namespace Hungath.Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject optionsMenu;

		private void Awake()
		{
			LoadVolumeLevels();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ToggleOptionsMenu();
			}
		}

		public void ToggleOptionsMenu()
		{
			optionsMenu.SetActive(!optionsMenu.activeSelf);
		}

		private static void LoadVolumeLevels()
		{
			GameObject.Find("MasterVolume/VolumeSlider").GetComponent<Slider>().value = Globals.MasterVolume;
			GameObject.Find("MusicVolume/VolumeSlider").GetComponent<Slider>().value = Globals.MusicVolume;
			GameObject.Find("SfxVolume/VolumeSlider").GetComponent<Slider>().value = Globals.SfxVolume;
			GameObject.Find("VoicesVolume/VolumeSlider").GetComponent<Slider>().value = Globals.VoicesVolume;
		}

		public static int[] GetMapSize(int population)
		{
			var value = Mathf.Sqrt(population / 2.0f);
			var fValue = Mathf.Floor(value);

			if (fValue < Globals.MapDimensionMin)	return new [] {Globals.MapDimensionMin, Globals.MapDimensionMin};
			if (value > Globals.MapDimensionMax)	return new [] {Globals.MapDimensionMax, Globals.MapDimensionMax};
			if (value == fValue)					return new [] {(int) fValue, (int) fValue};
			if (value - fValue < 0.5)				return new [] {(int) fValue + 1, (int) fValue};
			
			return new [] {(int) fValue + 1, (int) fValue + 1};
		}
	}
}
