using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public Rigidbody sub;
    private Rigidbody thisrigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        thisrigidbody = this.gameObject.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {


    }
}
