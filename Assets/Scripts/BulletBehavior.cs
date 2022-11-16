using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
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

    private void OnBecameInvisible()
    {
        Invoke(nameof(Delete), 1f);
    }
    private void OnBecameVisible()
    {
        CancelInvoke(nameof(Delete));
    }

    private void Delete()
    {
        ObjectManager.RemoveObject(_rigid.gameObject);
        Destroy(gameObject);
    }
}
