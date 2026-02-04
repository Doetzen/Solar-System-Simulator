using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private GameObject _pitvotPoint;
    [SerializeField] private float _multiplyAmmount;

    private void Update()
    {
        transform.Rotate(_planetInfo.planetRotationAxis, _planetInfo.rotationSpeed * Time.deltaTime);

        if (_pitvotPoint != null)
        {
            transform.RotateAround(_pitvotPoint.transform.position, Vector3.up, _planetInfo.rotateAngle * Time.deltaTime);
        }
    }
}
