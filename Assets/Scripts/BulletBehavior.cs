using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Transform _gunPivotPos;
    private Rigidbody _rigid;

    public void Start()
    {
        _rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position.y > 25)
        {
            _rigid.useGravity = true;
            _rigid.drag = 0.0f;
        }
        else
        {
            _rigid.useGravity = false;
            _rigid.drag = 0.1f;
        }
    }

    void OnBecameInvisible()
    {
        Invoke(nameof(Delete), 1f);
    }
    private void OnBecameVisible()
    {
        CancelInvoke("Delete");
    }

    private void Delete()
    {
        ObjectManager.RemoveObject(_rigid.gameObject);
        Destroy(gameObject);
    }
}
