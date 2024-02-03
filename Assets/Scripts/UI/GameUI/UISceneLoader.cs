using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync("GameUI", LoadSceneMode.Additive);
    }
}
