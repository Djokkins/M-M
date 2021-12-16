using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SureMenuUI;

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
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void optionsClick()
    {

    }

    public void menuClick()
    {
        PauseMenuUI.SetActive(false);
        SureMenuUI.SetActive(true);
    }

    public void goMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    
    public void goPause()
    {
        PauseMenuUI.SetActive(true);
        SureMenuUI.SetActive(false);
    }


}
