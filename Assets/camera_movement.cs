using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera_movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        float subX = GameObject.Find("submarine").transform.position.x;
        float subY = GameObject.Find("submarine").transform.position.y;
        float cameraX = GameObject.Find("Main Camera").transform.position.x;
        float cameraY = GameObject.Find("Main Camera").transform.position.y;
        GetComponent<Rigidbody>().AddForce(new Vector3(subX - cameraX , subY - cameraY,0));
        
        if (subX > 25)
            GameObject.Find("Main Camera").transform.position += new Vector3(-50,0,0);
        if (subX < -25)
            GameObject.Find("Main Camera").transform.position += new Vector3(50,0,0);
    }
}
