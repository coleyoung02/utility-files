using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private List<AudioSource> sources;
    [SerializeField] private AudioMixer mixer;
    private int soundIndex;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        soundIndex = 0;
    }

    private void Start()
    { 
        SetMusicVol(PlayerPrefs.GetFloat(VolumeSlider.MusicVol, .3f));
        SetSFXVol(PlayerPrefs.GetFloat(VolumeSlider.SFXVol, 1f));
    }

    private void PlayUISound(AudioClip clip)
    {
        sources[soundIndex].clip = clip;
        sources[soundIndex].pitch = Random.Range(.95f, 1.05f);
        sources[soundIndex].volume = Random.Range(.85f, 1f);
        sources[soundIndex].Play();
    }

    public void SetMusicVol(float value)
    {
        mixer.SetFloat(VolumeSlider.MusicVol, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(VolumeSlider.MusicVol, value);
    }

    public void SetSFXVol(float value)
    {
        mixer.SetFloat(VolumeSlider.SFXVol, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(VolumeSlider.SFXVol, value);
    }
}
