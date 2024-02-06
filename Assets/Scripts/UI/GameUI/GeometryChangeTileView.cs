using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeometryChangeTileView : MonoBehaviour
{
    private DurationTile targetTile;
    public Image progressBar;
    public ParticleSystem particleSystem;
    private float duration;
    public TMP_Text price;
    private void OnEnable()
    {
        targetTile = gameObject.GetComponentInParent<DurationTile>();
        targetTile.OnTileActive += TileActive;
        targetTile.OnTileDeactiveted += TileDeactiveted;
    }
    private void OnDisable()
    {
        targetTile.OnTileActive += TileActive;
        targetTile.OnTileDeactiveted += TileDeactiveted;
    }

    public void Start()
    {
        price.text = ServiceLocator.Get<IManaCostCalculator>().getCost(targetTile.TileType).ToString();
    }
    protected virtual void TileActive()
    {
        duration = targetTile.activationTimeLeft;
        StartCoroutine(ChangeProgressBar());
        particleSystem.Play();
    }
    protected virtual void TileDeactiveted()
    {
        duration = targetTile.activationTimeLeft;
        StartCoroutine(ChangeProgressBar());
        particleSystem.Play();
    }

    private IEnumerator ChangeProgressBar()
    {
        progressBar.enabled = true;
        while (targetTile.IsChganged)
        {
            progressBar.fillAmount = targetTile.activationTimeLeft / duration;
            yield return null;
        }
        particleSystem.Play();
        progressBar.enabled = false;
    }
}
