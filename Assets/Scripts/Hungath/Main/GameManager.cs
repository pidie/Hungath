using System.Linq;
using UnityEngine;
using Hungath.AudioManager;
using UnityEngine.SceneManagement;

namespace Hungath.Main
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject optionsMenu;
		[SerializeField]
		private GameObject confirmExitMenu;

		public static GameObject Tiles;
		public static bool IsRoundOver;

		private void Awake()
		{
			Tiles = GameObject.Find("Tiles");
			AudioController.LoadVolumeLevels(optionsMenu);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ToggleOptionsMenu();
			}

			if (IsRoundOver) NewRound();
		}

		public static int GetFaceDownTilesCount()
		{
			return Tiles.GetComponentInChildren<Transform>().Cast<Transform>().Count(
				tile => tile.gameObject.GetComponent<TileBehavior>().isFaceDown);
		}

		private void NewRound()
		{
			IsRoundOver = false;
			SceneManager.LoadScene("Game");
		}
		

		public void ConfirmExitGame()
		{
			optionsMenu.GetComponent<CanvasGroup>().alpha = 0.1f;
			confirmExitMenu.SetActive(true);
		}

		public void StayInGame()
		{
			Debug.Log(GetFaceDownTilesCount());
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
