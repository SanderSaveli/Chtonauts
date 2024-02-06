using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PopUpShower : MonoBehaviour
{
    public List<PopUpData> PopUps;
    private int index = 0;
    public GameObject popUpPrefab;
    private PopUp _popUp;
    public Button btn;
    public TextMeshProUGUI btnText;
    private Animator _animator;
    private bool _isTutorial = true;
    private void Start()
    {
        _popUp = popUpPrefab.GetComponent<PopUp>();
        btn.onClick.AddListener(ShowPopUps);
        btnText.text = "Дальше";
        _animator = GetComponent<Animator>();
        Time.timeScale = 0;
        if (index == 0)
        {
            _animator.SetBool("open", true);
            ShowPopUps();
        }
    }

    public void ShowPopUps()
    {
        
        if (index < PopUps.Count)
        {
            PopUpData currentData = PopUps[index];

            _popUp.showPopUp(currentData);
            btn.onClick.AddListener(NextPopUp);
        }
    }

    private void NextPopUp()
    {
        btn.onClick.RemoveListener(NextPopUp);
        index++;
        if (index == PopUps.Count - 1)
        {
            btnText.text = "Закрыть";
            btn.onClick.AddListener(ClosePopUp);
            
        }
        ShowPopUps();
    }

    private void ClosePopUp()
    {
        Time.timeScale = 1;
        _animator.SetBool("open", false);
        _animator.SetBool("close", true);
    }
}