using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public float minFOV = 20f; 
    public float maxFOV = 60f; 
    public float zoomSpeed = 5;
    public float zoomSmoothness = 5;

    private float currentFOV = 100f;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        currentFOV -= scroll * zoomSpeed * Time.deltaTime; 
        currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);

        float newFOV = currentFOV;
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, newFOV, zoomSmoothness * Time.deltaTime);

    }
}
