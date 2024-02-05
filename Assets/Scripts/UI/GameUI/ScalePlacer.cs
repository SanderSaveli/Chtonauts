using UnityEngine;
using UnityEngine.UI;

public class ScalePlacer : MonoBehaviour
{
    public AnimatedBar animatedBar; // Ссылка на AnimatedBar, откуда мы будем брать максимальное значение
    public GameObject scalePrefab; // Префаб шкалы, который будет использоваться для создания шкал
    public float scaleSpacing = 10f; // Расстояние между шкалами

    private void Start()
    {
        if (animatedBar == null)
        {
            Debug.LogError("AnimatedBar reference is not set.");
            return;
        }

        if (scalePrefab == null)
        {
            Debug.LogError("Scale prefab reference is not set.");
            return;
        }

        PlaceScales();
    }

    private void PlaceScales()
    {
        // Очищаем все дочерние объекты, чтобы удалить старые шкалы
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Рассчитываем количество шкал и расстояние между ними
        int scaleCount = animatedBar.maxBarValue;
        float totalWidth = scaleCount * scaleSpacing;
        float startPosition = -totalWidth / 2 + scaleSpacing / 2;

        // Создаем шкалы
        for (int i = 0; i < scaleCount; i++)
        {
            GameObject scaleInstance = Instantiate(scalePrefab, transform);
            RectTransform scaleRectTransform = scaleInstance.GetComponent<RectTransform>();
            scaleRectTransform.anchoredPosition = new Vector2(startPosition + i * scaleSpacing, 0);
        }
    }
}