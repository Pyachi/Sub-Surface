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
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 360 - Mathf.Atan2(this.transform.position.x - sub.transform.position.x, this.transform.position.y - sub.transform.position.y) * Mathf.Rad2Deg);
    }
}
