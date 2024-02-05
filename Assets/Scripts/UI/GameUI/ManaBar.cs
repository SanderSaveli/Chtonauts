public class ManaBar : AnimatedBar
{
    private IManaService manaService;
    private float previousValue;
    private void Start()
    {
        manaService = ServiceLocator.Get<IManaService>();
        previousValue = manaService.currentMana;
        _currentBarValue = manaService.currentMana;
        maxBarValue = manaService.maxMana;
    }

    private void Update()
    {
        ChangeBarValue(manaService.currentMana - previousValue);
        previousValue = manaService.currentMana;
        
    }
}