using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //healt 
    public Image filler;
    public float counter;
    public float maxCounter;
    public GameObject playerDeathParticle;

    public GameObject bloodEffect;


    // Start is called before the first frame update
    void Start()
    {
        GameStatus.status.previousHealth = GameStatus.status.health;
        filler.fillAmount = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        healthbar();
        // Die rotation
        if (GameStatus.status.health <= 0)
        {
            
            
            Instantiate(playerDeathParticle, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            transform.Rotate(35f * Time.deltaTime, 0f, 0f);
            Invoke("Die", 2f);
        }

    }


    public void healthbar()
    {
        if (counter > maxCounter)
        {
            GameStatus.status.previousHealth = GameStatus.status.health;
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }

        filler.fillAmount = Mathf.Lerp(GameStatus.status.previousHealth /
        GameStatus.status.maxHealth, GameStatus.status.health / GameStatus.status.maxHealth, counter / maxCounter);
    }

    public void TakeDamage(float dmg)
    {
        GameStatus.status.previousHealth = filler.fillAmount * GameStatus.status.maxHealth;
        counter = 0;
        GameStatus.status.health -= dmg;
        SoundManagerScript.PlaySound("TakeDamage");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        

    }

    public void Die()
    {
        GameStatus.status.maxHealth = 100;
        GameStatus.status.health = GameStatus.status.maxHealth;
        SceneManager.LoadScene("MainMenu");
    }
    private void OnCollisionEnter2D(Collision2D collision)   // OTTAA LÄMÄÄ
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            print("TRAP");
            TakeDamage(20);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy");
            TakeDamage(20);
        }

    }

}

