using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject sub;
    public static GameObject SubObject;

    private void Start()
    {
        SubObject = sub;
    }
    
    private void FixedUpdate()
    {
        EnemyManager.Update();
    }
}