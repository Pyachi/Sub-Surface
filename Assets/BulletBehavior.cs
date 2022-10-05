using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public GameObject gunpivot;
    public Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet.AddForce(0,500,0);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        bullet.AddForce(0,-2,0);
    }
}
