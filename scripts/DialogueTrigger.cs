using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSystem dialogueSystem; // Reference to the dialogue system
    private bool playerInRange = false;

    public DialogueSystem.DialogueLine[] dialogue; // Dialogue lines

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // Press 'E' to start
        {
            dialogueSystem.StartDialogue(dialogue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
