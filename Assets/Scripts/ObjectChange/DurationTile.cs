using System.Collections;
using UnityEngine;
using Zenject;

public abstract class DurationTile : InteractiveTile
{
    public float activationTimeLeft { get; protected set; }

    [Inject] protected IDurationCalculator _durationCalculator;

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
