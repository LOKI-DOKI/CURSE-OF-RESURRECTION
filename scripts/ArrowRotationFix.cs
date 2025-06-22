using UnityEngine;

public class ArrowRotationFix : MonoBehaviour
{
    private Rigidbody rb;

    // This method allows external scripts to set the initial rotation of the arrow
    public void InitializeRotation(Vector3 shootDirection)
    {
        transform.rotation = Quaternion.LookRotation(shootDirection);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb != null && rb.linearVelocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
        }
    }
}
