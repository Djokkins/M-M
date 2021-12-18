using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Creating variables
    //Controller and animator
    public CharacterController2D controller;
    public Animator animator;


    //movement variables
    private float runSpeed;
    private float rollSpeed;
    float horizontalMove;
    bool jump;
    bool isRolling;
    bool isJumping;
    private bool run;
    private float direction;

    //Resource externalization for damage
    PlayerDamage damage;
  
    public LayerMask enemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 100f;
        rollSpeed = 450f;
        horizontalMove = 0f;
        jump = false;
        isRolling = false;
        run = false;
        isJumping = false;
        direction = 1;
        isJumping = false;

        damage = animator.GetComponent<PlayerDamage>();


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
            else { 
                horizontalMove = rollSpeed * direction;
            }
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
            else { 
                horizontalMove = rollSpeed * direction;
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
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            isJumping = true;
        }


        //if (Input.GetButtonDown("Crouch"))
        //{ crouch = true; }



        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("roll") && !isJumping && Input.GetKeyDown(KeyCode.K) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 2"))
        {
            //damage.Attack1(); this doesnt work as we are triggering the animator from inside the function and thus we cannot time the damage with the animation
            //we want to call animator.setTrigger("Attack1") and then call the attack function using an event inside the animation itself
            animator.SetTrigger("Attack1");

        }
            
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("roll") && !isJumping && Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 1"))
        {
            //damage.Attack2();
            animator.SetTrigger("Attack2");
        }

        

        
        if (Input.GetKeyDown(KeyCode.C) && !animator.GetCurrentAnimatorStateInfo(0).IsName("jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
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
        isJumping = false;
    }


    // Moving the character function
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isRolling, jump);
        jump = false;
    }
    
}
