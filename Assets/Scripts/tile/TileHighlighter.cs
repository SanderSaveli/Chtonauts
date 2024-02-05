using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    public Material highlightMaterial; // Материал для обводки тайлов
    private Material originalMaterial; // Оригинальный материал тайла
    private Renderer tileRenderer; // Рендерер тайла

    private void Start()
    {
        // Получаем рендерер тайла
        tileRenderer = GetComponent<Renderer>();
        // Сохраняем оригинальный материал тайла
        originalMaterial = tileRenderer.material;
    }

    private void OnMouseEnter()
    {
        // При наведении мыши на тайл, меняем материал на материал обводки
        tileRenderer.material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        // При уходе мыши с тайла, возвращаем оригинальный материал
        tileRenderer.material = originalMaterial;
    }
}