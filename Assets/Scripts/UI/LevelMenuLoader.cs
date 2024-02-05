using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuLoader : MonoBehaviour
{
    public List<Button> levels;
    public Button home;

    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            int index = i;
            levels[i].onClick.AddListener(() => LoadCurrentScene(index));
        }
    }

    public void LoadCurrentScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex + 4);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
