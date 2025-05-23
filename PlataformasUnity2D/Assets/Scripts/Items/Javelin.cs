using UnityEngine;

public class Javelin : MonoBehaviour
{
    public float speed = 12f;
    private Rigidbody2D rb;
    private bool isStuck = false;
    private float flightTime = 3f;
    private float timer;

    private Collider2D javelinCol;
    private Collider2D playerCol;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        javelinCol = GetComponent<Collider2D>();

        // Ignorar colisión con el jugador
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(javelinCol, playerCol, true);

        rb.velocity = transform.right * speed;
        timer = flightTime;
    }

    void Update()
    {
        if (!isStuck)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStuck) return;

        // Golpea enemigo
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.HitByJavelin();
            return; // No se clava en enemigos
        }

        // Clavarse en muros
        if (collision.CompareTag("Wall"))
        {
            isStuck = true;

            // Posición precisa
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1f, LayerMask.GetMask("Wall"));
            if (hit.collider != null)
            {
                Vector2 offset = hit.point - (Vector2)transform.right * 0.1f;
                transform.position = new Vector3(offset.x, offset.y, transform.position.z);
            }

            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
            transform.SetParent(collision.transform);

            // Activar plataforma
            javelinCol.isTrigger = false;
            gameObject.layer = LayerMask.NameToLayer("Ground");
            Physics2D.IgnoreCollision(javelinCol, playerCol, false);

            JavelinManager.RegisterClavada(gameObject);
        }
    }
}
