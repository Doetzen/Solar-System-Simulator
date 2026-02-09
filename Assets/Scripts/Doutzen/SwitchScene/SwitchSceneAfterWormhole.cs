using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneAfterWormhole : MonoBehaviour
{
    private float _timeBetweenScenes = 1f;
    private string _sceneToSwitchTo;

    private void Start()
    {
        _sceneToSwitchTo = PlayerPrefs.GetString("sceneToLoad");
        Debug.Log("Loading: " + _sceneToSwitchTo);

        StartCoroutine(TimeToWait());

    }

    private IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(_timeBetweenScenes);
        SceneManager.LoadScene( _sceneToSwitchTo );
    }
}
