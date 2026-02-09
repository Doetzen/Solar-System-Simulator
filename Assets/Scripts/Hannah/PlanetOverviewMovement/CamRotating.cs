using UnityEngine;

public class CamRotating : MonoBehaviour
{

    public float rotationSpeed = 15;

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseDeltaX = Input.GetAxis("Mouse X");

            transform.Rotate(Vector3.up, mouseDeltaX * rotationSpeed * Time.deltaTime);

            float mouseDeltaY = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up, mouseDeltaX * rotationSpeed * Time.deltaTime);
        }
    }
}
