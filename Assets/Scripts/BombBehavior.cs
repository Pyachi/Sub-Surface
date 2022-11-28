using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public class BombBehavior : MonoBehaviour
{
    public ParticleSystem FireParticles;
    public Light Light;
    public Material RustyMetal;
    public Material LightGrayMetal;
    public Material Red;

    public Rigidbody bullet;

    private bool _explosionstarted;
    //public ParticleSystem SootParticles;
    //public ParticleSystem SmokeParticles;

    private Rigidbody _thisrigidbody;
    private float _timer = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        _thisrigidbody = gameObject.GetComponent<Rigidbody>();
        var emission = FireParticles.emission;
        emission.enabled = false;

        Light.intensity = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var subpos = Core.SubObject.transform.position;
            subpos.y -= 0.9f;
            var difference = subpos - transform.position;
            var distance = difference.magnitude;

            if (distance < 1.5 && distance > 1)
                _thisrigidbody.AddForce(difference * 10 / (distance * 2.0f));
            else if (distance < 1) _thisrigidbody.AddForce(difference * 15);

            if (Input.GetKey(KeyCode.E) && _explosionstarted == false &&
                distance < 1) //if E is also being pressed then start explosion sequence
            {
                _explosionstarted = true;
                Invoke(nameof(Countdown), Random.value / 4);
            }
        }
    }

    private void Countdown()
    {
        //play beeping sound
        AudioManager.PlayOneShot("beep");

        Invoke(nameof(Blink), 0.0f);

        //decrement timer amount by 15%
        _timer -= _timer * 0.15f;

        if (_timer > 0.01)
        {
            Invoke(nameof(Countdown), _timer);
        }
        else
        {
            //make the bomb invisible
            foreach (var rend in gameObject.GetComponentsInChildren<MeshRenderer>()) rend.enabled = false;

            //turn off collider for bomb components
            foreach (var coll in gameObject.GetComponentsInChildren<Collider>()) coll.enabled = false;

            //play the explosion sound
            AudioManager.PlayOneShot("Explosion");

            //start particle systems
            var emission = FireParticles.emission;
            emission.enabled = true;

            //start light
            Light.intensity = 3;

            //fire bullets in all directions
            var currentpos = _thisrigidbody.position;
            for (var i = 0; i < 360; i += 2)
            {
                var thisbullet = Instantiate(bullet, currentpos, new Quaternion());
                ObjectManager.AddObject(thisbullet.gameObject);
                thisbullet.AddForce(new Vector3(
                    Mathf.Sin(i * Mathf.Deg2Rad) * 750 * (Random.value + 0.5f),
                    Mathf.Cos(i * Mathf.Deg2Rad) * 750 * (Random.value + 0.5f),
                    0
                ));
            }

            Invoke(nameof(Explosion), 0.2f);
        }
    }

    private void Explosion()
    {
        //stop particles
        var emission = FireParticles.emission;
        emission.enabled = false;

        // stop light
        Light.intensity = 0;

        Invoke(nameof(Delete), 0.5f);
    }

    private void Delete()
    {
        ObjectManager.RemoveObject(gameObject);
        Destroy(gameObject);
    }

    private void Blink()
    {
        foreach (var rend in gameObject.GetComponentsInChildren<MeshRenderer>()) rend.material = Red;
        Invoke(nameof(UnBlink), 0.05f);
    }

    private void UnBlink()
    {
        foreach (var rend in gameObject.GetComponentsInChildren<MeshRenderer>())
            rend.material = rend.gameObject.GetComponent<SphereCollider>() != null ? RustyMetal : LightGrayMetal;
    }
}