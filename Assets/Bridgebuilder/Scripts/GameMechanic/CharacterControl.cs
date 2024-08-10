using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform targetPosition;
	[SerializeField] Transform startPosition;
	[SerializeField] float MoveSpeed = 5f;

	public void MoveToTarget()
	{
		StartCoroutine(MotToTarget());
	}
	public void MoveToStart()
	{
		transform.position = startPosition.position;
	}
	IEnumerator MotToTarget()
	{
		anim.SetBool("IsWalking", true);
		while (Vector3.Distance(transform.position, targetPosition.position) > 0.1f)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime* MoveSpeed);
			yield return null;
		}
		anim.SetBool("IsWalking", false);
	}
}
