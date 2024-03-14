using TMPro;
using UnityEngine;
using Zenject;

public class Baffer : MonoBehaviour
{
    public int damageIncreseCost;
    public int reloadIncreseCost;
    public int durationIncreseCost;

    public TMP_Text damageText;
    public TMP_Text reloadText;
    public TMP_Text durationText;

    private IDurationCalculator _durationCalculator;
    private IManaService _manaService;
    private IDamageCalculator _damageCalculator;
    private void Start()
    {
        damageText.text = damageIncreseCost.ToString();
        reloadText.text = reloadIncreseCost.ToString();
        durationText.text = durationIncreseCost.ToString();
    }

    [Inject] private void Construct(IDurationCalculator durationCalculator, 
        IManaService manaService, 
        IDamageCalculator damageCalculator)
    {
        _durationCalculator = durationCalculator;
        _manaService = manaService;
        _damageCalculator = damageCalculator;
    }
    public void IncreaseDamage()
    {
        if (_manaService.TrySpendMana(damageIncreseCost))
        {
            _damageCalculator.increaseModificatorForAll(2);
        }
    }
    public void IncreaseMatnaReload()
    {
        if (_manaService.TrySpendMana(reloadIncreseCost))
        {
            _manaService.increaseManaReload(0.2f);
        }
    }
    public void IncreaseDyration()
    {
        if (_manaService.TrySpendMana(durationIncreseCost))
        {
            _durationCalculator.increaseModificatorForAll(1);
        }
    }
}
