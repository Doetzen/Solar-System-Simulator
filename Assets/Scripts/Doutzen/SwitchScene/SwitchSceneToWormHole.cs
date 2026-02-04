using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneToWormHole : MonoBehaviour
{
    [SerializeField] private AudioSource _clickAudio;
    [SerializeField] private PlanetScribtableObject _planetInfo;
    //scenetoswitchto will be the wormhole scene but its not made yet
    private void OnMouseDown()
    {
        SceneManager.LoadScene(_planetInfo.sceneToLoad);
        PlayerPrefs.SetString("sceneToLoad", _planetInfo.sceneToLoad);
    }
}
