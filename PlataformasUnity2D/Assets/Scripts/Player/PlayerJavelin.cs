using UnityEngine;

public class PlayerJavelin : MonoBehaviour
{
    public GameObject javelinPrefab;
    public Transform throwPoint;
    public float throwCooldown = 1f;

    private float lastThrowTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastThrowTime >= throwCooldown)
        {
            Instantiate(javelinPrefab, throwPoint.position, throwPoint.rotation);
            lastThrowTime = Time.time;
        }
    }
}
