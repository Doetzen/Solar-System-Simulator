using UnityEngine;
using UnityEngine.Splines;

public class SwitchOverview : MonoBehaviour
{
    private bool _standartViewOn;

    [SerializeField] private GameObject[] _planets;
    [SerializeField] private GameObject _camHolder;

    [SerializeField] private Transform _nearCamPos;
    [SerializeField] private Transform _farCamPos;

    private void Start()
    {
        _standartViewOn = true;  
    }

    public void SwitchView()
    {
        if (_standartViewOn)
        {
            _standartViewOn = false;
            _camHolder.transform.position = _farCamPos.position;
        }
        else
        {
            _standartViewOn = true;
            _camHolder.transform.position = _nearCamPos.position;
        }

        foreach (GameObject planet in _planets)
        {
            planet.GetComponent<MovePlanet>().Switch(_standartViewOn);
        }
    }
}
