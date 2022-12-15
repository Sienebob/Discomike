﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
   

        //Spawn this object
        public GameObject spawnObject;

        public float maxTime = 8;
        public float minTime = 3;

        //current time
        private float time;

        //The time to spawn the object
        private float spawnTime;

        private Transform playerpos;

        void Start()
        {
            SetRandomTime();
            time = minTime;
             playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         }

        void FixedUpdate()
        {
        if (playerpos.position.x > 27)
            //Counts up
            time += Time.deltaTime;

            //Check if its the right time to spawn the object
            if (time >= spawnTime)
            {
                SpawnObject();
                SetRandomTime();
            }

        }


        //Spawns the object and resets the time
        void SpawnObject()
        {
      
            time = 0;
            Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
        }

        //Sets the random time between minTime and maxTime
        void SetRandomTime()
        {
            spawnTime = Random.Range(minTime, maxTime);
        }

    
}
