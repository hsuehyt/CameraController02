using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 3.0f;
    public float panSpeed = 0.1f;
    public float zoomSpeed = 0.5f;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;
    public Transform cameraAim;

    void Start()
    {
        // Save the default position and rotation
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;

        if (cameraAim == null)
        {
            Debug.LogError("Camera Aim object is not set. Please set the cameraAim GameObject in the inspector.");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            // Rotate the camera around the cameraAim
            if (Input.GetMouseButton(0) && cameraAim != null)
            {
                float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
                float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

                // Rotate around the cameraAim's position
                transform.RotateAround(cameraAim.position, Vector3.up, -rotationX);
                transform.RotateAround(cameraAim.position, transform.right, rotationY);
            }

            // Pan the camera
            if (Input.GetMouseButton(2))
            {
                float panX = -Input.GetAxis("Mouse X") * panSpeed;
                float panY = -Input.GetAxis("Mouse Y") * panSpeed;
                transform.Translate(new Vector3(panX, panY, 0), Space.Self);
            }

            // Zoom the camera
            if (Input.GetMouseButton(1))
            {
                float zoom = Input.GetAxis("Mouse Y") * zoomSpeed;
                transform.Translate(0, 0, zoom, Space.Self);
            }
        }

        // Reset the camera to default position and rotation
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = defaultPosition;
            transform.rotation = defaultRotation;
        }
    }
}
