
using UnityEngine;

public class ServiceRegistrator : MonoBehaviour 
{
    public ManaServiceData manaServiceData;
    public IncreasedManaPool manaPool;
    public void RegistrateAllServices()
    {
        new ServiceLocator();
        ServiceLocator.RegisterService(new GameManaService(manaServiceData, manaPool), typeof(IManaService));
    }
}