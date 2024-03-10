using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource audioSource;

    public AudioClip popSound;

    void Awake()
    {
        instance = this;
    }

    public static void PlayMergeSound()
    {
        instance.audioSource.PlayOneShot(instance.popSound);
    }

}