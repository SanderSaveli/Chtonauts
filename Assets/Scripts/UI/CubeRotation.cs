using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float rotationSpeed = 20.0f; // Скорость вращения в градусах в секунду

    void Update()
    {
        // Вращаем объект вокруг оси Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
