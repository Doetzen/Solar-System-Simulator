using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject parentModel;

    public float rotationSpeed = 25f;
    private Vector3 mouseWorldPosStart;
    private float zoomScale = 10f;
    private float maxFOV = 80f;
    private float minFOV = 20f;
    private float defaultFOV = 60f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CamOrbit();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F))
        {
            FitToScreen();
        }

        if (Input.GetMouseButtonDown(2) && !Input.GetKey(KeyCode.LeftShift))
        {
            mouseWorldPosStart = GetPerspectivePos();
        }

        if (Input.GetMouseButton(2))
        {
            Pan();
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;

            transform.Rotate(Vector3.right, -verticalInput);
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }

    private Bounds GetBound(GameObject parentGameObj)
    {
        Bounds bound = new Bounds(parentGameObj.transform.position, Vector3.zero);
        var rList = parentGameObj.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer r in rList)
        {
            bound.Encapsulate(r.bounds);
        }
        return bound;
    }

    void FitToScreen()
    {
        Camera.main.fieldOfView = defaultFOV;
        Bounds bound = GetBound(parentModel);
        Vector3 boundSize = bound.size;
        float boundDiagonal = Mathf.Sqrt((boundSize.x * boundSize.x) + (boundSize.y * boundSize.y) + (boundSize.z * boundSize.z));
        float camDistanceToBoundCentre = boundDiagonal / 2.0f / (Mathf.Tan(Camera.main.fieldOfView / 2.0f * Mathf.Deg2Rad));
        float camDistanceToBoundWithOffset = camDistanceToBoundCentre - (Camera.main.transform.position - transform.position).magnitude;
        transform.position = bound.center + (-transform.forward * camDistanceToBoundWithOffset);
    }

    void Pan()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            Vector3 mouseWorldPosDiff = mouseWorldPosStart - GetPerspectivePos();
            transform.position += mouseWorldPosDiff;
        }
    }

    void Zoom(float zoomDiff)
    {
        if (zoomDiff != 0)
        {
            mouseWorldPosStart = GetPerspectivePos();
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - zoomDiff * zoomScale, minFOV, maxFOV);
            Vector3 mouseWorldPosDiff = mouseWorldPosStart - GetPerspectivePos();
            transform.position += mouseWorldPosDiff;
        }
    }

    public Vector3 GetPerspectivePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float dist;
        plane.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
}