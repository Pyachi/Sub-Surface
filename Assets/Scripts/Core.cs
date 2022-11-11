using System;
using UnityEngine;

public class Core : MonoBehaviour
{
    private void FixedUpdate()
    {
        EnemyManager.Update();
    }
}