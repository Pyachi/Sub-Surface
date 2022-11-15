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
            Vector3 temppos = obj.transform.position;
            temppos.x -= 50;
            obj.transform.position = temppos;
        }
    }

    public static void ShiftRight()
    {
        foreach (var obj in Objs)
        {
            Vector3 temppos = obj.transform.position;
            temppos.x += 50;
            obj.transform.position = temppos;
        }
    }
}