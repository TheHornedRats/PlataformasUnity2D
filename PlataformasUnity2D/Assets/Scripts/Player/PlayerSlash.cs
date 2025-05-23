using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    public GameObject slashPrefab;
    public Transform attackPoint;
    public float cooldown = 0.5f;

    private float lastSlashTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && Time.time - lastSlashTime >= cooldown)
        {
            Slash();
            lastSlashTime = Time.time;
        }
    }

    void Slash()
    {
        GameObject slash = Instantiate(slashPrefab, attackPoint.position, Quaternion.identity);

        float direction = transform.localScale.x > 0 ? 1f : -1f;
        Vector3 scale = slash.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        slash.transform.localScale = scale;
    }
}
