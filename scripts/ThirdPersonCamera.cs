using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Assign your character
    public float minDistance = 0.5f; // First-person mode at closest zoom
    public float maxDistance = 5.0f; // Maximum zoom distance
    public float height = 1.5f; // Camera height
    public float rotationSpeed = 2.0f; // Speed of mouse rotation
    public float zoomSpeed = 2.0f; // Speed of zooming
    public float zoomSmoothTime = 0.2f; // Smooth transition time for zoom
    public LayerMask obstacleMask; // Mask for objects that block the camera

    private float currentDistance; // The current zoom level
    private float targetDistance; // Target zoom level (for smooth transition)
    private float yaw = 0.0f; // Horizontal rotation
    private float pitch = 0.0f; // Vertical rotation
    private float zoomVelocity; // Used for smooth zooming

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
        currentDistance = maxDistance; // Start at max zoom distance
        targetDistance = maxDistance;
    }

    void LateUpdate()
    {
        if (!target) return;

        // Mouse input for rotation
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // Limit vertical rotation

        // Smooth zoom with scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            targetDistance -= scrollInput * zoomSpeed;
            targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        }

        // Apply smooth zooming
        currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref zoomVelocity, zoomSmoothTime);

        // Calculate desired camera position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * currentDistance) + Vector3.up * height;

        // Check for obstacles (Prevents camera clipping through walls)
        RaycastHit hit;
        if (Physics.Raycast(target.position + Vector3.up * height, desiredPosition - target.position, out hit, currentDistance, obstacleMask))
        {
            transform.position = hit.point; // Move the camera closer
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        }

        // Look at the player
        transform.LookAt(target.position + Vector3.up * 1f);

        // First-Person Mode: Hide Player Model When Fully Zoomed In
        if (currentDistance <= minDistance + 0.1f)
        {
            HidePlayerModel(true); // Hide player for first-person mode
        }
        else
        {
            HidePlayerModel(false); // Show player in third-person mode
        }
    }

    void HidePlayerModel(bool hide)
    {
        SkinnedMeshRenderer[] meshes = target.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            mesh.enabled = !hide;
        }
    }
}
