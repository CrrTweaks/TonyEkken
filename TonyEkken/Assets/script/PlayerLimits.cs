using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = 0f;
    public float maxY = 8f;

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}