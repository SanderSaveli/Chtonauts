
using UnityEngine;

public class ServiceRegistrator : MonoBehaviour 
{
    public ManaServiceData manaServiceData;
    public IncreasedManaPool manaPool;
    public ManaCostData costData;
    public DurationData durationData;
    public void RegistrateAllServices()
    {
        new ServiceLocator();
        ServiceLocator.RegisterService(new GameManaService(manaServiceData, manaPool), typeof(IManaService));
        ServiceLocator.RegisterService(new ManaCostCalculator(costData), typeof(IManaCostCalculator));
        ServiceLocator.RegisterService(new DurationCalculator(durationData), typeof(IDurationCalculator));
    }
}