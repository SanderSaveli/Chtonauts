using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider overall, music, effects;
    public Text overallValue, musicValue, effectsValue;
    public GameObject settingsTab;
    private Animator _animator;

    private void Start()
    {
        audioMixer.SetFloat("MasterVolume", overall.value);
        audioMixer.SetFloat("MusicVolume", music.value);
        _animator = settingsTab.GetComponent<Animator>();
    }

    private void Update()
    {
        overallValue.text = (overall.value + 100) + "%";
        musicValue.text = (music.value + 100)  + "%";
        effectsValue.text = (effects.value + 100) + "%";
    }

    public void overallSoundChange(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }
    public void musicSoundChange(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
    }
    public void effectsSoundChange(float value)
    {
        
    }

    public void openCloseSettingsTab()
    {
        if (settingsTab.transform.position.y < 0)
        {
            _animator.SetBool("open", true);
            _animator.SetBool("close", false);
        }
        else
        {
            _animator.SetBool("close", true);
            _animator.SetBool("open", false);
        }
    }
    
}
