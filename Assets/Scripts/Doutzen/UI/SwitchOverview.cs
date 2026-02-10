using UnityEngine;

public class SwitchOverview : MonoBehaviour
{
    private bool _standartViewOn;
    private bool _isSwitching;

    [SerializeField] private float _speed = 5;

    [SerializeField] private GameObject[] _planets;
    [SerializeField] private GameObject _camHolder;

    [SerializeField] private Transform _nearCamPos;
    [SerializeField] private Transform _farCamPos;

    private void Start()
    {
        _standartViewOn = true;  
    }
    private void Update()
    {
        if (_standartViewOn && _isSwitching)
        {
            MoveCam(_nearCamPos, _speed);
            Debug.Log("Move NEAR?");

        }
        else if (!_standartViewOn && _isSwitching) 
        {
            MoveCam(_farCamPos, _speed);
            Debug.Log("Move FAR?");
        }
    }

    //The UI button to handle the switch
    //we only want to switch the view instantly when going far away. 
    public void SwitchViewButton()
    {
        _isSwitching = true;

        if (_standartViewOn)
        {
            _standartViewOn = false;
            SwitchView();
        }
        else
        {
            _standartViewOn = true;
            return;
        }
    }
    //tells the planets to switch
    private void SwitchView()
    {
        foreach (GameObject planet in _planets)
        {
            planet.GetComponent<MovePlanet>().Switch(_standartViewOn);
        }
    }
    //Move the camera to the desired position. After the camera gets there, stop the function.
    private void MoveCam(Transform newPos, float speed)
    {
        _camHolder.transform.position = Vector3.MoveTowards(_camHolder.transform.position, newPos.position, speed);
        if(_camHolder.transform.position == newPos.position)
        {
            _isSwitching = false;

            if (_standartViewOn)
            {
                SwitchView();
            }
        }
    } 
}
