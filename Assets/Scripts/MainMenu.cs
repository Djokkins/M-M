using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 'PLAY' button to enter the game
    private bool cutScenePlayed;
    public Animator transition;
    public float transitiontime = 1f;

    public void Start()
    {
        if(PlayerPrefs.GetInt("IntroCutScenePlayed", 0) == 0) {
            PlayerPrefs.SetInt("IntroCutScenePlayed", 1);
            cutScenePlayed = false;
        }
        else
        {
            cutScenePlayed = true;
            FindObjectOfType<AudioManager>().Play("introsound");
        }
    }
    

    public void PlayGame()
    {
        Debug.Log("THis is a test");
        if (cutScenePlayed)
        {
            StartCoroutine(LoadLevel("MainHub"));
            Debug.Log("Just Some change");
        }

        else
        {
            StartCoroutine(LoadLevel("IntroCutScene"));
            cutScenePlayed = true;
        }
    }

   IEnumerator LoadLevel (string scenename){
        transition.SetTrigger("StartLevelChange");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(scenename);
    }

    // 'QUIT' button to exit the game
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
