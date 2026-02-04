using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private float _multiplyAmmount;

    void Update()
    {
        transform.Rotate(_planetInfo.planetRotationAxis, _planetInfo.rotationSpeed * Time.deltaTime);
    }
}
