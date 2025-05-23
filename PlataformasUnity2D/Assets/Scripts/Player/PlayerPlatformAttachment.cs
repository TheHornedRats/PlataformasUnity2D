using UnityEngine;

public class PlayerPlatformAttachment : MonoBehaviour
{
    public Transform groundCheck;          // Punto desde donde lanzamos el raycast
    public float rayLength = 0.1f;         // Distancia del raycast
    public LayerMask platformLayer;        // Capa de plataformas móviles

    private Transform currentPlatform;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLength, platformLayer);

        if (hit.collider != null && hit.collider.CompareTag("MovingPlatform"))
        {
            if (currentPlatform != hit.collider.transform)
            {
                currentPlatform = hit.collider.transform;
                transform.SetParent(currentPlatform);
            }
        }
        else
        {
            if (currentPlatform != null)
            {
                currentPlatform = null;
                transform.SetParent(null);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * rayLength);
        }
    }
}
