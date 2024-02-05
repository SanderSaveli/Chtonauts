using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ChangeDurationData", menuName = "Data/PopUp Data")]
public class PopUpData : ScriptableObject
{
    public string Title;
    public Sprite Sprite;
    [TextArea] public string Text;
}
