using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
	Animator enemyAC;

	public float enemyAccel;
	public float maxSpeed = 20f;
	public float minAttackDistance = 1.5f;


	public float chargeTime;
	float startChargeTime;
	bool charging = false;
	Rigidbody2D enemyRB;

	public GameObject target;

	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 5f;
	float nextFlipChance = 0f;
	Transform enemyTransform;

	bool attacking = false;


	// Use this for initialization
	void Start()
	{
		enemyTransform = GetComponent<Transform>();
		enemyRB = GetComponent<Rigidbody2D>();
		enemyAC = GetComponent<Animator>();
		GameObject player = GameObject.Find("Player");
		Transform playerTransform = player.transform;
		Vector3 position = playerTransform.position;
	}

	// Update is called once per frame
	void Update()
	{
		
		if (enemyRB.velocity.x != 0)
		{
			
			enemyAC.SetBool("isCharging", true);
		}

		if (Time.time > nextFlipChance)
		{
			if (Random.Range(0, 10) >= 5)
				flipFacing();
			nextFlipChance = Time.time + flipTime;
		}

		if (charging && Time.time > startChargeTime && enemyRB.velocity.x < maxSpeed)
		{
			if (!facingRight)
			{
				enemyRB.AddForce(new Vector2(-1f, 0f) * enemyAccel);
			}
			else
			{
				enemyRB.AddForce(new Vector2(1f, 0f) * enemyAccel);
				enemyAC.SetBool("isCharging", charging);
			}
			
			enemyAccel = 50;
		}
		if (target != null)
		{
			float distance = Vector3.Distance(transform.position, target.transform.position);
			
			if (distance < minAttackDistance)
			{
				Debug.Log("Attacking bumbum" + enemyAccel);

				enemyAccel = 0;
				enemyRB.velocity = Vector2.zero;
				enemyAC.SetTrigger("Attacking");

			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (facingRight && other.transform.position.x < transform.position.x)
			{
				flipFacing();
			}
			else if (!facingRight && other.transform.position.x > transform.position.x)
			{
				flipFacing();
			}
			canFlip = false;
			charging = true;
			startChargeTime = Time.time + chargeTime;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			target = other.gameObject;
			charging = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			target = null;
			canFlip = true;
			charging = false;
			enemyRB.velocity = new Vector2(0f, 0f);
			enemyAC.SetBool("isCharging", charging);
		}
	}

	void flipFacing()
	{
		if (!canFlip)
			return;
		float facingX = enemyTransform.localScale.x;
		facingX *= -1;
		enemyTransform.localScale = new Vector3(facingX, enemyTransform.localScale.y, enemyTransform.localScale.z);
		facingRight = !facingRight;

	}

}