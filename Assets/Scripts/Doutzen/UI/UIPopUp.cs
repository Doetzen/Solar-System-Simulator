using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    [SerializeField] private CanvasGroup _objectToEnable;

    [SerializeField] private AudioSource _popUpAudio;
    [SerializeField] private AudioSource _hoverAudio;

    [SerializeField] private Transform _objectToScale;

    [SerializeField] private Vector3 _selectedScale;
    //variable for hover shader

    private void OnMouseEnter()
    {
        // Enable UI gameObject
        // in enter play popup audio
        // start hoveraudio
        StopAllCoroutines();
        StartCoroutine(FadeCVGroupOn(1, 2));

        if( _objectToScale != null)
        {
            _objectToScale.localScale += _selectedScale;
        }

        //set hover shader value to on
    }

    private void OnMouseExit()
    {
        //disable UI gameobject
        //stop hoveraudio
        StopAllCoroutines();
        StartCoroutine(FadeCVGroupOff(0, 2));

        if ( _objectToScale != null )
        {
            _objectToScale.localScale -= _selectedScale;
        }

        // set hover shader value to off
    }
    private IEnumerator FadeCVGroupOn(float toFadeTo, float speed)
    {
        float current = _objectToEnable.alpha;

        while (current < toFadeTo)
        {
            current += Time.deltaTime * speed;
            _objectToEnable.alpha = current;
            yield return null;
        }
    }

    private IEnumerator FadeCVGroupOff(float toFadeTo, float speed)
    {
        float current = _objectToEnable.alpha;

        while (current > toFadeTo)
        {
            current -= Time.deltaTime * speed;
            _objectToEnable.alpha = current;
            yield return null;
        }
    }
}
