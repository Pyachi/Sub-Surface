using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }
    

    void Update() {
        Rigidbody rbSub = GameObject.Find("subBody").GetComponent<Rigidbody>(); //can't move this out, I forgot how it was done, it is now significantly less taxing
        Rigidbody rbCamera = GameObject.Find("Main Camera").GetComponent<Rigidbody>();
        float frametime = Time.deltaTime * 100; //get time since last frame

        float subX = rbSub.transform.position.x;  //get current position of objects in submarine
        float subY = rbSub.transform.position.y;
        float cameraX = rbCamera.transform.position.x;
        float cameraY = rbCamera.transform.position.y;

        rbCamera.AddForce(new Vector3((subX - cameraX) * frametime, (subY - cameraY) * 100 * frametime,0));  //move camera towards sub body

        if (Input.GetKey(KeyCode.A))           //move sub body in direction of player input
            rbSub.AddForce(new Vector3(1 * frametime,0,0));
        if (Input.GetKey(KeyCode.D))
            rbSub.AddForce(new Vector3(-1 * frametime,0,0));
        if (Input.GetKey(KeyCode.W))
            rbSub.AddForce(new Vector3(0,1 * frametime,0));
        if (Input.GetKey(KeyCode.S))
            rbSub.AddForce(new Vector3(0,-1 * frametime,0));

        if (subX > 25) {              //snap camera and body to other side of level if moved there
            rbSub.transform.position += new Vector3(-50, 0, 0);
            rbCamera.transform.position += new Vector3(-50, 0, 0);
        }
        if (subX < -25) {
            rbSub.transform.position += new Vector3(50, 0, 0);
            rbCamera.transform.position += new Vector3(50, 0, 0);
        }

        if (subY > 24.75) //add force for above surface
            rbSub.AddForce(new Vector3(0,(float)(subY-24.75)*(-2) * frametime,0));
        if (subY < -24.75) //stop sub at seafloor
            rbSub.transform.position = new Vector3(subX,(float)-24.75,0); 
    }
}
