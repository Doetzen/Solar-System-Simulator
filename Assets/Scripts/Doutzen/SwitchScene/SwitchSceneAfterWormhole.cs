using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneAfterWormhole : MonoBehaviour
{
    private string _sceneToSwitchTo;

    private void Start()
    {
        _sceneToSwitchTo = PlayerPrefs.GetString("sceneToLoad");
        Debug.Log("Loading: " + _sceneToSwitchTo);

        StartCoroutine(TimeToWait());

    }

    private IEnumerator TimeToWait()
    {
        yield return new WaitForSeconds(1);

        AsyncOperation sceneOperation = SceneManager.LoadSceneAsync(_sceneToSwitchTo);

        while(!sceneOperation.isDone)
        {
            //for if we want a loading slider
            //float progress = Mathf.Clamp01(sceneOperation.progress / 0.9f);
            yield return null;
        }
    }
}
