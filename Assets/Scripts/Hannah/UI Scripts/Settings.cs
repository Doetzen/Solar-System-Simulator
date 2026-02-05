using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [Header("VolumeSliders")]
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    [Header("Resolutions")]
    public TMP_Dropdown resolutionDropdown;
    Resolution[] allResolutions;
    public int selectedResolution;
    private List<Resolution> filteredResolution;
    private List<Resolution> selectedResolutionList = new List<Resolution>();

    public bool isFullScreen;


    public void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        }
        else
        {
            PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        }
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        }

        allResolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach(Resolution res in allResolutions)
        {
            newRes = res.width.ToString() + "x" + res.height.ToString();
            
            if(!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                selectedResolutionList.Add(res);
            }

            resolutionStringList.Add(res.ToString());
        }

        resolutionDropdown.AddOptions(resolutionStringList);


    }

    public void ChangeRes()
    {
        selectedResolution = resolutionDropdown.value;

        Screen.SetResolution(selectedResolutionList[selectedResolution].width, selectedResolutionList[selectedResolution].height, isFullScreen); 
    }

    public void SetMaster(float sliderValue)
    {
        audioMixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);

    }

    public void SetMusic(float sliderValue)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

    }

    public void SetSFX(float sliderValue)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

