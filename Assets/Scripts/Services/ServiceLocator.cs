using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    static Dictionary<Type, IService> Services;

    public ServiceLocator()
    {
        Services = new Dictionary<Type, IService>();
    }

    public static void RegisterService<T>(T service, Type type) where T : IService
    {
        if (Services.ContainsKey(type))
        {
            throw new Exception("Service of type " + type + " already registered in the service locator.");
        }

        Services.Add(type, service);
        Debug.Log("service " +  type + "sucsessfully registered");
        service.StartWork();
    }

    public static void UnregisterService<T>(T service) where T : IService
    {
        var type = service.GetType();

        if (!Services.ContainsKey(type))
        {
            throw new Exception("There is no service of type " + type + " in service lockator.");
        }

        service.EndWork();
        Services.Remove(type);
    }

    public static T Get<T>() where T : IService
    {
        var type = typeof(T);
        if (!Services.ContainsKey(type))
        {
            throw new Exception("There is no service of type " + type + " in service lockator.");
        }
        return (T)Services[type];
    }
}