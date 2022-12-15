using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public float health;
    public GameObject reward;
    public GameObject bloodEffect;
    public GameObject dieEffect;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }


    public void TakeDamage(float dmg)
    {
        print("Otetaan damage");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        SoundManagerScript.PlaySound("Run");
        health -= dmg;

    }



    void Die()
    {
        Instantiate(reward, transform.position, Quaternion.identity);
        DeathParticle();
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);


    }
    void DeathParticle()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
    }
}
