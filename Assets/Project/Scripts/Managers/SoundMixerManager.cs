using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetMasterVolume (float volume)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetSoundFxVolume(float volume)
    {
        _audioMixer.SetFloat("SoundFxVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20f);
    }
}
