using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfCutScene : MonoBehaviour
{

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            OnEnable();
        }
    }

    void OnEnable() 
    {
        Debug.Log("The cutscene has ended");
        SceneManager.LoadScene("MainHub");
    }
    
}
