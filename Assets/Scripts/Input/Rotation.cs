using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float MouseSens = 2.5f;
    public float timer = 0;
    private Vector3 center;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 screenCenter = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0f);

                // Указываем расстояние от центра экрана
                float distanceFromCenter = 5f;

                // Создаем вектор, представляющий точку на расстоянии от центра экрана
                Vector3 pointFromCenter = screenCenter + new Vector3(0f, 0f, distanceFromCenter);

                center = Camera.main.ScreenToWorldPoint(pointFromCenter);
                float hor = Input.GetAxis("Mouse X");
                // float ver = Input.GetAxis("Mouse Y"); // Эта строка больше не нужна
                transform.RotateAround(center, Vector3.up, hor * MouseSens * 300 * Time.deltaTime);
                // Вращение вокруг оси Y удалено
            }
        }
    }
}