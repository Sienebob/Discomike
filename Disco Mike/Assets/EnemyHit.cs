﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {

            print("Osuma!");
            transform.GetComponentInParent<EnemyTakeDamage>().TakeDamage(50);
            //Destroy(collision.gameObject);
        }
    }
}
