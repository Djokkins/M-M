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
            }
            else
            {
                onPause();
            }
        }
    }


    public void onPause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    
    }

    public void onResume()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        SureMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void optionsClick()
    {
        SettingsMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    public void menuClick()
    {
        PauseMenuUI.SetActive(false);
        SureMenuUI.SetActive(true);
    }

    public void goMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    
    public void goPause()
    {
        PauseMenuUI.SetActive(true);
        SureMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
    }

    public void Cancel()
    {

    }

    public void Save()
    {

    }


}
