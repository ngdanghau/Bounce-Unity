using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("---- Audio Source ----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---- Audio Source ----")]
    public AudioClip buttonEffect;
    public AudioClip pickupItem;
    public AudioClip characterPop;
    public AudioClip pickupObstacle;

    [SerializeField] AudioMixer myMixer;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // set background (optinal)
        // musicSource.clip = background;
        // musicSource.Play();

        LoadSFXVolume();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void SetSFXVolume(bool isOn = true)
    {
        float value = 0.001f;
        if (isOn)
        {
            value = 1f;
        }

        myMixer.SetFloat("sfx", Mathf.Log10(value) * 20);
        PlayerPrefs.SetInt("sfxVolume", isOn ? 1 : 0);
    }

    public void LoadSFXVolume()
    {
        bool isOn = GetSFXVolume();
        SetSFXVolume(isOn);
    }
    
    public bool GetSFXVolume()
    {
        return PlayerPrefs.GetInt("sfxVolume", 1) == 1;
    }
}
