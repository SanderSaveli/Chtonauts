using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTileView : MonoBehaviour
{
    private ChangableTile targetTile;
    public Image progressBar;
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
        progressBar.enabled = false;
    }
}
