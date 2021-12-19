using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
   

    private Vector2 moveDirection;

    public GameObject interactIcon;
    private Vector2 boxSize = new Vector2(0.1f, 1f); // The size of the collider box for entering a building
    private float rotationAngle = 0f;


    void Start() 
    {
        // Getting a reference to the Inventory UI
        // InventoryPopUp = GameObject.Find("/Inventory_Canvas/InventoryPopUp");
        // InventoryPopUp.SetActive(!InventoryPopUp.activeInHierarchy); // It has to be active in order to get a ref, so we set it to false on start
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        // Debug.Log("Were in update");
        
        float speedx = Input.GetAxisRaw("Horizontal");
        float speedy = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", speedx);
        animator.SetFloat("Vertical", speedy);

        //Debug.Log("Speed x =" + speedx + ", speed y = " + speedy);
        if (speedx != 0 || speedy != 0) { 
        animator.SetBool("isRunning", true);
        //FindObjectOfType<AudioManager>().Play("playerwalksound"); 
        }
        else
            animator.SetBool("isRunning", false);

        if (Input.GetKeyDown(KeyCode.Q)) {BackToMainMenu();}

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("'e' was pressed");
            CheckInteraction();
        }

        
        // Toggle Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            // InventoryPopUp.SetActive(!InventoryPopUp.activeInHierarchy);
            // Debug.Log("InventoryPopUp is set to: " + InventoryPopUp.activeInHierarchy);
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

    // Not implemented but used for text pop-up when you can enter a building - NudNud
    // public void OnTriggerEnter(Collider other) {
    //     var item = other.GetComponent<SOMETHING>();
    // }
}

