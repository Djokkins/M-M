using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// No idea if this is necessary
// [RequireComponent(typeof(int))]
public class GoToScene : Interactable
{
    public override void Interact()
    {
        // Go back to start screen
        // Debug.Log("THIIS FUCKING WORKS");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(sceneName);
    }
}
