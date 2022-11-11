using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public static class EnemyManager
{
    private static readonly GameObject Fish = Resources.Load("enemies/fish",typeof(GameObject)) as GameObject;
    private static readonly GameObject Shark = Resources.Load("enemies/shark", typeof(GameObject)) as GameObject;
    private static readonly GameObject Eel = Resources.Load("enemies/eel", typeof(GameObject)) as GameObject;
    private static GameObject _sub;
    private static int _lifetime;
    private static double _credits;

    public static void Init(GameObject sub)
    {
        _sub = sub;
    }

    public static void Update()
    {
        _lifetime++;
        _credits += 0.02; //To be scaled with time, credits are spent to spawn enemies, stronger enemies -> more credit cost
        if (_credits < 1.0) return;
        _credits -= 1.0;
        var rand = Random.Range(0, 10);
        GameObject selection;
        if (rand < 6) selection = Fish;
        else if (rand < 9) selection = Shark;
        else selection = Eel;
        var locAngle = Random.Range(0F, 2F * (float)Math.PI);
        var spawnPosition = _sub.transform.position +
                            new Vector3((float)(Math.Sin(locAngle) * 15), (float)(Math.Cos(locAngle) * 15), 0F);
        if (spawnPosition.y > 24F) spawnPosition.y = 24F;
        else if (spawnPosition.y < -24F) spawnPosition.y = -24F;
        ObjectManager.AddObject(Object.Instantiate(selection, spawnPosition, Quaternion.identity));
    }
}