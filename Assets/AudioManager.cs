using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sonds")]
    public AudioClip ambienteClip;
    public AudioClip starClip;
    public AudioClip touchClip;
    public AudioClip destroyClip;

    [Header("Mixids")]
    public AudioMixerGroup groupAmbiente;
    public AudioMixerGroup groupEffects;


    AudioSource ambienteSource;
    AudioSource starSource;
    AudioSource touchSource;
    AudioSource destroySource;

    void Awake()
    {
        if(instance !=null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        //Create audio source
        ambienteSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        starSource=gameObject.AddComponent<AudioSource>()as AudioSource;
        touchSource = gameObject.AddComponent<AudioSource>();
        destroySource= gameObject.AddComponent<AudioSource>();

        //Add ground mixed
        ambienteSource.outputAudioMixerGroup = groupAmbiente;
        starSource.outputAudioMixerGroup = groupEffects;
        touchSource.outputAudioMixerGroup = groupEffects;
        destroySource.outputAudioMixerGroup = groupEffects;
        
        //add clips

        StartAudioAmbient();
    }

    private void StartAudioAmbient()
    {
        ambienteSource.clip= ambienteClip;
        ambienteSource.loop = true;
        ambienteSource.Play();

        starSource.clip = starClip;
        touchSource.clip = touchClip;
        destroySource.clip = destroyClip;
    }


    public static void PlayTouchSoung() { 
        if(instance==null || instance.touchSource.isPlaying)
        {
            return;
        }
        instance.touchSource.Play();
    }

    public static void PlayDestroySoung()
    {
        if (instance == null || instance.destroySource.isPlaying)
        {
            return;
        }
        instance.destroySource.Play();
    }

    public static void PlayStarSoung()
    {
        if (instance == null || instance.starSource.isPlaying)
        {
            return;
        }
        instance.starSource.Play();
    }

}
