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
        result.text = "Победа";
        _animator.SetBool("open", true);
        timeToComplete.text = time.ToString("2");
        restart.gameObject.SetActive(false);
    }

    public void LoseLevel()
    {
        result.text = "Поражение";
        _animator.SetBool("open", true);
        timeToComplete.text = time.ToString("2");
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
