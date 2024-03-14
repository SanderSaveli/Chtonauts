using UnityEngine;
using Zenject;

public class ManaBar : AnimatedBar
{
    private IManaService manaService;
    private float previousValue;
    private void Start()
    {
        previousValue = manaService.currentMana;
        _currentBarValue = manaService.currentMana;
        maxBarValue = manaService.maxMana;
    }

    [Inject] 
    private void Construct(IManaService manaService)
    {
        this.manaService = manaService;
    }


    private void Update()
    {
        ChangeBarValue(manaService.currentMana - previousValue);
        previousValue = manaService.currentMana;
        
    }
}