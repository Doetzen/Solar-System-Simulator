using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public void SceneSwitch(int sceneLoad)
    {
        SceneManager.LoadScene(sceneLoad);
    }

}
    
