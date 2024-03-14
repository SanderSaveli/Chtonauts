using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class UISceneLoader : MonoBehaviour
{
    [Inject] private DiContainer _container;
    private void Awake()
    {
        SceneManager.LoadSceneAsync("GameUI", LoadSceneMode.Additive);
    }
}
