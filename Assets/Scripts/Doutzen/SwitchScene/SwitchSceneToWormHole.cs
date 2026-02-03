using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneToWormHole : MonoBehaviour
{
    [SerializeField] private AudioSource _clickAudio;

    //planetInfo for scenetoswitchto
    //scenetoswitchto will be the wormhole scene but its not made yet
    [SerializeField] private string _sceneToSwitchTo;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetString("sceneToLoad", _sceneToSwitchTo);
    }
}
