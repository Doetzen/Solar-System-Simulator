using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        Invoke("Enable", 0.1f);
    }

    private void Enable()
    {
        _button.interactable = true;
    }


}
