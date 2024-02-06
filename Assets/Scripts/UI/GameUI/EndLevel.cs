using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public TextMeshProUGUI result;
    public Text timeToComplete;
    private float time = 0.0f;
    private Animator _animator;
    public Button restart;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    public void WinLevel()
    {
        Time.timeScale = 0f;
        result.text = "Победа";
        _animator.SetBool("open", true);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string displayTime = timeSpan.ToString("mm':'ss");
        timeToComplete.text = displayTime;
        restart.gameObject.SetActive(false);
    }

    public void LoseLevel()
    {
        Time.timeScale = 0f;
        result.text = "Поражение";
        _animator.SetBool("open", true);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string displayTime = timeSpan.ToString("mm':'ss");
        timeToComplete.text = displayTime;
        restart.gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        _animator.SetBool("open", false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void toMenu()
    {
        _animator.SetBool("open", false);
        SceneManager.LoadScene(0);
    }
    
}
