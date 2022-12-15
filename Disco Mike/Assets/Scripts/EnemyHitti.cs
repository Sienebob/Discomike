using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitti : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision + "ja" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {

            print("Osuma!");
            
            transform.GetComponentInParent<EnemyTakeDamage>().TakeDamage(50);
            //Destroy(collision.gameObject);
        }
    }
}
