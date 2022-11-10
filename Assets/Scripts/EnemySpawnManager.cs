using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject sub;
    public Rigidbody fish1;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(SpawnEnemy), 0.0f);
    }

    void SpawnEnemy()
    {
        int fish = (int)Random.value * 3;
        float subposx = sub.transform.position.x;
        float subposy = sub.transform.position.y;

        if (fish == 0)
        {
            //Rigidbody thisfish = Instantiate(fish1);
        }
        if (fish == 1)
        {
            //Rigidbody thisfish = Instantiate(fish2);
        }
        if (fish == 2)
        {
            //Rigidbody thisfish = Instantiate(fish3);
        }
        
        //then invoke again randomly based on total time in game, more game time means less invoke time
    }
}
