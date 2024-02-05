using UnityEngine;
using TMPro;

public class PriceViewController : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public float price = 5f;
    private GeometryChangeTile targetTile;

    private void Start()
    {
        targetTile = GetComponentInParent<GeometryChangeTile>();
        if (targetTile != null)
        {
            targetTile.OnTileChanged += OnTileChanged;
            priceText.text = price.ToString();
            priceText.enabled = true; // Начальное состояние - текст отображается
        }
    }

    private void OnEnable()
    {
        // При включении объекта, цены должны быть видимыми
        priceText.enabled = true;
    }

    private void OnDisable()
    {
        // При отключении объекта, цены должны быть невидимыми
        priceText.enabled = false;
    }

    private void OnTileChanged(bool isChangeToTarget)
    {
        // Если блок изменяется, цены не отображаются, иначе - отображаются
        priceText.enabled = !isChangeToTarget;
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        if (targetTile != null)
        {
            targetTile.OnTileChanged -= OnTileChanged;
        }
    }
}