using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 dir = transform.forward;
            dir.y = 0;
            transform.position += dir * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 dir = transform.forward;
            dir.y = 0;
            transform.position -= dir * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 dir = transform.right;
            dir.y = 0;
            transform.position += dir * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 dir = transform.right;
            dir.y = 0;
            transform.position -= dir * speed * Time.deltaTime;
        }

        
    }
}