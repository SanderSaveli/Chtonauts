using UnityEngine;

public class Baffer : MonoBehaviour
{
    IDurationCalculator durationCalculator;
    IManaService manaService;
    IDamageCalculator DamageCalculator;

    public int damageIncreseCost;
    public int reloadIncreseCost;
    public int durationIncreseCost;
    private void Start()
    {
        durationCalculator = ServiceLocator.Get<IDurationCalculator>();
        manaService = ServiceLocator.Get<IManaService>();
        DamageCalculator = ServiceLocator.Get<IDamageCalculator>();
    }
    public void IncreaseDamage()
    {
        if (manaService.TrySpendMana(damageIncreseCost))
        {
            DamageCalculator.increaseModificatorForAll(2);
        }
    }
    public void IncreaseMatnaReload()
    {
        if (manaService.TrySpendMana(reloadIncreseCost))
        {
            manaService.increaseManaReload(0.2f);
        }
    }
    public void IncreaseDyration()
    {
        if (manaService.TrySpendMana(durationIncreseCost))
        {
            durationCalculator.increaseModificatorForAll(1);
        }
    }
}
