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
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(sceneName);
    }
}
