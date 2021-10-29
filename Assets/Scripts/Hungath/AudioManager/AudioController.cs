using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hungath.AudioManager
{
    public enum AudioClipBank
    {
        DebugChirp,
        SfxDart,
        SfxVocalChord,
        SfxTileFlip
    }
    public static class AudioController
    {
        public static void PlaySfx(AudioClipBank sound, AudioSource source)
        {
            if (GetSfx(sound).GetType() != typeof(AudioClip)) sound = AudioClipBank.DebugChirp;
            source.PlayOneShot(GetSfx(sound));
        }

        private static AudioClip GetSfx(AudioClipBank sound)
        {
            return sound switch
            {
                AudioClipBank.DebugChirp => Resources.Load<AudioClip>("Audio/SFX/54415__korgms2000b__short-cut-off-beep"),
                AudioClipBank.SfxDart => Resources.Load<AudioClip>("Audio/SFX/dart sound"),
                AudioClipBank.SfxVocalChord => Resources.Load<AudioClip>("Audio/SFX/Vocal_chord"),
                AudioClipBank.SfxTileFlip => Resources.Load<AudioClip>("Audio/SFX/StoneOnStoneVeryShort"),
                _ => throw new ArgumentNullException($"'{sound}' is not a valid AudioClipBank value.")
            };
        }
        
        public static void SaveVolumeLevels(GameObject optionsMenu)
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
        
        public static void LoadVolumeLevels(GameObject optionsMenu)
        {
            optionsMenu.GetComponent<CanvasGroup>().alpha = 0;
            optionsMenu.SetActive(true);
            GameObject.Find("MasterVolumeSlider").GetComponent<Slider>().value = Globals.MasterVolume;
            GameObject.Find("MusicVolumeSlider").GetComponent<Slider>().value = Globals.MusicVolume;
            GameObject.Find("SFXVolumeSlider").GetComponent<Slider>().value = Globals.SfxVolume;
            GameObject.Find("VoicesVolumeSlider").GetComponent<Slider>().value = Globals.VoicesVolume;
            optionsMenu.SetActive(false);
            optionsMenu.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}
