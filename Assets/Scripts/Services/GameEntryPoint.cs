using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    public ServiceRegistrator registrator;
    void Start()
    {
        registrator.RegistrateAllServices();
    }
}
