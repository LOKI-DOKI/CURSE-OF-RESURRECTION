using UnityEngine;
using DialogueEditor;

public class DemonGodTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation myconversation;
    public AudioSource audio;
    public AudioClip HA;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audio.Stop();
            audio.PlayOneShot(HA);

            if (Input.GetKeyDown(KeyCode.G))
            {

                ConversationManager.Instance.StartConversation(myconversation);
            }
        }
      
    }

}