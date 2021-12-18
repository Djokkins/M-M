using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    Resolution[] resolutions;
    
    public Toggle fullscreenToggle;
    public Slider audioLevel;
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;

    private void Start()
    {
        

        bool fullscreen = Screen.fullScreen;
        fullscreenToggle.isOn = fullscreen;

        float storedVolume = PlayerPrefs.GetFloat("StoredVolume", 0f);
        audioLevel.value = storedVolume;
        audioMixer.SetFloat("masterVolume", storedVolume);




        //Get the list of resolutions and add it to our dropdown menu
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();


        //Make the list of resolutions as nice strings for the dropdown
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }

    public void setResolution(int index)
    {
        Debug.Log("We get into setResolution");
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
    }

    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("StoredVolume", volume);
    }



    public void SetFullscreen(bool toggle)
    {
        Debug.Log("We get into setFullScreen");
        Screen.fullScreen = toggle;
    }

}
