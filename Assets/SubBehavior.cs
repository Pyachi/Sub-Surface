using System;
using System.Drawing;
using UnityEngine;

public class SubBehavior : MonoBehaviour
{

    private Rigidbody _sub;
    private Rigidbody _camera;
    private void Start()
    {
        AudioManager.Play("submarine_ambience"); 
        _sub = GetComponent<Rigidbody>();
        _camera = FindObjectOfType<Camera>().GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {


    }

    public void FixedUpdate()
    {
        //get current position of objects in submarine
        var pos1 = _sub.transform.position;
        var subX = pos1.x;
        var subY = pos1.y;
        var pos2 = _camera.transform.position;
        var cameraX = pos2.x;
        var cameraY = pos2.y;

        //move camera towards sub body
        _camera.AddForce(new Vector3((subX - cameraX) * 2, (subY - cameraY) * 2, 0));

        //move sub body in direction of player input
        if (Input.GetKey(KeyCode.A))
            _sub.AddForce(new Vector3(2, 0, 0));
        if (Input.GetKey(KeyCode.D))
            _sub.AddForce(new Vector3(-2, 0, 0));
        if (Input.GetKey(KeyCode.W))
            _sub.AddForce(new Vector3(0, 2, 0));
        if (Input.GetKey(KeyCode.S))
            _sub.AddForce(new Vector3(0, -2, 0));
        if (Input.GetKey(KeyCode.F))
            AudioManager.PlayOneShot("SubBump");
            

        //snap camera and body to other side of level if moved there
        if (subX > 25)
        {
            _sub.transform.position += new Vector3(-50, 0, 0);
            _camera.transform.position += new Vector3(-50, 0, 0);
        }

        if (subX < -25)
        {
            _sub.transform.position += new Vector3(50, 0, 0);
            _camera.transform.position += new Vector3(50, 0, 0);
        }

        //add stop sub above surface
        if (subY > 24.75)
            _sub.AddForce(new Vector3(0, (float)(subY - 24.75) * -4, 0));
        //stop sub at seafloor
        if (subY < -24.75)
            //_sub.transform.position = new Vector3(subX, (float)-24.75, 0);
        //raise camera near surface
        if(cameraY > 24)
            _camera.AddForce(new Vector3(0,(cameraY - 24) * 1, 0));
        //stop camera near seafloor
        if(cameraY < -15)
            _camera.AddForce(new Vector3(0,  (cameraY + 15) * (float)-1.2, 0));
        
        //change pitch and volume of submarine based on speed
        AudioManager.SetPitch("submarine_ambience", ((_sub.velocity.magnitude)/8) + 1 );
        AudioManager.SetVolume("submarine_ambience", ((_sub.velocity.magnitude)/8) + (float)0.1);
        
        //set fog color based on height
        if (cameraY < 25)
        {
            RenderSettings.fogEndDistance = 30;
            RenderSettings.fogColor = new Color32((byte)((cameraY+25)*1.5),(byte)((cameraY+25)*1.5),(byte)((cameraY+70)*2), 0);
        }
        else
        {
            RenderSettings.fogEndDistance = 3000;
        }

    }

}