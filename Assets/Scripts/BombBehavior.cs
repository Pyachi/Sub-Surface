using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class BombBehavior: MonoBehaviour
{
    public ParticleSystem FireParticles;
    public Light Light;
    //public ParticleSystem SootParticles;
    //public ParticleSystem SmokeParticles;
    
    private Rigidbody thisrigidbody;
    private bool explosionstarted = false;
    private float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       thisrigidbody = this.gameObject.GetComponent<Rigidbody>();
       var Emission = FireParticles.emission;
       Emission.enabled = false;

       Light.intensity = 0;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 subpos = Core.SubObject.transform.position;
            subpos.y -= 0.9f;
            Vector3 difference = subpos - this.transform.position;
            float distance = difference.magnitude;
            
            if (distance < 1.5 && distance > 1)
            {
                thisrigidbody.AddForce((difference*10) / (distance * 2.0f));
            }
            else if (distance < 1)
            {
                thisrigidbody.AddForce(difference*15);
            }

            if (Input.GetKey(KeyCode.E) && explosionstarted == false && distance < 1)  //if E is also being pressed then start explosion sequence
            {
                explosionstarted = true;
                Invoke(nameof(Countdown), Random.value/4);
            }
        }
    }
    
    

    void Countdown()
    {
        AudioManager.PlayOneShot("beep");
        timer -= timer * 0.15f;

        if (timer > 0.01)
        {
            Invoke(nameof(Countdown), timer);
        }
        else
        {
            //make the bomb invisible
            foreach (var renderer in this.gameObject.GetComponentsInChildren<MeshRenderer>())  
            {
                renderer.enabled = false;
            }
            
            //play the sound
            AudioManager.PlayOneShot("Explosion");
            
            //start particle systems
            var Emission = FireParticles.emission;
            Emission.enabled = true;
            
            //start light
            Light.intensity = 3;
            
            
            Invoke(nameof(Explosion), 0.2f);
        }
    }

    private void Explosion()
    {
        //stop particles
        var Emission = FireParticles.emission;
        Emission.enabled = false;
        
        // stop light
        Light.intensity = 0;
        
        Invoke(nameof(Delete), 0.5f);
        
    }

    private void Delete()
    {
        ObjectManager.RemoveObject(this.gameObject);
        Destroy(this.gameObject);
    }
}
