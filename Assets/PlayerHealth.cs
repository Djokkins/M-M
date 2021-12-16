using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	private float maxHealth = 100;
	public float cHealth;
	public float resistance = 0;

	public GameObject deathEffect;
	void Start()
	{
		cHealth = maxHealth;
	}

	public void TakeDamage(float damage)
	{
		
		cHealth -= damage - CalcResistance();
		animator.SetTrigger("gotHit");
		if (cHealth <= 0)
		{
			Die();
		}
		else
		{
			StartCoroutine(setGotHit());
		}
	}

    IEnumerator setGotHit()
    {
		yield return new WaitForSeconds(0.3f);
	}

    void Die()
	{
		animator.SetBool("isDead", true);
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}

	private float CalcResistance()
    {
		resistance = 0;// + take input from armor 
		return resistance;
    }
}
