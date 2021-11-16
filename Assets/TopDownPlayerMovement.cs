using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb; 

    private Vector2 moveDirection;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if(Input.GetKeyDown("q"))
        {
            BackToMainMenu();
        }

        if(Input.GetKeyDown("e"))
        {
            Debug.Log("'e' was pressed");
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

    void BackToMainMenu()
    {
        // Go back to start screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
