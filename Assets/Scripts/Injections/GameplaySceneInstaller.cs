using Zenject;
using UnityEngine;

public class GameplaySceneInstaller : MonoInstaller
{
    public ManaServiceData manaServiceData;
    public ManaCostData costData;
    public DurationData durationData;
    public DamageCalculatorData damageData;
    public AudioServiceData audioData;
    private IncreasedManaPool manaPool;
    public override void InstallBindings()
    {
        if(manaPool == null)
        {
            manaPool = GameObject.FindObjectOfType<IncreasedManaPool>();
        }
        Container.Bind<IManaPool>().FromInstance(manaPool);
        Container.Bind<IManaService>().To<GameManaService>().FromInstance(new GameManaService(manaServiceData, manaPool)).AsSingle();
        Container.Bind<IManaCostCalculator>().To<ManaCostCalculator>().FromInstance(new ManaCostCalculator(costData)).AsSingle();
        Container.Bind<IDurationCalculator>().To<DurationCalculator>().FromInstance(new DurationCalculator(durationData)).AsSingle();
        Container.Bind<IDamageCalculator>().To<DamageCalculator>().FromInstance(new DamageCalculator(damageData)).AsSingle();
        Container.Bind<IAudioService>().To<AudioService>().FromInstance(new AudioService(audioData, gameObject.AddComponent<AudioSource>())).AsSingle();
    }
}
