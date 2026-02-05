using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    //Script for UI in planet overview.
    //This is because you can rotate and move around the celectials which makes looking at UI difficult if you're not perfectly in front of it.

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
