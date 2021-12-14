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
    private bool attacking = false;
    private bool run = false;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        // Health = FindObjectOfType<Stats>().Health;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            horizontalMove = 0.0f;
        }
        else { 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * 1.5f;
                run = true;
            }
            else
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                run = false;
            }
        }





        handleAnimations();
    }

    public void handleAnimations()
    {
        if (horizontalMove != 0)
        {
            if (run)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            Debug.Log("Nothing");
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }


        if (Input.GetButtonDown("Crouch"))
        { crouch = true; }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isRolling");
        }
    }


    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }


    // Moving the character function
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }
    
}
