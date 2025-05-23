using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 10;
    private int currentLives;

    public Transform spawnPoint;

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        currentLives = Mathf.Max(currentLives, 0);
        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Respawn();
        }
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
