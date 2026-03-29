using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer _audioMixer;
    [SerializeField] private SettingsManager _settingManager;

    public float _masterVolume;
    public float _soundFxVolume;
    public float _musicVolume;

    private void Start()
    {
        _settingManager.LoadSettings();
    }
    public void SetMasterVolume (float volume)
    {
        _masterVolume = volume;
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(_masterVolume) * 20f);
    }

    public void SetSoundFxVolume(float volume)
    {
        _soundFxVolume = volume;
        _audioMixer.SetFloat("SoundFxVolume", Mathf.Log10(_soundFxVolume) * 20f);
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20f);
    }
}
