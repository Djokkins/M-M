using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_run : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rigidBody;
    private Enemy enemyRun;

    private float speedRun;
    //onstateenter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        Debug.Log("We entered enemy_run");
        speedRun = 7f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidBody = animator.GetComponent<Rigidbody2D>();
        enemyRun = animator.GetComponent<Enemy>();

    }

    //onstateupdate is called on each update frame between onstateenter and onstateexit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        enemyRun.ChasePlayer();
        Vector2 target = new Vector2(player.position.x, rigidBody.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidBody.position, target, speedRun * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPos);

        if ((Vector2.Distance(player.position, rigidBody.position) <= 5f) && animator.GetBool("isRunning"))
        {
            speedRun = 0f;
            animator.SetTrigger("Attack2");
        }
    }

    //onstateexit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        speedRun = 0f;
        animator.ResetTrigger("Attack2");
        animator.SetBool("isRunning", false);
    }
}
