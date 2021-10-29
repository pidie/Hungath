using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hungath.AudioManager;

namespace Hungath.UIManager.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject optionsMenu;

        private void Awake()
        {
            AudioController.LoadVolumeLevels(optionsMenu);
        }

        public void StartNewGame()
        {
            AudioController.SaveVolumeLevels(optionsMenu);
            StartCoroutine(StartGame());
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
