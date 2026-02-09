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
    [SerializeField] private GameObject _hoverShaderMesh;

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
        StopAllCoroutines();
        StartCoroutine(FadeCVGroupOn(1, 2));

        if (_objectToScale != null)
        {
            _objectToScale.localScale += _selectedScale;
        }

        if(_hoverShaderMesh != null)
        {
            _hoverShaderMesh.SetActive(true);
        }

        if(_popUpAudio && _hoverAudio != null)
        {
            _popUpAudio.Play();
            _hoverAudio.Play();
        }
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

        if (_hoverShaderMesh != null)
        {
            _hoverShaderMesh.SetActive(false);
        }

        if (_hoverAudio != null)
        {
            _hoverAudio.Stop();
        }
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
