using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
     public float speed = 5.0f;
void Update()
{
   
	if(Input.GetKey(KeyCode.D))
	{
		transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
	}
	if(Input.GetKey(KeyCode.A))
	{
		transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
	}
	if(Input.GetKey(KeyCode.S))
	{
		transform.Translate(new Vector3(0,-speed * Time.deltaTime,-speed * Time.deltaTime));
	}
	if(Input.GetKey(KeyCode.W))
	{
		transform.Translate(new Vector3(0,speed * Time.deltaTime,speed * Time.deltaTime));
	}
}
}
