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
        EnemyManager.Update();
        BombManager.Update();
    }
}