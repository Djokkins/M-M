using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform player;

    //range variable
    private float attackRange;

    private bool isFlipped;
    public float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        attackRange = 1.5f;
        isFlipped = false;
        maxHealth = 100f;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("gotHit");

        //play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    //most of this function is from https://github.com/Brackeys/Boss-Battle
    public void ChasePlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Died");
        //die animation
        animator.SetBool("isDead", true);

        //disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    public float getCurrentHealth()
    {
        return currentHealth;
    }
    public float getAttackRange()
    {
        return attackRange;
    }
}
