using System;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject sub;
    public static GameObject subObject;

    private void Start()
    {
        subObject = sub;
    }
    
    private void FixedUpdate()
    {
        EnemyManager.Update();
    }
}