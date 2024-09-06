using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance {  get; private set; }

    AudioSource audioEffect;

    public AudioClip plusSound;
    public AudioClip downSound;
    public AudioClip speedSound;
    public AudioClip jumpSound;
    public AudioClip missSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioEffect = GetComponent<AudioSource>();
    }
    public void PlayPlusSound()
    {
        audioEffect.PlayOneShot(plusSound);
    }

    public void PlayDownSound()
    {
        audioEffect.PlayOneShot(downSound);
    }

    public void PlaySpeedSound()
    {
        audioEffect.PlayOneShot(speedSound);
    }
    public void PlayJumpSound()
    {
        audioEffect.PlayOneShot(jumpSound);
    }
    public void PlayMissSound()
    {
        audioEffect.PlayOneShot(missSound);
    }
}
