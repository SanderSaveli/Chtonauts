using Zenject;
using UnityEngine;

public class GameplaySceneInstaller : MonoInstaller
{
    public ManaServiceData manaServiceData;
    public ManaCostData costData;
    public DurationData durationData;
    public DamageCalculatorData damageData;

    public IncreasedManaPool manaPool;
    public override void InstallBindings()
    {
        BindData();
        if(manaPool == null)
        {
            manaPool = GameObject.FindObjectOfType<IncreasedManaPool>();
        }
        Container.Bind<IManaPool>().FromInstance(manaPool);
        Container.Bind<IManaService>().To<GameManaService>().FromNew().AsSingle();
        Container.Bind<IManaCostCalculator>().To<ManaCostCalculator>().FromNew().AsSingle();
        Container.Bind<IDurationCalculator>().To<DurationCalculator>().FromNew().AsSingle();
        Container.Bind<IDamageCalculator>().To<DamageCalculator>().FromNew().AsSingle();
        Debug.Log("1");
    }

    private void BindData()
    {
        Container.BindInstance(manaServiceData);
        Container.BindInstance(costData);
        Container.BindInstance(durationData);
        Container.BindInstance(damageData);
    }
}
