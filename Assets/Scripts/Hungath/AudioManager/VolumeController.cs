using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Hungath.AudioManager
{
    public class VolumeController : MonoBehaviour
    {
        public Slider volumeSlider;
        public TMP_Text volumeText;
        public Toggle volumeToggle;
        public AudioMixer audioMixer;
        public string audioGroup;

        private float _currentVolume;

        private void Awake() => SetVolume();

        public void SetVolume()
        {
            volumeText.text = Mathf.RoundToInt(100 + volumeSlider.value * 1.25f) + "%";
            audioMixer.SetFloat(audioGroup, volumeSlider.value);
        }

        public void ToggleVolume()
        {
            if (!volumeToggle.isOn)
            {
                SaveVolumeValue();
                volumeSlider.interactable = false;
            }
            else
            {
                RestoreVolumeValue();
                volumeSlider.interactable = true;
            }
        }

        private void SaveVolumeValue()
        {
            _currentVolume = volumeSlider.value;
            volumeSlider.value = -80f;
        }

        private void RestoreVolumeValue() => volumeSlider.value = _currentVolume;
    }
}
