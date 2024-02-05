using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool opened = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
       
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        opened = !opened;

        if (opened)
        {
            pauseMenu.SetActive(true); // Показываем меню паузы
            Time.timeScale = 0f; // Останавливаем игровое время
        }
        else
        {
            pauseMenu.SetActive(false); // Скрываем меню паузы
            Time.timeScale = 1f; // Возобновляем игровое время
        }
    }
    
}
