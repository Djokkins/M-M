using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float runSpeed = 200f;
    private float rollSpeed = 450f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isRolling = false;
    private bool attacking = false;
    private bool run = false;
    private float direction = 1;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        // Health = FindObjectOfType<Stats>().Health;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isRolling) {
                if (input != 0) {
                    direction = input;
                }
                
                horizontalMove = input * runSpeed * 1.5f;
                run = true;
            }
            else
                horizontalMove = rollSpeed * direction;
        }
        else
        {
            if (!isRolling) {
                if (input != 0)
                {
                    direction = input;
                }
                horizontalMove = input * runSpeed;
                run = false;
            }
            else
                horizontalMove = rollSpeed * direction;

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

        if (Input.GetKeyDown(KeyCode.K) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 2") && !animator.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {
            animator.SetTrigger("Attack1");

            
        }
        if (Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {
            animator.SetTrigger("Attack2");
        }

        

        
        if (Input.GetKeyDown(KeyCode.C) && !animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            isRolling = true;
            animator.SetTrigger("isRolling");
        }
        else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {
            isRolling = false;
        }

    }


    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }


    // Moving the character function
    void FixedUpdate()
    {
        //Debug.Log("rolling = " + isRolling);
        controller.Move(horizontalMove * Time.fixedDeltaTime, isRolling, jump);
        jump = false;
        crouch = false;
    }
    
}
