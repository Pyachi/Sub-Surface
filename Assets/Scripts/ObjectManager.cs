using System.Collections.Generic;
using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public static class ObjectManager
{
    private static readonly List<GameObject> Objs = new List<GameObject>();
    
    //add an object to the list of objects
    public static void AddObject(GameObject obj)
    {
        Objs.Add(obj);
    }

    //remove an object from the list of objects
    public static void RemoveObject(GameObject obj)
    {
        Objs.Remove(obj);
    }

    //shift every object in the list left by 50 to teleport them all at once
    public static void ShiftLeft()
    {   
        //for each non-null object in the list change its position and if it's an enemy reset its target
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
    
    //shift every object in the list right by 50 to teleport them all at once
    public static void ShiftRight()
    {
        //for each non-null object in the list change its position and if it's an enemy reset its target
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