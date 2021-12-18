using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
	public float attackDamage = 20;
	public float enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask playerMask;

	// Start is called before the first frame update

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, playerMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}

		StartCoroutine(setAttackStunDur());
	}
		
	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;


		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, playerMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
		}
		StartCoroutine(setEnragedStunDur());
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		
		Gizmos.DrawWireSphere(pos, attackRange);
	}	

	IEnumerator setAttackStunDur()
    {
		yield return new WaitForSeconds(.3f);
    }
	IEnumerator setEnragedStunDur()
	{
		yield return new WaitForSeconds(1.3f);
	}
}
