using Unity.VisualScripting;
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
    public void SwitchView()
    {
        _isSwitching = true;

        if (_standartViewOn)
        {
            _standartViewOn = false;

           // _camHolder.transform.rotation = _farCamPos.rotation;
        }
        else
        {
            _standartViewOn = true;

            //_camHolder.transform.rotation = _nearCamPos.rotation;

        }

        foreach (GameObject planet in _planets)
        {
            planet.GetComponent<MovePlanet>().Switch(_standartViewOn);
        }
    }

    private void MoveCam(Transform newPos, float speed)
    {
        //Vector3 targetPos = new Vector3(newPos.position.x, newPos.position.y, newPos.position.z);
        //_camHolder.transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;
        _camHolder.transform.position = Vector3.MoveTowards(_camHolder.transform.position, newPos.position, speed);
        if(_camHolder.transform.position == newPos.position)
        {
            _isSwitching = false;
        }
    } 
}
