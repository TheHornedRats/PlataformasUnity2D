using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public float chaseRange = 5f;
    public float stopDistance = 0.5f;
    public float moveSpeed = 2f;
    public float attackCooldown = 1.0f;
    public int contactDamage = 1;

    private Transform player;
    private Rigidbody2D rb;
    private float lastAttackTime;
    private EnemyHealth health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<EnemyHealth>();
    }

    void FixedUpdate()
    {
        if (player == null || health == null || health.IsDead()) return;

        float deltaX = player.position.x - transform.position.x;
        float horizontalDistance = Mathf.Abs(deltaX);
        float totalDistance = Vector2.Distance(transform.position, player.position);

        // Movimiento
        if (totalDistance <= chaseRange && horizontalDistance > stopDistance)
        {
            float direction = Mathf.Sign(deltaX);
            float moveStep = moveSpeed * Time.fixedDeltaTime;

            if (horizontalDistance - moveStep < stopDistance)
                moveStep = horizontalDistance - stopDistance;

            Vector2 move = new Vector2(direction * moveStep, 0f);
            rb.MovePosition(rb.position + move);
        }

        // Ataque en rango
        if (horizontalDistance <= stopDistance)
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage);
                lastAttackTime = Time.time;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Javelin"))
        {
            health.HitByJavelin();
        }
    }
}
