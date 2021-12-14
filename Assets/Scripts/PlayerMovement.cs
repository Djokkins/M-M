using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public int attack1Damage = 30;
    public int attack2Damage = 17;

    private float runSpeed = 200f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private bool run = false;


    public Transform attackPoint1;
    public float attackRange1 = 0.5f;
    public float attackSpeed1 = 1.5f;

    public Transform attackPoint2;
    public float attackRange2 = 0.6f;
    public float attackSpeed2 = 2f;

    float nextAttack = 0f;
    
    public LayerMask enemyLayers;

    private int Health;
    private int count_debug = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Health = FindObjectOfType<Stats>().Health;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
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


        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.K) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 2"))
            {
                Attack1();
                nextAttack = Time.time + (1f / attackSpeed1);
            }

            if (Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack 1"))
            {
                Attack2();
                nextAttack = Time.time + (1f / attackSpeed2);
            }
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
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
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
    
}
