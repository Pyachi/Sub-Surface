using System;
using System.Data.Common;
using System.Drawing;
using UnityEngine;

public class SubBehavior : MonoBehaviour
{

    public Rigidbody sub;
    public GameObject gunPivot;
    public Rigidbody camera;
    private void Start()
    {
        AudioManager.Play("submarine_ambience"); 
        

    }

    private void OnCollisionEnter(Collision collision)
    {


    }

    public void FixedUpdate()
    {
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
            AudioManager.PlayOneShot("SubBump");
            

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

        //add stop sub above surface
        if (subY > 24.75)
            sub.AddForce(new Vector3(0, (float)(subY - 24.75) * -4, 0));
        //stop sub at seafloor
        if (subY < -24.75)
            //_sub.transform.position = new Vector3(subX, (float)-24.75, 0);
        //raise camera near surface
        if(cameraY > 24)
            camera.AddForce(new Vector3(0,(cameraY - 24) * 1, 0));
        //stop camera near seafloor
        if(cameraY < -15)
            camera.AddForce(new Vector3(0,  (cameraY + 15) * (float)-1.2, 0));
        
        //change pitch and volume of submarine based on speed
        AudioManager.SetPitch("submarine_ambience", ((sub.velocity.magnitude)/8) + 1 );
        AudioManager.SetVolume("submarine_ambience", ((sub.velocity.magnitude)/8) + (float)0.1);
        
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

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        mousePos -= screenCenter;
        gunPivot.transform.eulerAngles = new Vector3(0,0, 360 - Mathf.Atan2(-mousePos.x, mousePos.y) * Mathf.Rad2Deg);
        //Debug.Log("it's running");

    }
}