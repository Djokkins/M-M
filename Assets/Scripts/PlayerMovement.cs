using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Creating variables
    //Controller and animator
    public CharacterController2D controller;
    public Animator animator;
    //ad variables
    private float dmgMult;
    private float attack1Damage;
    private float attack2Damage;

    //movement variables
    private float runSpeed;
    private float rollSpeed;
    float horizontalMove;
    bool jump;
    bool isRolling;
    bool isJumping;
    private bool attacking;
    private bool run;
    private bool isJumping;
    private float direction;

    //as variables
    private float aSpeedMult;
    public Transform attackPoint1;
    private float attackRange1;
    private float attackSpeed1;

    public Transform attackPoint2;
    private float attackRange2;
    private float attackSpeed2;
    float nextAttack;

    //Resource externalization
    PlayerDamage damage;
  
    public LayerMask enemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        //initializing variables
        //ad variables
        //dmgMult = 1f;
        //attack1Damage = 9 * dmgMult;
        //attack2Damage = 5 * dmgMult;

        ////as variables
        //aSpeedMult = 1f;
        //attackRange1 = 0.5f * aSpeedMult;
        //attackSpeed1 = 1.5f * aSpeedMult;

        //attackRange2 = 0.6f;
        //attackSpeed2 = 2f;

        //nextAttack = 0f;

        //movement variables
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

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            isJumping = true;
        }

        
        //if (Input.GetButtonDown("Crouch"))
        //{ crouch = true; }



        if (/*Time.time >= nextAttack && */!animator.GetCurrentAnimatorStateInfo(0).IsName("roll") && !isJumping)
        {
            if (Input.GetKeyDown(KeyCode.K) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 2"))
            {
                damage.Attack1();
            }

            if (Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 1"))
            {
                damage.Attack2();
            }
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

    //private void Attack1()
    //{
    //    //Animation for slow attack
    //    animator.SetTrigger("Attack1");

    //    //Detect enemies in range
    //    Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange1, enemyLayers);
    //    //Damage enemies -- this allows us to scale the game if we want more enemies in a single fight.
    //    foreach (Collider2D enemy in enemiesHit)
    //    {
    //        enemy.GetComponent<Enemy>().TakeDamage(attack1Damage);
    //        Debug.Log("We hit" + enemy.name);
    //    }
    //}
    //public void Attack2()
    //{
    //    //Animation for quick attack
    //    animator.SetTrigger("Attack2");   


    //    //Detect enemies in range
    //    Collider2D [] enemiesHit = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
    //    Debug.Log("We attack" + count_debug);
    //    count_debug++;
    //    //Damage enemies -- this allows us to scale the game if we want more enemies in a single fight.
    //    foreach (Collider2D enemy in enemiesHit)
    //    {
    //        enemy.GetComponent<Enemy>().TakeDamage(attack2Damage);
    //        Debug.Log("We hit" + enemy.name);
    //        }
    //}


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
