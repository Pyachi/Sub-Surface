using System.Collections.Generic;
using UnityEngine;

public static class ObjectManager
{
    private static readonly List<GameObject> Objs = new List<GameObject>();

    public static void AddObject(GameObject obj) => Objs.Add(obj);
    public static void RemoveObject(GameObject obj) => Objs.Remove(obj);
    public static void ShiftLeft() => Objs.ForEach(obj => obj.transform.Translate(-50, 0, 0));
    public static void ShiftRight() => Objs.ForEach(obj => obj.transform.Translate(50, 0, 0));
}