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
        

    }

    private void FixedUpdate()
    {
        thisrigidbody = this.gameObject.GetComponent<Rigidbody>();
        float suby = sub.position.y;
        float subx = sub.position.x;
        float thisy = thisrigidbody.position.y;
        float thisx = thisrigidbody.position.x;
        thisrigidbody.transform.eulerAngles = new Vector3(0, 0,
            Mathf.Atan2((suby - thisy), (subx - thisx)) *
            Mathf.Rad2Deg);
    }
}
