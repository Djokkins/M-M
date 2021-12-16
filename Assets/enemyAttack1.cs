using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack1 : StateMachineBehaviour
{
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //First we need to make sure we're facing the player
       // animator.GetComponent<Enemy>().ChasePlayer();
        //Get the attack function from Enemy_attack
        animator.GetComponent<Enemy_attack>().Attack();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
