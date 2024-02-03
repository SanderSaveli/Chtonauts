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
            
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}