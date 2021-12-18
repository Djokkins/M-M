using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public HealthBarBoss healthBar;

    private bool isFlipped;
    private float stunDR;
    public float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
        maxHealth = 100f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (stunDR < 1f)
        {
            animator.SetTrigger("gotHit");
            animator.ResetTrigger("Attack1");
            animator.ResetTrigger("Attack2");
            stunDR += .5f;
        }
        else
        {
            stunDR = 0f;
        }

        //play hurt animation

        if (currentHealth <= 0)
        {
            Die();
            animator.ResetTrigger("Attack1");
            animator.ResetTrigger("Attack2");
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
}
