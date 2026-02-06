using System.Collections;
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
        OnHover();
    }
    private void OnMouseExit()
    {
        StopHover();
    }

    //do things when mouse is hovering on this GameObject
    //like scale, show hover shader and show UI
    public void OnHover()
    {
        // in enter play popup audio
        // start hoveraudio
        StopAllCoroutines();
        StartCoroutine(FadeCVGroupOn(1, 2));

        if (_objectToScale != null)
        {
            _objectToScale.localScale += _selectedScale;
        }

        //set hover shader value to on
    }

    //stop the hovershader, ui and back to normal scale
    public void StopHover()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCVGroupOff(0, 2));

        if (_objectToScale != null)
        {
            _objectToScale.localScale -= _selectedScale;
        }
        //stop hoveraudio

        // set hover shader value to off
    }

    //fade UI in when hovering
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
    //fade UI out when hovering is canceled
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
