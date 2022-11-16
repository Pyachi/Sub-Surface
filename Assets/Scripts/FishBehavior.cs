using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    private void FixedUpdate()
    {
        var subPos = Core.SubObject.transform.position;
        var subY = subPos.y;
        var subX = subPos.x;
        var position = transform.position;
        var x = position.x;
        var y = position.y;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(subY - y, subX - x) * Mathf.Rad2Deg);
    }
}