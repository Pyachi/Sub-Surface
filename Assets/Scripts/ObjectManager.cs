using System.Collections.Generic;
using UnityEngine;

public static class ObjectManager
{
    private static readonly List<GameObject> Objs = new List<GameObject>();

    public static void AddObject(GameObject obj) => Objs.Add(obj);
    public static void RemoveObject(GameObject obj) => Objs.Remove(obj);

    public static void ShiftLeft()
    {
        foreach (var obj in Objs)
        {
            obj.transform.Translate(new Vector3(-50,0,0));
        }
    }

    public static void ShiftRight()
    {
        foreach (var obj in Objs)
        {
            obj.transform.Translate(new Vector3(50,0,0));
        }
    }
}