using UnityEngine;

public class CameraClamp2D : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D bounds;

    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = target.position;

        float minX = bounds.bounds.min.x + camHalfWidth;
        float maxX = bounds.bounds.max.x - camHalfWidth;
        float minY = bounds.bounds.min.y + camHalfHeight;
        float maxY = bounds.bounds.max.y - camHalfHeight;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}