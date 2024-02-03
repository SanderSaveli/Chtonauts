using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas UICanvas;
    void Start()
    {
        Camera cam = Camera.main;
        UICanvas.worldCamera = cam;
        UICanvas.planeDistance = 0.5f;
        transform.SetAsFirstSibling();
    }

}
