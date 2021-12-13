using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float runSpeed = 200f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        // Health = FindObjectOfType<Stats>().Health;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else animator.SetBool("isRunning", false);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("We got here Ayyy");
            jump = true;
        } 

        if (Input.GetButtonDown("Crouch"))
        {crouch = true;}

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Attack2");
        }



    }

    // Moving the character function
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }

}
