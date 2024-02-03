using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTileView : MonoBehaviour
{
    private ChangableTile targetTile;
    public Image progressBar;
    public ParticleSystem particleSystem;
    private float duration;
    private void Start()
    {
        targetTile = gameObject.GetComponentInParent<ChangableTile>();
        targetTile.OnTileChanged += TileChange;
    }

    private void TileChange(bool isCghangeToTarget)
    {
        if (isCghangeToTarget)
        {
            duration = targetTile.ChangeTimeLeft;
            StartCoroutine(ChangeProgressBar());
            particleSystem.Play();
        }
    }

    private IEnumerator ChangeProgressBar()
    {
        progressBar.enabled = true;
        while (targetTile.IsChganged)
        {
            progressBar.fillAmount = targetTile.ChangeTimeLeft / duration;
            yield return null;
        }
        particleSystem.Play();
        progressBar.enabled = false;
    }
}
