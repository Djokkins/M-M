using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// No idea if this is necessary
// [RequireComponent(typeof(int))]
public class GoToScene : Interactable
{

    public Animator transition;
    public float transitiontime = 1f;

    public override void Interact()
    {
        // Go back to start screen
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(sceneName);
        //StartCoroutine(LoadLevel("FightArena"));
    }

     IEnumerator LoadLevel (string scenename){
        transition.SetTrigger("StartLevelChange");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
