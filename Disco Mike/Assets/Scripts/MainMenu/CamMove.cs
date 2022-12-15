using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += panSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
