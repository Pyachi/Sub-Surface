using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Transform _gunPivotPos;
    public Rigidbody bullet;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position.y > 25)
        {
            rigid.useGravity = true;
            rigid.drag = 0.0f;
        }
        else
        {
            rigid.useGravity = false;
            rigid.drag = 0.1f;
        }
    }

    void OnBecameInvisible()
    {
        Invoke("Delete", 1f);
    }
    private void OnBecameVisible()
    {
        CancelInvoke("Delete");
    }
    
    void Delete()
    {
        Destroy(this.gameObject);
    }

    void snapleft()
    {
        this.gameObject.transform.position += new Vector3(-50, 0, 0);
    }
    void snapright()
    {
        this.gameObject.transform.position += new Vector3(50, 0, 0);
    }
}
