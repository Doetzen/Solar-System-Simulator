using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GameObject.FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
