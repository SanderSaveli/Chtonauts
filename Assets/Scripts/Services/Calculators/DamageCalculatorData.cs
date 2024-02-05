using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "Data/Damage Data")]
public class DamageCalculatorData : ScriptableObject
{
    public List<IntEntry> defaultDamage = new List<IntEntry>();
}
