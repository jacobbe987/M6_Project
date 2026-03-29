using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager _instance;

    [SerializeField] private List<Sound> _fxSounds;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFxSound(string playSound)
    {
        var clip = _fxSounds.Find(t => t._soundName == playSound);
        if (clip != null)
        {
            _audioSource.clip = clip._soundClip;
            _audioSource.Play();
        }
    }


}
