using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 10;
    private int currentLives;

    public Transform spawnPoint;
    public SpriteRenderer spriteRenderer;
    public Color damageColor = Color.red;
    public float flashDuration = 0.2f;
    public AudioClip hitSound;
    public AudioSource audioSource;

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        currentLives = Mathf.Max(currentLives, 0);
        Debug.Log("Vidas restantes: " + currentLives);

        // Reproducir sonido
        if (audioSource != null && hitSound != null)
            audioSource.PlayOneShot(hitSound);

        // Flash rojo
        if (spriteRenderer != null)
            StartCoroutine(DamageFlash());

        if (currentLives <= 0)
        {
            Respawn();
        }
    }

    private IEnumerator DamageFlash()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = Color.white;
    }

    private void Respawn()
    {
        Debug.Log("Jugador ha muerto. Reapareciendo...");
        transform.position = spawnPoint.position;
        currentLives = maxLives;
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
}
