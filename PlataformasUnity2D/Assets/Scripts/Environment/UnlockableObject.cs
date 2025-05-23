using UnityEngine;

public class UnlockableObject : MonoBehaviour
{
    private bool unlocked = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (unlocked) return;

        if (collision.collider.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.collider.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.hasKey)
            {
                unlocked = true;
                Destroy(gameObject);
            }
        }
    }
}
