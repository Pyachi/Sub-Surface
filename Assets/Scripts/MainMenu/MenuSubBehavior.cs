using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public class MenuSubBehavior : MonoBehaviour
{
    //modifiable at runtime or at developer's discretion
    private const float BulletSpeed = 5;
    private const float BarrelLength = 0.75f;
    private const float ClickCooldown = 0.1f;
    private const bool RapidFire = true;
    public Rigidbody sub;
    public GameObject gunPivot;
    public ParticleSystem bubbles;
    public Rigidbody bullet;
    public ParticleSystem ruThrustBubbles;
    public ParticleSystem luThrustBubbles;
    public ParticleSystem rdThrustBubbles;
    public ParticleSystem ldThrustBubbles;

    //private static float subpitch = 1;
    //private static float subvolume = 0.1f;

    private bool _clickBlock;

    private void Start()
    {
        AudioManager.Play("menu_theme");
    }

    private void Update()
    {
        //calculate the angle of sub gun by finding angle from submarine to mouse cursor
        //get mouse position in pixels
        Vector2 mousePos = Input.mousePosition;
        //get game window center point
        var screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //subtract sub position in pixels relative game window from mouse position (scaled by window size)
        var subPos = sub.position;
        var camPos = new Vector3(0, 1, -10);
        mousePos -= new Vector2((subPos.x - camPos.x) * (Screen.width / 5.2F),
            (subPos.y - camPos.y) * (Screen.height / 2.7F));
        //subtract screen center from mouse position
        mousePos -= screenCenter;
        //set the angle of the gun to point at the mouse
        gunPivot.transform.eulerAngles = new Vector3(0, 0, 360 - Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);

        // spawns the bullet on mouse click with variable cooldown, or rapidfires if rapidfire is enabled
        if ((Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && RapidFire)) && !_clickBlock)
        {
            //set the click block to true and invoke method to unblock later
            _clickBlock = true;
            Invoke(nameof(ClickUnblock), ClickCooldown);

            //get the barrel angle once 
            var barrelAngleZ = gunPivot.transform.eulerAngles.z;

            // instantiate a bullet at the position of the edge of the gun barrel, scaled by barrel length
            var bulletObj = Instantiate(bullet,
                new Vector3(
                    sub.position.x + Mathf.Cos((barrelAngleZ + 90) * Mathf.Deg2Rad) * BarrelLength,
                    sub.position.y + Mathf.Sin((barrelAngleZ + 90) * Mathf.Deg2Rad) * BarrelLength,
                    sub.position.z
                ),
                sub.rotation
            );

            //add a force to the bullet that is relative to the gun's rotation, multiplied by bullet speed, and relative to the sub's current speed
            bulletObj.AddForce(
                new Vector3(
                    Mathf.Cos((barrelAngleZ + 90) * Mathf.Deg2Rad) * BulletSpeed * 100 + sub.velocity.x * 50,
                    Mathf.Sin((barrelAngleZ + 90) * Mathf.Deg2Rad) * BulletSpeed * 100 + sub.velocity.y * 50,
                    0
                )
            );
        }
    }

    public void FixedUpdate()
    {
        //get current position of objects in submarine
        var pos1 = sub.transform.position;
        var subX = pos1.x;
        var subY = pos1.y;

        //get the emission modules of each thruster
        var ruEmission = ruThrustBubbles.emission;
        var luEmission = luThrustBubbles.emission;
        var rdEmission = rdThrustBubbles.emission;
        var ldEmission = ldThrustBubbles.emission;

        //get the values of each key
        var aKey = Input.GetKey(KeyCode.A);
        var dKey = Input.GetKey(KeyCode.D);
        var wKey = Input.GetKey(KeyCode.W);
        var sKey = Input.GetKey(KeyCode.S);

        //move sub body in direction of player input
        if (aKey) sub.AddForce(new Vector3(-2, 0, 0));
        if (dKey) sub.AddForce(new Vector3(2, 0, 0));
        if (wKey) sub.AddForce(new Vector3(0, 2, 0));
        if (sKey) sub.AddForce(new Vector3(0, -2, 0));

        //move sub body in direction of original position;
        var difference = new Vector3(-1, 0, -6) - pos1;

        sub.AddForce(difference * 5);

        //generate a unique number for each key combo
        var x = 0;
        if (wKey) x += 1;
        if (aKey) x += 2;
        if (sKey) x += 4;
        if (dKey) x += 8;

        //if the mod 5 of x is 0 then enable all thrusters, else use the table of known key inputs to generate correct output
        if (x % 5 == 0 && x != 0)
        {
            ruEmission.enabled = true;
            luEmission.enabled = true;
            rdEmission.enabled = true;
            ldEmission.enabled = true;
        }
        else
        {
            ruEmission.enabled = x == 2 || x == 4 || x == 6 || x == 7 || x == 14;
            luEmission.enabled = x == 4 || x == 8 || x == 12 || x == 13 || x == 14;
            rdEmission.enabled = x == 1 || x == 2 || x == 3 || x == 7 || x == 11;
            ldEmission.enabled = x == 1 || x == 8 || x == 9 || x == 11 || x == 13;
        }

        /* //change pitch and volume of submarine based on speed
        subpitch = subpitch * 0.85f + (sub.velocity.magnitude/8 + 1) * 0.15f;
        subvolume = subvolume * 0.85f + (sub.velocity.magnitude/8 + 0.1f) * 0.15f;
        AudioManager.SetPitch("submarine_ambience", subpitch);
        AudioManager.SetVolume("submarine_ambience", subvolume);
        */
    }

    private void ClickUnblock()
    {
        _clickBlock = false;
    }
}