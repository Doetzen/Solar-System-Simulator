using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneToWormhole : MonoBehaviour
{
    [SerializeField] private AudioSource _clickAudio;
    [SerializeField] private PlanetScribtableObject _planetInfo;
    //scenetoswitchto will be the wormhole scene but its not made yet
    private void OnMouseDown()
    {
        //store the selected planet scene in playerprefs and get playerpref in wormhole scene to load
        PlayerPrefs.SetString("sceneToLoad", _planetInfo.sceneToLoad);

        SceneManager.LoadScene("Wormhole");
    }


    public void SwitchSceneWithButton()
    {
        PlayerPrefs.SetString("sceneToLoad", "MainScene");
        SceneManager.LoadScene("Wormhole");
    }
}
