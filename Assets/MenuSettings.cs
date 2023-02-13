using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer audio;
    public Slider slider;
    public void Volume(float volume)
    {
        

        audio.SetFloat("volumeMixer",volume);
        PlayerPrefs.SetFloat("volume", volume);
        Debug.Log("your player prefs is   " + PlayerPrefs.GetFloat("volume"));
        PlayerPrefs.Save();

    }
    private void Start()
    {
        Debug.Log("saved volume = " + PlayerPrefs.GetFloat("volume"));
        slider.value = PlayerPrefs.GetFloat("volume");
    }


}
