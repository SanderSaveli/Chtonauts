using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public TMP_Text Title;
    public Image Image;
    public TMP_Text Text;

    public void showPopUp(PopUpData data)
    {
        Title.text = data.Title;
        Image.sprite = data.Sprite;
        Text.text = data.Text;
    }
}
