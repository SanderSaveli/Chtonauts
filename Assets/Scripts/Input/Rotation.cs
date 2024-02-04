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
        // Получаем все рендереры дочерних объектов
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        // Если есть рендереры, вычисляем центр их объединения
        if (renderers.Length > 0)
        {
            Bounds bounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
            {
                bounds.Encapsulate(renderers[i].bounds);
            }
            center = bounds.center;
        }
        else
        {
            // Если рендереров нет, используем позицию объекта
            center = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                float hor = Input.GetAxis("Mouse X");
                // float ver = Input.GetAxis("Mouse Y"); // Эта строка больше не нужна
                transform.RotateAround(center, Vector3.up, hor * MouseSens * 300 * Time.deltaTime);
                // Вращение вокруг оси Y удалено
            }
        }
    }
}