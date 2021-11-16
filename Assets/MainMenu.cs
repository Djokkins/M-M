using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 'PLAY' button to enter the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // 'QUIT' button to exit the game
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
