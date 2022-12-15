using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

{
    public Transform target;
    public float smoothTime = 0.5F;
    private Vector3 velocity = Vector3.zero;
    public bool moveCamera;
    public float thresholdDistance; // PUT DEFAULT TO 6
    public float distance;
    public Vector3 lastTargetPosition;
    public Vector3 targetPosition;

    


    private void Start()
    {
        targetPosition = target.TransformPoint(new Vector3(0, 5, 5));
        lastTargetPosition = targetPosition;
    }


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            distance = Mathf.Abs(Vector3.Distance(targetPosition, lastTargetPosition));

            if (distance > thresholdDistance)
            {
                moveCamera = true;
            }
        }
        else
        {
            moveCamera = false;
        }
        if (moveCamera == true)
        {
            lastTargetPosition = targetPosition;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        //targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        targetPosition.z = -20; // kameran lopullinen Z arvo
    }
}
