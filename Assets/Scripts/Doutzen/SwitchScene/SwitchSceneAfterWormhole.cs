using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneAfterWormhole : MonoBehaviour
{
    private float _timeBetweenScenes = 1f;
    private string _sceneToSwitchTo;

    //get playerpref for scene loading to switch to right scene
    private void Start()
    {
        _sceneToSwitchTo = PlayerPrefs.GetString("sceneToLoad");
        Debug.Log("Loading: " + _sceneToSwitchTo);

        StartCoroutine(TimeToWait());

    }
    //wait a second to see wormhole effect, after switch to right scene
    private IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(_timeBetweenScenes);
        SceneManager.LoadScene( _sceneToSwitchTo );
    }
}
