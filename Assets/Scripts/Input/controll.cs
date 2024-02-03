using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour
{
    public float dragSpeed = 30;

    public float outerLeft = 100F;
    public float outerRight = 100F;
    public float outerDown = 100F;
    public float outerUp = 100F;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;
            newPosition.z = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;

            if (gameObject.transform.position.x > -outerLeft && gameObject.transform.position.x < -outerRight && gameObject.transform.position.y > outerDown && gameObject.transform.position.y < -outerUp && gameObject.transform.position.z > outerDown && gameObject.transform.position.z < -outerUp)
            {
                transform.Translate(newPosition);
            }
            if (gameObject.transform.position.x < -outerLeft || gameObject.transform.position.x > -outerRight || gameObject.transform.position.y < outerDown || gameObject.transform.position.y > -outerUp || gameObject.transform.position.z < outerDown || gameObject.transform.position.z > -outerUp)
            {
                transform.Translate(-newPosition);
            }
        }
    }
}