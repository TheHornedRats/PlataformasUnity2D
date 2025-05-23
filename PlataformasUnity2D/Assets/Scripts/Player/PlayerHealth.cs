using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 10;
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        currentLives = Mathf.Max(currentLives, 0); // evita negativos
        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        Destroy(this.gameObject);

        // Aquí puedes desactivar controles, mostrar menú, etc.
        // Por ejemplo:
        // gameObject.SetActive(false);
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
}
