using UnityEngine;
using UnityEngine.Splines;

public class StopMoving : MonoBehaviour
{
    private SplineAnimate _spline;

    [SerializeField] private SplineAnimate _extraSpline;

    private void Start()
    {
        _spline = GetComponent<SplineAnimate>();
    }

    private void OnMouseEnter()
    {
        if(_spline != null) 
            _spline.Pause();

        if(_extraSpline != null)
            _extraSpline.Pause();
    }
    private void OnMouseExit()
    {
        if (_spline != null)
            _spline.Play();

        if(_extraSpline != null)
            _extraSpline.Play();
    }
}
