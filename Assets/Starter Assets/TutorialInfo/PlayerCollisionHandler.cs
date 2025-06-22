using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "DemonGod"
        if (other.CompareTag("DemonGod"))
        {
            Debug.Log("Player collided with Demon God! Destroying Player...");
            Destroy(gameObject); // Destroys the player
        }
    }
}
