using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
 
    public float rotationSpeed = 3f;

    float yaw;   // links/rechts
    float pitch; // omhoog/omlaag

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // rechter muisknop
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * rotationSpeed;
            pitch -= mouseY * rotationSpeed;

            // Clamp zodat je niet over de kop gaat
            pitch = Mathf.Clamp(pitch, -80f, 80f);

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }
}

  /* public float rotationSpeed = 5f; 

    void Start()
    {
        
    }


    // Als de player rechter muisknop inhoud & de muis beweegt
    //
    // Keer dan de camera(gameobject) naar de richting waar de muis naar toe beweegt
   
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            float mouseDeltaX = Input.GetAxis("Mouse X");
            
            transform.Rotate(Vector3.up, mouseDeltaX * rotationSpeed * Time.deltaTime);
        }

    }*/

