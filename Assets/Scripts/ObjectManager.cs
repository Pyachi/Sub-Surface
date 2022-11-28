using System.Collections.Generic;
using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public static class ObjectManager
{
    private static readonly List<GameObject> Objs = new List<GameObject>();

    public static void AddObject(GameObject obj)
    {
        Objs.Add(obj);
    }

    public static void RemoveObject(GameObject obj)
    {
        Objs.Remove(obj);
    }

    public static void ShiftLeft()
    {
        Objs.RemoveAll(it => !it);
        foreach (var obj in Objs)
        {
            var pos = obj.transform.position;
            pos.x -= 50;
            obj.transform.position = pos;
            var enemy = obj.GetComponent<EnemyBehavior>();
            if (enemy) enemy.target.Clear();
        }
    }

    public static void ShiftRight()
    {
        Objs.RemoveAll(it => !it);
        foreach (var obj in Objs)
        {
            var pos = obj.transform.position;
            pos.x += 50;
            obj.transform.position = pos;
            var enemy = obj.GetComponent<EnemyBehavior>();
            if (enemy) enemy.target.Clear();
        }
    }
}