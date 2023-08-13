using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsCtrl : MonoBehaviour
{
    public GameObject uiSettings;
    public AudioMixer audioMixer;

    float volumenAmbien = 1f;
    float volumenEffects = 1f;

    public Slider sliderAmbie,sliderEffects;
    // Start is called before the first frame update
    void Start()
    {
        volumenAmbien=    PlayerPrefs.GetFloat("volumenAmbien", 1f);
        volumenEffects = PlayerPrefs.GetFloat("volumenEffects", 1f);
        SetChangeAudioAmbient(volumenAmbien);
        SetChangeAudioEffects(volumenEffects);
    }

    public void ShowSettings()
    {
        if(sliderAmbie != null && sliderEffects !=null)
        {
            sliderAmbie.value = volumenAmbien;
            sliderEffects.value = volumenEffects;
        }
        uiSettings.SetActive(true);
    }
    public void CloseSettings()
    {
        uiSettings.SetActive(false);
    }

    public void SetChangeAudioAmbient(float value)
    {
        audioMixer.SetFloat("AmbientVolumen", value);
        PlayerPrefs.SetFloat("volumenAmbien", value);
    }
    public void SetChangeAudioEffects(float value)
    {
        audioMixer.SetFloat("EffextsVolumen", value);
        PlayerPrefs.SetFloat("volumenEffects", value);
    }
}
