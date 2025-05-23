using UnityEngine;

public class Slash : MonoBehaviour
{
    public float duration = 0.2f;
    public float knockbackDistance = 0.5f;
    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);

            // Empujar al enemigo si tiene Rigidbody
            Vector2 knockback = new Vector2(transform.right.x * knockbackDistance, 0f);
            enemy.ApplyKnockback(knockback); // llamamos a un método nuevo

            hasHit = true;
        }
    }
}
