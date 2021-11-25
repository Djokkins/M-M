using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb; 

    private Vector2 moveDirection;

    public GameObject interactIcon;
    private Vector2 boxSize = new Vector2(0.1f, 1f); // The size of the collider box for entering a building
    private float rotationAngle = 0f;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if(Input.GetKeyDown("q")) {BackToMainMenu();}

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("'e' was pressed");
            CheckInteraction();
        }

    }


    void FixedUpdate() 
    {
        Move();
    }


    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    // Implementation for opbject interaction
    private void CheckInteraction()
    {
        // Make an array of all the collisions in case we have some overlapping
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, rotationAngle, Vector2.zero);

        if(hits.Length > 0)
        {

            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return; //Insure that we only call on a single interactable object
                }
            }
        }
    }

    public void OpenInteractableIcon()
    {
        Debug.Log("InteractIcon is true");
        interactIcon.SetActive(true);
    }

        public void CloseInteractableIcon()
    {
        Debug.Log("InteractIcon is false");
        interactIcon.SetActive(false);
    }
    

    // Implementation for scene navigation
    void BackToMainMenu()
    {
        // Go back to start screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
