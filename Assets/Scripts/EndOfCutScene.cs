using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfCutScene : MonoBehaviour
{
    void OnEnable() 
    {
        Debug.Log("The cutscene has ended");
        SceneManager.LoadScene("MainHub");
    }
    
}
