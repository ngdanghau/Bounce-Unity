using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        // set background (optinal)
        // musicSource.clip = background;
        // musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
