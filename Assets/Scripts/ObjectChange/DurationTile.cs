using System.Collections;
using UnityEngine;

public abstract class DurationTile : InteractiveTile
{
    public float activationTimeLeft { get; protected set; }

    protected IDurationCalculator _durationCalculator;

    private void Start()
    {
        _durationCalculator = ServiceLocator.Get<IDurationCalculator>();
    }

    protected IEnumerator WaitTimeAndDeactivation(float tinme)
    {
        activationTimeLeft = tinme;
        while (activationTimeLeft > 0)
        {
            activationTimeLeft -= Time.deltaTime;
            ActivationUpdate();
            yield return null;
        }
        Deactivation();
        activationTimeLeft = 0;
        IsChganged = false;
    }

    protected abstract void Deactivation();

    protected virtual void ActivationUpdate() { }
}
