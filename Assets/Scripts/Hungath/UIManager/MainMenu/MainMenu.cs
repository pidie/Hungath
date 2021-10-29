using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Hungath.UIManager.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject optionsMenu;

        public void StartNewGame()
        {
            SaveVolumeLevels();
            StartCoroutine(StartGame());
        }

        private void SaveVolumeLevels()
        {
            optionsMenu.GetComponent<CanvasGroup>().alpha = 0;
            optionsMenu.SetActive(true);
            Globals.MasterVolume = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>().value;
            Globals.MusicVolume = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>().value;
            Globals.SfxVolume = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>().value;
            Globals.VoicesVolume = GameObject.Find("VoicesVolumeSlider").GetComponent<Slider>().value;
            optionsMenu.SetActive(false);
            optionsMenu.GetComponent<CanvasGroup>().alpha = 1;
        }

        public void QuitGame() => Application.Quit();

        public void ToggleOptionsMenu()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }

        public IEnumerator StartGame()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Game");
        }
    }
}
