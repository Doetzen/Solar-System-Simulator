using UnityEngine;
using UnityEngine.Splines;

public class MovePlanet : MonoBehaviour
{
    [SerializeField] private PlanetScribtableObject _planetInfo;
    [SerializeField] private float _multiplyAmmount;

    [SerializeField] private LineRenderer _orbitRenderer;

    [SerializeField] private SplineContainer _splineNear;
    [SerializeField] private SplineContainer _splineFar;
    private SplineAnimate _planetSpline;

    private void Start()
    {
        _planetSpline = GetComponent<SplineAnimate>();
        _planetSpline.Duration = _planetInfo.duration;
        //DrawLine(_planetInfo.steps, _planetInfo.radiusClose);
        Switch(true);
    }
    private void Update()
    {
        //Rotates the planet based on given rotation
        transform.Rotate(_planetInfo.planetRotationAxis, _planetInfo.rotationSpeed * Time.deltaTime);
    }

    public void Switch(bool near)
    {
        if (near)
        {
            if(_planetSpline != null)
            {
                _planetSpline.Container = _splineNear;
            }
            transform.localScale = new Vector3(_planetInfo.nearViewScale, _planetInfo.nearViewScale, _planetInfo.nearViewScale);
            DrawLine(_planetInfo.steps, _planetInfo.radiusClose);
        }
        else
        {
            if(_planetSpline != null)
            {
                _planetSpline.Container = _splineFar;
            }
            transform.localScale = new Vector3(_planetInfo.farViewScale, _planetInfo.farViewScale, _planetInfo.farViewScale);
            DrawLine(_planetInfo.steps, _planetInfo.radiusFar);
        }
    }


    //Using the line renderer to draw the orbit
    //Steps == the ammount of points between lined
    //radius == size of the orbit ring
    public void DrawLine(int steps, float radius)
    {
        //reset positionCount for new line in far away and close view
        _orbitRenderer.positionCount = 0;


        _orbitRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            //Calculate where i is between 0 and <1 for the circle (almost 1)
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
