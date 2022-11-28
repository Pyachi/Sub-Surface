using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

//Written By:
//Sarah Glass
//Mark Scheidker
public static class EnemyManager
{
    private static readonly GameObject Fish = Resources.Load("enemies/fish", typeof(GameObject)) as GameObject;
    private static readonly GameObject Shark = Resources.Load("enemies/shark", typeof(GameObject)) as GameObject;
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
        if (_credits < 1.0) //if there are not enough credits to spawn an enemy, then return
            return;

        _credits -= 1.0;
        var rand = Random.Range(0, 10); //pick a random number that corresponds to a specific fish
        GameObject selection;

        //pick a fish
        selection = rand < 9 ? Fish : Shark;

        Vector3 spawnPosition;
        while (true) //pick a random point off the screen and spawn an enemy, if the enemy is out of bounds try again.
        {
            var locAngle = Random.Range(0F, 2F * (float)Math.PI); //
            spawnPosition = _sub.transform.position +
                            new Vector3((float)(Math.Sin(locAngle) * 15), (float)(Math.Cos(locAngle) * 15), 0F);

            if (spawnPosition.y < 24F && spawnPosition.y > -24F) //try again if out of bounds
                break;
        }

        ObjectManager.AddObject(Object.Instantiate(selection, spawnPosition,
            Quaternion.identity)); //instantiate the enemy and add it to object list
    }
}