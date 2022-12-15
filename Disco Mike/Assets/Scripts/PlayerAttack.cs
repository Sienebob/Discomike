using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwPunch;
    public float startTimeBtwSweep;
    

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public Animator animator;
    public int damage;
    
    void Update()
    {
        punch();
        sweep();
        
    }
    // sweep
    void sweep()
    
        {

            if (timeBtwAttack <= 0)
            {
                if (Input.GetKey(KeyCode.X)|| Input.GetKey(KeyCode.Mouse1))
                {
                    SoundManagerScript.PlaySound("Hit");
                    timeBtwAttack = startTimeBtwSweep;
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    animator.SetTrigger("Punch");

                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyTakeDamage>().TakeDamage(damage);
                    enemiesToDamage[i].GetComponent<BossTakeDamage>().TakeDamage(damage);
                    Debug.Log("sweep dmg annettu");
                    }

                }

            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
       

        }

     void OnDrawGizmosSelected()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPos.position, attackRange);
            }

    
 //punch  
    void punch()
    {

        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                SoundManagerScript.PlaySound("Sweep");
                timeBtwAttack = startTimeBtwPunch;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                animator.SetTrigger("Sweep");

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyTakeDamage>().TakeDamage(damage);
                    enemiesToDamage[i].GetComponent<BossTakeDamage>().TakeDamage(damage);
                    Debug.Log("Punch dmg annettu");
                }
            }
            }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    /*private void Shoot()
    {
        Vector3 bulletR = new Vector3(1, 0, 0);
        Vector3 bulletL = new Vector3(-1, 0, 0);

        if (Input.GetKey(KeyCode.LeftShift) && timeBtwAttack <= 0 )








        /*
        if (Input.GetKey(KeyCode.LeftShift) && timeBtwAttack <= 0)
        {
            timeBtwAttack = startTimeBtwShoot;
            
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
            
            SoundManagerScript.PlaySound("Shoot");


        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        */

    

}

