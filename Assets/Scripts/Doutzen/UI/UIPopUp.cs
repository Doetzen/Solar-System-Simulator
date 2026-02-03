using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    [SerializeField] private GameObject _objectToEnable;

    [SerializeField] private AudioSource _popUpAudio;
    [SerializeField] private AudioSource _hoverAudio;

    //something for hover shader
    private void OnMouseEnter()
    {
        // Enable UI gameObject
        // in enter play popup audio
        // start hoveraudio
        _objectToEnable.SetActive(true);
        //set hover shader value to on
        Debug.Log("ONMOUSEENTER");
    }

    private void OnMouseExit()
    {
        //disable UI gameobject
        //stop hoveraudio
        _objectToEnable.SetActive(false);

        // set hover shader value to off

        Debug.Log("ONMOUSEEXIT");
    }
}
