using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float speed = 0.5f;
    public float start = 0;
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    Vector2 offset = new Vector2(0, 0);

    void Update()
    {
        offset.x = start + Time.time * speed;

        float temp = (cam.transform.position.x * (1 - parallaxEffect));  // taustat looppiin
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // taustaa loopataan
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;



    }
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }


}



