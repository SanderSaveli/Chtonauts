using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool opened = false;
    public GameObject pauseMenu;
    public AudioClip click;
    public AudioSource audioSource;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
        }
       
    }
    
    public void Resume()
    {
        _animator.SetBool("open", false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        _animator.SetBool("open", true);
        Time.timeScale = 0;
    }
    
}
