using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public GameObject submarine;
    private Transform _gunPivotPos;
    public Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        _gunPivotPos = transform.Find("GunPivot");
        bullet.AddForce(5000 * _gunPivotPos.eulerAngles.z,0,0);
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
