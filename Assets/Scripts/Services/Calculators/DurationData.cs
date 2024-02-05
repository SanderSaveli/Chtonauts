using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeDurationData", menuName = "Data/Change Duration Data")]
public class DurationData : ScriptableObject
{
    public List<FloatEntry> defaultDurations;
}
