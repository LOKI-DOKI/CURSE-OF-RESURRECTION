using UnityEngine;

public class ArrowShooter : MonoBehaviour  // Ensure the script is a MonoBehaviour
{
    public GameObject arrowPrefab;  // Assign this in the Unity Inspector
    public Transform shootPosition; // The position from where arrows are shot
    public float arrowSpeed = 60f;  // Speed of the arrow



    public void Shoot()
    {
        if (arrowPrefab == null || shootPosition == null)
        {
            Debug.LogError("Missing arrowPrefab or shootPosition! Assign them in the Inspector.");
            return;
        }

        // Instantiate the arrow at the shooter's position & rotation
        GameObject arrow = Instantiate(arrowPrefab, shootPosition.position, shootPosition.rotation);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Reset physics properties before applying force
            arrow.transform.rotation = shootPosition.rotation;
            arrow.transform.position = shootPosition.position;
            rb.linearVelocity = Vector3.zero;  // Reset velocity
            rb.angularVelocity = Vector3.zero;  // Reset rotation speed

            // Log the arrow's forward direction in the console
            Debug.Log("Arrow (" + arrow.name + ") Direction: " + arrow.transform.forward);

            // Apply force to shoot the arrow forward
            rb.linearVelocity = arrow.transform.forward * arrowSpeed;

            // Destroy the arrow after 10 seconds to prevent clutter
            Destroy(arrow, 10f);
        }
        else
        {
            Debug.LogError("Rigidbody not found on arrowPrefab!");
        }
    }
}