using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public void ApplyKnockback(Vector2 force)
    {
        if (dead) return;

        transform.position += (Vector3)force;
    }

    private bool recentlyHitByJavelin = false;
    private bool dead = false;

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        if (dead) return;

        currentLives -= amount;
        Debug.Log("Vida enemiga: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    public void HitByJavelin()
    {
        if (recentlyHitByJavelin || dead) return;

        TakeDamage(1);
        recentlyHitByJavelin = true;
    }

    public bool IsDead()
    {
        return dead;
    }

    private void Die()
    {
        dead = true;
        // Aquí puedes añadir animación, partículas, sonido
        Destroy(gameObject);
    }
}
