using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public static class BombManager
{
    private static readonly GameObject Bomb = Resources.Load("spawnables/Bomb", typeof(GameObject)) as GameObject;
    private static int _lifetime;
    private static double _credits;

    public static void Update()
    {
        _lifetime++;
        _credits += 0.02; //To be scaled with time, credits are spent to spawn bombs
        if (_credits < 10.0) //if there are not enough credits to spawn a bomb, then return
        {
            return;
        }
        _credits -= 10.0;
        
        Vector3 spawnPosition;
        while (true) //pick a random point off the screen and spawn a bomb, if the bomb is out of bounds try again.
        {
            var locAngle = Random.Range(0F, 2F * (float)Math.PI); //
            spawnPosition = Core.SubObject.transform.position + new Vector3((float)(Math.Sin(locAngle) * 15), (float)(Math.Cos(locAngle) * 15), 0F);

            if (spawnPosition.y < 24F && spawnPosition.y > -24F)  //try again if out of bounds
            {
                break;
            }
        }
        
        ObjectManager.AddObject(Object.Instantiate(Bomb, spawnPosition, Quaternion.identity));  //instantiate the bomb and add it to object list
    }
}