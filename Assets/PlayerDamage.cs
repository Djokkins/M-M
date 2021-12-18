using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    //as variables
    //private float aSpeedMult = 1f;
    public Transform attackPoint1;
    public float attackRange1 = 0.5f;
    private float attackSpeed1 = 1.5f;

    public Transform attackPoint2;
    public float attackRange2 = 0.6f;
    private float attackSpeed2 = 9f;//10 makes  Attack 2 more dps, and 9 makes attack 1 higher dps, theyre quite close at 6,40 and 6,45
    public float nextAttack = 0f;

    //ad variables
    private float dmgMult = 1f;
    private float attack1Damage = 9;
    private float attack2Damage = 6;
    private float totalDamage;

    //animator and layermask
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform player;

    public void Attack1()
    {
        totalDamage = attack1Damage * dmgMult;
        
        if (Time.time >= nextAttack)
        {
            FindObjectOfType<AudioManager>().Play("playerattack1");
            Debug.Log("We attack1 from the new playerdamage script");

            //Detect enemies in range
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange1, enemyLayers);
            //Damage enemies -- this allows us to scale the game if we want more enemies in a single fight.
            foreach (Collider2D enemy in enemiesHit)
            {
                enemy.GetComponent<Enemy>().TakeDamage(totalDamage);
                FindObjectOfType<AudioManager>().Play("playerattack1_hit");
                Debug.Log("We hit" + enemy.name);
            }
            nextAttack = Time.time + (1f + (1f / attackSpeed1));
        }
        else
        {
            return;
        }
        }


    public void Attack2()
    {
        totalDamage = attack2Damage * dmgMult;

        if (Time.time >= nextAttack)
        {
            //Detect enemies in range
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
            Debug.Log("We attack2 from the new playerdamage script");

            //Damage enemies -- this allows us to scale the game if we want more enemies in a single fight.
            foreach (Collider2D enemy in enemiesHit)
            {
                Debug.Log("we hit");
                enemy.GetComponent<Enemy>().TakeDamage(totalDamage);
                Debug.Log("We hit" + enemy.name);
            }
            nextAttack = Time.time + (1f + (1f / attackSpeed2));
        }
        else
        {
            return;
        }


        }
    void OnDrawGizmosSelected()
    {
        if(attackPoint1 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange1);
    }
}
