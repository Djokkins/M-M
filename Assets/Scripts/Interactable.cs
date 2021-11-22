
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public string sceneName;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }


    public abstract void Interact();


    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.CompareTag("Player"))
                collision.GetComponent<TopDownPlayerMovement>().OpenInteractableIcon();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if(collision.CompareTag("Player"))
                collision.GetComponent<TopDownPlayerMovement>().CloseInteractableIcon();
    }
}
