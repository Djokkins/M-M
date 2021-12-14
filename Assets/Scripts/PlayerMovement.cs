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
    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackRange1 = 0.5f;
    public float attackRange2 = 0.6f;
    
    public LayerMask enemyLayers;

    private int Health;
    public int count_debug = 0;

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
        else {
            //Debug.Log("Idle");
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
            Attack1();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Attack2();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isRolling");
        }
    }

    private void Attack1()
    {
        //Animation for slow attack
        animator.SetTrigger("Attack1");

        //Detect enemies in range
        Physics2D.OverlapCircleAll(attackPoint1.position, attackRange1, enemyLayers);
    }
    public void Attack2()
    {
        //Animation for quick attack
        animator.SetTrigger("Attack2");


        //Detect enemies in range
        Collider2D [] enemiesHit = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
        Debug.Log("We attack" + count_debug);
        count_debug++;
        //Damage enemies -- this allows us to scale the game if we want more enemies in a single fight.
        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("We hit" + enemy.name);
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

    private void OnDrawGizmosSelected()
    {
        if(attackPoint1 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange1);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
    }

}
