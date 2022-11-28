using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public class Core : MonoBehaviour
{
    public static GameObject SubObject;
    public static float Scale = 1F;
    public GameObject sub;

    private void Start()
    {
        SubObject = sub;
        Scale = 1F;
    }

    private void FixedUpdate()
    {
        Scale *= 1.0003F;
        EnemyManager.Update();
        BombManager.Update();
    }
}