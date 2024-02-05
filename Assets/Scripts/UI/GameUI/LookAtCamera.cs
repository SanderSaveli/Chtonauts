using UnityEngine;
using TMPro;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;
    private TextMeshProUGUI priceText;

    private void Start()
    {
        mainCamera = Camera.main;
        priceText = GetComponent<TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        // Поворачиваем текст так, чтобы он всегда смотрел на камеру
        transform.LookAt(mainCamera.transform);
        // Отражаем текст, если он должен смотреть на обратную сторону от камеры
        transform.forward = -transform.forward;
    }
}