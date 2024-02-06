using TMPro;
using UnityEngine;

public class Baffer : MonoBehaviour
{
    IDurationCalculator durationCalculator;
    IManaService manaService;
    IDamageCalculator DamageCalculator;

    public int damageIncreseCost;
    public int reloadIncreseCost;
    public int durationIncreseCost;

    public TMP_Text damageText;
    public TMP_Text reloadText;
    public TMP_Text durationText;
    private void Start()
    {
        durationCalculator = ServiceLocator.Get<IDurationCalculator>();
        manaService = ServiceLocator.Get<IManaService>();
        DamageCalculator = ServiceLocator.Get<IDamageCalculator>();
        damageText.text = damageIncreseCost.ToString();
        reloadText.text = reloadIncreseCost.ToString();
        durationText.text = durationIncreseCost.ToString();
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
