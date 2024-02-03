using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    //перекинуть в другой скрипт, это не настройки блять 
    public void exit()
    {
        Application.Quit();
    }
}
