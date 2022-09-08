using UnityEngine;

public class SubBehavior : MonoBehaviour
{
    public void Update()
    {
        var sub = gameObject.transform.Find("subBody").GetComponent<Rigidbody>();
        var camera = gameObject.transform.Find("Main Camera").GetComponent<Rigidbody>();

        //get current position of objects in submarine
        var pos1 = sub.transform.position;
        var subX = pos1.x;
        var subY = pos1.y;
        var pos2 = camera.transform.position;
        var cameraX = pos2.x;
        var cameraY = pos2.y;

        //move camera towards sub body
        camera.AddForce(new Vector3(subX - cameraX, subY - cameraY, 0));

        //move sub body in direction of player input
        if (Input.GetKey(KeyCode.A))
            sub.AddForce(new Vector3(1, 0, 0));
        if (Input.GetKey(KeyCode.D))
            sub.AddForce(new Vector3(-1, 0, 0));
        if (Input.GetKey(KeyCode.W))
            sub.AddForce(new Vector3(0, 1, 0));
        if (Input.GetKey(KeyCode.S))
            sub.AddForce(new Vector3(0, -1, 0));

        //snap camera and body to other side of level if moved there
        if (subX > 25)
        {
            sub.transform.position += new Vector3(-50, 0, 0);
            camera.transform.position += new Vector3(-50, 0, 0);
        }

        if (subX < -25)
        {
            sub.transform.position += new Vector3(50, 0, 0);
            camera.transform.position += new Vector3(50, 0, 0);
        }

        //add force for above surface
        if (subY > 24.75)
            sub.AddForce(new Vector3(0, (float)(subY - 24.75) * -2, 0));
        //stop sub at seafloor
        if (subY < -24.75)
            sub.transform.position = new Vector3(subX, (float)-24.75, 0);
    }
}