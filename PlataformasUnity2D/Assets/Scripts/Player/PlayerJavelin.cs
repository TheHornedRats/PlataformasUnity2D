using UnityEngine;

public class PlayerJavelin : MonoBehaviour
{
    public GameObject javelinPrefab;
    public Transform throwPoint;
    public float javelinSpeed = 10f;
    public float cooldown = 1f;

    private float lastThrowTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Time.time - lastThrowTime >= cooldown)
        {
            ThrowJavelin();
            lastThrowTime = Time.time;
        }
    }

    void ThrowJavelin()
    {
        float direction = Mathf.Sign(transform.localScale.x);

        GameObject javelin = Instantiate(javelinPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = javelin.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(javelinSpeed * direction, 0f);
        javelin.transform.right = new Vector2(direction, 0f); 
    }
}
