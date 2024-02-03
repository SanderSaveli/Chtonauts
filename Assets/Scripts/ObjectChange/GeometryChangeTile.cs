using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryChangeTile : InteractiveTile
{
    public float ChangeTimeLeft { get; protected set; }

    [SerializeField] private GameObject _changeTarget;

    private GameObject createdObject;
    private IDurationCalculator _durationCalculator;

    private void Start()
    {
        _durationCalculator = ServiceLocator.Get<IDurationCalculator>();
    }
    public override bool ActivateTile()
    {
        float duration = _durationCalculator.getDuration(TileType);
        if (IsChganged)
        {   
            return false;
        }
        StartCoroutine(WaitTimeAndChangeBack(duration));
        ChangeGeometry(false);
        IsChganged = true;
        return true;

    }

    IEnumerator WaitTimeAndChangeBack(float tinme)
    {
        ChangeTimeLeft = tinme;
        while (ChangeTimeLeft > 0)
        {
            ChangeTimeLeft -= Time.deltaTime;
            yield return null;
        }
        ChangeBack();
    }

    protected void ChangeBack()
    {
        ChangeTimeLeft = 0;
        IsChganged = false;
        ChangeGeometry(true);
    }

    protected void ChangeGeometry(bool isActive)
    {
        GetComponent<MeshRenderer>().enabled = isActive;
        if (isActive)
        {
            if (createdObject != null)
            {
                Destroy(createdObject);
            }
        }
        else
        {
            if (createdObject == null)
            {
                createdObject = Instantiate(_changeTarget, transform.position, transform.rotation);
            }
        }
    }
}
