using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text Title;
    public Image Image;
    public Text mainText;
    public Font customFont;

    
    public void showPopUp(PopUpData data)
    {
        
        Title.text = data.Title;
        Image.sprite = data.Sprite;
        mainText.text = data.Text;
    }
}
