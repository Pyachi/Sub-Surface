using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using UnityEngine;
using UnityEngine.Analytics;

public class SubBehavior : MonoBehaviour
{
    public Rigidbody sub;
    public GameObject gunPivot;
    public Rigidbody camera;
    public Rigidbody bullet;
    public ParticleSystem Bubbles;
    public ParticleSystem RU_Thrust_bubbles;
    public ParticleSystem LU_Thrust_bubbles;
    public ParticleSystem RD_Thrust_bubbles;
    public ParticleSystem LD_Thrust_bubbles;

    private bool ClickBlock;
    
    //modifiable at runtime or at developer's discretion
    private float BulletSpeed = 5;
    private float BarrelLength = 0.75f;
    private float ClickCooldown = 0.1f;
    private bool Rapidfire = true;
    private void Start()
    {
        AudioManager.Play("submarine_ambience");
        ObjectManager.AddObject(sub.gameObject);
        ObjectManager.AddObject(camera.gameObject);
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
        
        //get the emission modules of each thruster
        var ruEmission = RU_Thrust_bubbles.emission;
        var luEmission = LU_Thrust_bubbles.emission;
        var rdEmission = RD_Thrust_bubbles.emission;
        var ldEmission = LD_Thrust_bubbles.emission;

        //move camera towards sub body
        camera.AddForce(new Vector3((subX - cameraX) * 2, (subY - cameraY) * 2, 0));

        //get the values of each key
        var aKey = Input.GetKey(KeyCode.A);
        var dKey = Input.GetKey(KeyCode.D);
        var wKey = Input.GetKey(KeyCode.W);
        var sKey = Input.GetKey(KeyCode.S);
        
        //move sub body in direction of player input
        if (aKey) sub.AddForce(new Vector3(-2, 0, 0));
        if (dKey) sub.AddForce(new Vector3(2, 0, 0));
        if (wKey) sub.AddForce(new Vector3(0, 2, 0)); 
        if (sKey) sub.AddForce(new Vector3(0, -2, 0));

        var x = 0;
        if (wKey) x += 1;
        if (aKey) x += 2;
        if (sKey) x += 4;
        if (dKey) x += 8;

        if (x % 5 == 0 && x != 0)
        {
            ruEmission.enabled = true;
            luEmission.enabled = true;
            rdEmission.enabled = true;
            ldEmission.enabled = true;
        }
        else
        {
            ruEmission.enabled = x == 2 || x == 4 || x == 6 || x == 7 || x == 14;
            luEmission.enabled = x == 4 || x == 8 || x == 12 || x == 13 || x == 14;
            rdEmission.enabled = x == 1 || x == 2 || x == 3 || x == 7 || x == 11;
            ldEmission.enabled = x == 1 || x == 8 || x == 9 || x == 11 || x == 13;
        }

        //snap camera and body and bullets to other side of level if moved there
        if (subX > 25)
            ObjectManager.ShiftLeft();

        if (subX < -25)
            ObjectManager.ShiftRight();
        
        //add stop sub above surface
        if (subY > 24.75)
            sub.AddForce(new Vector3(0, (float)(subY - 24.75) * -4, 0));
        //stop sub at seafloor
        if (subY < -24.75)
            //_sub.transform.position = new Vector3(subX, (float)-24.75, 0);
        //raise camera near surface
        if(cameraY > 24)
            camera.AddForce(new Vector3(0,(cameraY - 24) * 1.5f, 0));
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
            RenderSettings.fogColor = new Color32((byte)((cameraY+25)*1.7),(byte)((cameraY+25)*1.7),(byte)((cameraY+70)*2), 0);
        }
        else
        {
            RenderSettings.fogEndDistance = 3000;
        }
    }

    private void Update()
    {
        //calculate the angle of sub gun by finding angle from submarine to mouse cursor
        //get mouse position in pixels
        Vector2 mousePos = Input.mousePosition;
        //get game window center point
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //subtract sub position in pixels relative game window from mouse position (scaled by window size)
        mousePos -= new Vector2((sub.position.x - camera.position.x) * (Screen.width / 21), (sub.position.y - camera.position.y) * (Screen.height / 12) );
        //subtract screen center from mouse position
        mousePos -= screenCenter;
        //set the angle of the gun to point at the mouse
        gunPivot.transform.eulerAngles = new Vector3(0,0, 360 - Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);

        //this does not work yet
        var particleArray = new ParticleSystem.Particle[30];
        Bubbles.GetParticles(particleArray);
        for (int i = 0; i < 30; i++)
        {
            if (particleArray[i].position.y > 50)
            {
                particleArray[i].remainingLifetime = 0;
            }
        }
        
        // spawns the bullet on mouse click with variable cooldown, or rapidfires if rapidfire is enabled
        if ((Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && Rapidfire)) && !ClickBlock)
        {
            //set the click block to true and invoke method to unblock later
            ClickBlock = true;
            Invoke(nameof(ClickUnblock), ClickCooldown);
            
            //get the barrel angle once 
            float BarrelAngleZ = gunPivot.transform.eulerAngles.z;
            
            // instatntiate a bullet at the position of the edge of the gun barrel, scaled by barrel length
            Rigidbody thisbullet = Instantiate(bullet, 
                new Vector3(
                    sub.position.x + Mathf.Cos((BarrelAngleZ + 90) * Mathf.Deg2Rad) * BarrelLength,
                    sub.position.y + Mathf.Sin((BarrelAngleZ + 90) * Mathf.Deg2Rad) * BarrelLength,
                    sub.position.z
                ),
                sub.rotation
            );
            
            //store and save each rigid body for each newly spawned bullet
            ObjectManager.AddObject(thisbullet.gameObject);

            //add a force to the bullet that is relative to the gun's rotation, multiplied by bullet speed, and relative to the sub's current speed
            thisbullet.AddForce(
                new Vector3(
                    Mathf.Cos((BarrelAngleZ + 90) * Mathf.Deg2Rad) * BulletSpeed * 100 + (sub.velocity.x * 50),
                    Mathf.Sin((BarrelAngleZ + 90) * Mathf.Deg2Rad) * BulletSpeed * 100 + (sub.velocity.y * 50),
                    0
                )
            );
        }
    }

    private void ClickUnblock()
    {
        ClickBlock = false;
    }
}
