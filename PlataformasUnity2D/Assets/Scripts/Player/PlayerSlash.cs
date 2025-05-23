using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    public GameObject slashPrefab;
    public Transform slashPoint;
    public float cooldown = 0.5f;

    private float lastAttackTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastAttackTime >= cooldown)
        {
            Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation);
            lastAttackTime = Time.time;
        }
    }
}
