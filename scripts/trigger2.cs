using DialogueEditor;
using UnityEngine;

public class trigger2 : MonoBehaviour
{
    [SerializeField] private NPCConversation myconversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

                ConversationManager.Instance.StartConversation(myconversation);
            }
        }
    }
}
