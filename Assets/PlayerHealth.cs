using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	private float maxHealth = 100;
	private float cHealth;
	public float resistance = 0;
	public HealthBarPlayer healthBar;
	public Animator transition;
    public float transitiontime = 1f;

	void Start()
	{
		cHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		healthBar.SetHealth(cHealth);

	}

	public void TakeDamage(float damage)
	{
		cHealth -= damage - CalcResistance();
		healthBar.SetHealth(cHealth);
		StartCoroutine(setGotHit());
	}

    IEnumerator setGotHit()
    {
		animator.SetTrigger("gotHit");
		if(cHealth <= 0)
        {
			StartCoroutine(Die());
        }
		yield return new WaitForSeconds(0.3f);
	}

    IEnumerator Die()
	{
		animator.SetBool("isDead", true);
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
		SceneManager.LoadScene("MainHub");
		yield return new WaitForSeconds(3f);
	}

	private float CalcResistance()
    {
		resistance = 0;// + take input from armor 
		return resistance;
    }

	public float getMaxHealth()
    {
		return maxHealth;
    }

	public float getCurrentHealth()
    {
		return cHealth;
    }

}
