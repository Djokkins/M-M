using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walk : StateMachineBehaviour
{

    private Transform player;
    Rigidbody2D rb;

    Enemy enemy;

    private float speed;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        speed = 1.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.ChasePlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        //Enrage effect below 50% health
        if (animator.GetComponent<Enemy>().getCurrentHealth() <= 50f)
        {
            Debug.Log("Enemy current health 2= " + (animator.GetComponent<Enemy>().getCurrentHealth()));
            animator.SetBool("isRunning", true);
        }
        else if (Vector2.Distance(player.position, rb.position) <= 5f)
        {
            Debug.Log("Enemy current health = " + (animator.GetComponent<Enemy>().getCurrentHealth()));
            rb.MovePosition(rb.position);
            animator.SetTrigger("Attack1");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.SetBool("isWalking", false);
    }

}
