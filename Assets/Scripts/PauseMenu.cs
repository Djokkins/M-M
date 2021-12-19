using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SureMenuUI;
    public GameObject SettingsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if (isPaused)
            {
                onResume();
                FindObjectOfType<AudioManager>().Play("pausemenuclosesound");
            }
            else
            {
                onPause();
                FindObjectOfType<AudioManager>().Play("pausemenuopensound");
            }
        }
    }


    public void onPause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        FindObjectOfType<AudioManager>().Play("click");
    
    }

    public void onResume()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        SureMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void optionsClick()
    {
        SettingsMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void menuClick()
    {
        PauseMenuUI.SetActive(false);
        SureMenuUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void goMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("click");
    }
    
    public void goPause()
    {
        PauseMenuUI.SetActive(true);
        SureMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void Cancel()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void Save()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }


}
