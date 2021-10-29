using System;
using UnityEngine;

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
            Debug.Log(GetSfx(sound));
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
    }
}
