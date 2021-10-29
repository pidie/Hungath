using UnityEngine;
using Hungath.AudioManager;
using UnityEngine.SceneManagement;

namespace Hungath.Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject optionsMenu;
		[SerializeField]
		private GameObject confirmExitMenu;

		private void Awake()
		{
			AudioController.LoadVolumeLevels(optionsMenu);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ToggleOptionsMenu();
			}
		}

		public void ConfirmExitGame()
		{
			optionsMenu.GetComponent<CanvasGroup>().alpha = 0.1f;
			confirmExitMenu.SetActive(true);
		}

		public void StayInGame()
		{
			confirmExitMenu.SetActive(false);
			optionsMenu.GetComponent<CanvasGroup>().alpha = 1;
		}

		public void ReturnToMainMenu()
		{
			AudioController.SaveVolumeLevels(optionsMenu);
			SceneManager.LoadScene("MainMenu");
		}

		public void ToggleOptionsMenu() => optionsMenu.SetActive(!optionsMenu.activeSelf);

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
