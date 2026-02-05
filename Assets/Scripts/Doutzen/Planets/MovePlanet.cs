using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private GameObject _pitvotPoint;
    [SerializeField] private float _multiplyAmmount;

    [SerializeField] private LineRenderer _orbitRenderer;

    private void Update()
    {
        //Rotates the planet based on given rotation
        transform.Rotate(_planetInfo.planetRotationAxis, _planetInfo.rotationSpeed * Time.deltaTime);

        //rotates around sun or earht, null ref check for the sun because she doesn't rotate around anything
        if (_pitvotPoint != null)
        {
            transform.RotateAround(_pitvotPoint.transform.position, Vector3.up, _planetInfo.rotateAngle * Time.deltaTime);
        }
    }

    //Using the line renderer to draw the orbit
    public void DrawLine(int steps, float radius)
    {
        _orbitRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            float progress = (float)i / steps;


        }
    }

}
