using UnityEngine;
using TMPro;

public class NPCInteract : MonoBehaviour
{
    public GameObject promptUI;
    public GameObject dialogueBubble;
    public string message = "¡Hola aventurero!";
    private bool playerInRange = false;

    void Start()
    {
        promptUI.SetActive(false);
        dialogueBubble.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueBubble.SetActive(true);
            dialogueBubble.GetComponentInChildren<TextMeshProUGUI>().text = message;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(true);
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(false);
            dialogueBubble.SetActive(false);
            playerInRange = false;
        }
    }
}
