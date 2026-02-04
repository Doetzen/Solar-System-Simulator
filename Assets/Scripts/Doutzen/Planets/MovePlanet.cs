using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private GameObject _pitvotPoint;
    [SerializeField] private float _multiplyAmmount;

    private void Update()
    {
        if (_pitvotPoint != null)
        {
            transform.RotateAround(_pitvotPoint.transform.position, _planetInfo.planetOffset, _planetInfo.moveSpeed * Time.deltaTime);
        }
    }
}
