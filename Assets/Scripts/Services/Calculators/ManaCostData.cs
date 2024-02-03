using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ManaCostData", menuName = "Data/Mana Cost Data")]
public class ManaCostData : ScriptableObject
{
    public List<CostEntry> defaultCost;
}
