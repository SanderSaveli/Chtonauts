using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : AnimatedBar
{
    private Reseacher reseacher;
    private void Start()
    {
        reseacher = FindObjectOfType<Reseacher>();
        _currentBarValue = reseacher.Mind;
        maxBarValue = reseacher.MaxMind;
        reseacher.OnMindChanged.AddListener(UpdateBar);
        ChangeBarValue(_currentBarValue);
    }


    private void UpdateBar(int value)
    {
        ChangeBarValue(value - _currentBarValue);
    }
}
