using UnityEngine;
using DialogueEditor;  // Make sure this is the correct namespace for your Dialogue Editor asset

public class NPCDialogueTrigger : MonoBehaviour
{
    public NPCConversation demonTreeConversation;
    public NPCConversation deathGodConversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "DemonTree")
            {
                ConversationManager.Instance.StartConversation(demonTreeConversation);
            }
            else if (gameObject.name == "DeathGod")
            {
                ConversationManager.Instance.StartConversation(deathGodConversation);
            }
        }
    }
}
