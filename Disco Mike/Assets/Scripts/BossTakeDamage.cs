using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTakeDamage : MonoBehaviour
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
        health -= dmg;

    }



    void Die()
    {
        Instantiate(reward, transform.position, Quaternion.identity);
        
        DeathParticle();
        LoadLastScene();
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        //Invoke("LoadLastScene", 2f);
        //SceneManager.LoadScene("End");


    }
    void DeathParticle()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
    }

    void LoadLastScene()
    {
        // 
        SceneManager.LoadScene("End");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {

            print("Osuma!");
            TakeDamage(50);
            
        }
    }



}
