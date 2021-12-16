using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 'PLAY' button to enter the game
    private bool cutScenePlayed;

    public void Start()
    {
        if(PlayerPrefs.GetInt("IntroCutScenePlayed", 0) == 0) {
            PlayerPrefs.SetInt("IntroCutScenePlayed", 1);
            cutScenePlayed = false;
        }
        else
        {
            cutScenePlayed = true;
        }
    }
    

    public void PlayGame()
    {
        Debug.Log("THis is a test");
        if (cutScenePlayed)
        {
            SceneManager.LoadScene("MainHub");
            Debug.Log("Just Some change");
        }

        else
        {
            SceneManager.LoadScene("IntroCutScene");
            cutScenePlayed = true;
        }
    }

    // 'QUIT' button to exit the game
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
