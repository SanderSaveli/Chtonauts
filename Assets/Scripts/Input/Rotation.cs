using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   public Transform Target;
   public float MouseSens = 2.5f;
   public  float timer = 0;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(1))
       {
        timer -=Time.deltaTime;
        if(timer<=0)
        {
            float hor = Input.GetAxis("Mouse X");
            float Ver = Input.GetAxis("Mouse Y");
            transform.RotateAround(Target.position,Vector3.up , hor *MouseSens *300 * Time.deltaTime);

        }
       } 
       
    }
}
