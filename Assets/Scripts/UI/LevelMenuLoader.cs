using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuLoader : MonoBehaviour
{
    public List<Button> levels;
    public AudioClip click;
    public AudioSource audioSource;

    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            int index = i;
            levels[i].onClick.AddListener(() => LoadCurrentScene(index));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(click);
        }
    }

    public void LoadCurrentScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex + 2);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
