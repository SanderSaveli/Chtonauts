using UnityEngine;

[CreateAssetMenu(fileName = "ManaServiceData", menuName = "Data/Mana Data")]
public class ManaServiceData : ScriptableObject
{
    [Header("Start values")]
    public float manaIncreasePerSecond;
    public float startMana;
    public int maxMana;
}
