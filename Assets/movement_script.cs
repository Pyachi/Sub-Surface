using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        float xpos = GameObject.Find("submarine").transform.position.x;  //get current position of object
        float ypos = GameObject.Find("submarine").transform.position.y;
        
        Rigidbody rb = GetComponent<Rigidbody>();  //wasd movement
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down);
        
        if (xpos > 25)   //snap the submarine 
            rb.transform.position += new Vector3(-50,0,0);
        if (xpos < -25)
            rb.transform.position += new Vector3(50,0,0);
        
        if (ypos > 24.75) //add force for above surface
            rb.AddForce(new Vector3(0,(float)(ypos-24.75)*(-2),0));
        if (ypos < -24.75) //stop sub at seafloor
            rb.transform.position = new Vector3(xpos,(float)-24.75,0);
    }
}