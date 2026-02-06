using UnityEngine;

[CreateAssetMenu(fileName = "PlanetScribtableObject", menuName = "Scriptable Objects/PlanetScribtableObject")]
public class PlanetScribtableObject : ScriptableObject
{
    //Name
    public string planetName;
    //Rotate
    public float rotationSpeed;
    public Vector3 planetRotationAxis;
    
    //Speed over spline
    public float duration;

    //Line renderer
    public int steps;
    public float radiusClose;
    public float radiusFar;

    //Scales near and far view
    public float nearViewScale;
    public float farViewScale;

    //Scene to load after wormhole scene
    public string sceneToLoad;
}
