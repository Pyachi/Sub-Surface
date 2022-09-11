using System;
using UnityEngine;

public class SubBehavior : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("submarine_ambience");
    }

    private void OnCollisionEnter(Collision collision)
    {


    }

    public void FixedUpdate()
    {
        //Gets sub-objects without relying on names
        var sub = GetComponentInChildren<SphereCollider>().GetComponent<Rigidbody>();
        var camera =  GetComponentInChildren<Camera>().GetComponent<Rigidbody>();
        var audio = FindObjectOfType<AudioManager>();

        //get current position of objects in submarine
        var pos1 = sub.transform.position;
        var subX = pos1.x;
        var subY = pos1.y;
        var pos2 = camera.transform.position;
        var cameraX = pos2.x;
        var cameraY = pos2.y;

        //move camera towards sub body
        camera.AddForce(new Vector3((subX - cameraX) * 2, (subY - cameraY) * 2, 0));

        //move sub body in direction of player input
        if (Input.GetKey(KeyCode.A))
            sub.AddForce(new Vector3(2, 0, 0));
        if (Input.GetKey(KeyCode.D))
            sub.AddForce(new Vector3(-2, 0, 0));
        if (Input.GetKey(KeyCode.W))
            sub.AddForce(new Vector3(0, 2, 0));
        if (Input.GetKey(KeyCode.S))
            sub.AddForce(new Vector3(0, -2, 0));
        if (Input.GetKey(KeyCode.F))
            FindObjectOfType<AudioManager>().PlayOneShot("SubBump");
            

        //snap camera and body to other side of level if moved there
        if (subX > 25)
        {
            sub.transform.position += new Vector3(-50, 0, 0);
            camera.transform.position += new Vector3(-50, 0, 0);
        }

        if (subX < -25)
        {
            sub.transform.position += new Vector3(50, 0, 0);
            camera.transform.position += new Vector3(50, 0, 0);
        }

        //add force for above surface
        if (subY > 24.75)
            sub.AddForce(new Vector3(0, (float)(subY - 24.75) * -4, 0));
        //stop sub at seafloor
        if (subY < -24.75)
            sub.transform.position = new Vector3(subX, (float)-24.75, 0);
        //stop camera near seafloor
        if(cameraY < -15)
            camera.AddForce(new Vector3(0,  (cameraY + 15) * -2, 0));
        
        
        //change pitch and volume of submarine based on speed
        audio.SetPitch("submarine_ambience", ((sub.velocity.magnitude)/8) + 1 );
        audio.SetVolume("submarine_ambience", ((sub.velocity.magnitude)/5) + (float)0.1);
        
    }
}