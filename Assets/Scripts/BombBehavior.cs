using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BombBehavior: MonoBehaviour
{
    private Rigidbody thisrigidbody;
    // Start is called before the first frame update
    void Start()
    {
       thisrigidbody = this.gameObject.GetComponent<Rigidbody>();
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
        }
    }

    void countdown()
    {
        
    }

    private void particles()
    {
        
    }

    private void explode()
    {
        
    }
}
