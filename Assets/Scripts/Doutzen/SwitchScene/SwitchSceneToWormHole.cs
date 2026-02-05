using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneToWormHole : MonoBehaviour
{
    [SerializeField] private AudioSource _clickAudio;
    [SerializeField] private PlanetScribtableObject _planetInfo;
    //scenetoswitchto will be the wormhole scene but its not made yet
    private void OnMouseDown()
    {

        //placeholder, will switch to wormhole scene
        if (_planetInfo != null)
        {
            SceneManager.LoadScene(_planetInfo.sceneToLoad);
        }
        //store the selected planet scene in playerprefs and get playerpref in wormhole scene to load
        PlayerPrefs.SetString("sceneToLoad", _planetInfo.sceneToLoad);
    }


    public void SwitchSceneWithButton()
    {
        SceneManager.LoadScene(1);
    }
}
