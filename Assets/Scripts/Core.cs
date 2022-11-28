using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject sub;
    public static GameObject SubObject;
    public static float Scale = 1F;

    private void Start()
    {
        SubObject = sub;
    }

    private void FixedUpdate()
    {
        Scale *= 1.0003F;
        EnemyManager.Update();
        BombManager.Update();
    }
}