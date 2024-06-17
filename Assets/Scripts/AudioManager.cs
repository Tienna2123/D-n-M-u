using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Sources-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip kingdeath;
    public AudioClip humanjump;
    public AudioClip humanwalk;
    public AudioClip humanattack;
    public AudioClip hit;
    public AudioClip cleave;
    public AudioClip walk;
    public AudioClip checkpoint;
    public AudioClip key;
    public AudioClip coin;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlayVFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
