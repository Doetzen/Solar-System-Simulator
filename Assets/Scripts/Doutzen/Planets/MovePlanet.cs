using UnityEngine;
using UnityEngine.Splines;

public class MovePlanet : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private GameObject _pitvotPoint;
    [SerializeField] private float _multiplyAmmount;

    [SerializeField] private LineRenderer _orbitRenderer;


    private void Start()
    {
        DrawLine(_planetInfo.steps, _planetInfo.radius);
    }
    private void Update()
    {
        //Rotates the planet based on given rotation
        transform.Rotate(_planetInfo.planetRotationAxis, _planetInfo.rotationSpeed * Time.deltaTime);

        //rotates around sun or earht, null ref check for the sun because she doesn't rotate around anything
        /*if (_pitvotPoint != null)
        {
            transform.RotateAround(_pitvotPoint.transform.position, Vector3.up, _planetInfo.rotateAngle * Time.deltaTime);
        }*/
    }

    //Using the line renderer to draw the orbit
    //Steps == the ammount of points between lined
    //radius == size of the orbit ring
    public void DrawLine(int steps, float radius)
    {
        _orbitRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            //Calculate where i is between 0 and 1 for the circle
            float progress = (float)i / steps;

            //radian is the full length of the circle, PI * 2 is the same
            float currentRadian = progress * 2 * Mathf.PI;


            //calcute current radian to x between -1 and 1. -1 for far left, 1 for far right, 0 for center
            float xScaled = Mathf.Cos(currentRadian);
            //calcute current radian to x between -1 and 1. -1 for far down, 1 for up, 0 for center
            float zScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float z = zScaled * radius;

            Vector3 currentPos = new Vector3(x, 0, z);

            _orbitRenderer.SetPosition(i, currentPos);
        }
    }
}
