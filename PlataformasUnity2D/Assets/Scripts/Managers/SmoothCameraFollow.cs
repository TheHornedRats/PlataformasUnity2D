using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 baseOffset = new Vector3(0f, 1.5f, -10f);
    public float fallLookAhead = -2f;
    public float velocityThreshold = -1f;
    public float smoothSpeed = 5f;

    private Rigidbody2D targetRb;

    void Start()
    {
        if (target != null)
        {
            targetRb = target.GetComponent<Rigidbody2D>();
        }
    }

    void LateUpdate()
    {
        if (target == null || targetRb == null) return;

        Vector3 adjustedOffset = baseOffset;

        if (targetRb.velocity.y < velocityThreshold)
        {
            adjustedOffset.y += fallLookAhead;
        }

        Vector3 desiredPosition = target.position + adjustedOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
