using System.Collections.Generic;
using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public class EnemyBehavior : MonoBehaviour
{
    //Preset stats for enemy type
    public int health;
    public int damage;
    public float speed;
    public int targetingDistance;
    public int money;
    
    [HideInInspector] public List<Vector2> target = new List<Vector2>();
    
    //Actual storage for damage and health as they scale with time
    private int _damage;
    private int _health;

    private void Start()
    {
        //Scales health and damage with time
        _health = (int)(health * Core.Scale);
        _damage = (int)(damage * Core.Scale);
    }

    private void FixedUpdate()
    {
        //Rotation
        var subPos = Core.SubObject.transform.position;
        var subY = subPos.y;
        var subX = subPos.x;
        var pos = transform.position;
        var x = pos.x;
        var y = pos.y;
        //Set rotation to face player
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(subY - y, subX - x) * Mathf.Rad2Deg);

        //Movement
        target.Add(subPos + Core.SubObject.GetComponent<Rigidbody>().velocity);
        while (target.Count > targetingDistance + 1) target.RemoveAt(0);
        if (target.Count > 0)
        {
            //Move enemy towards player target
            var tar = target[0];
            var position = new Vector2(x, y);
            var dif = tar - position;
            Vector2 newPos;
            if (dif.magnitude >= 1.0) newPos = position + (tar - position).normalized * speed;
            else newPos = position + (tar - position) * speed;
            transform.position = new Vector3(newPos.x, newPos.y, pos.z);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            //Take damage when hit with bullets
            _health -= PlayerPrefs.GetInt("DamageLevel");
            Destroy(collision.gameObject);
            if (_health > 0) return;
            AudioManager.PlayOneShot("Explosion");
            PlayerPrefs.SetInt("Money", (int)(PlayerPrefs.GetInt("Money") + money * Core.Scale));
            Destroy(transform.GetChild(0).gameObject);
            Destroy(this);
        }
        else if (collision.gameObject == Core.SubObject)
        {
            //Deal damage to submarine when collided with submarine
            Core.SubObject.GetComponent<SubBehavior>().TakeDamage(_damage);
            Destroy(transform.GetChild(0).gameObject);
            Destroy(this);
        }
    }
}