using UnityEngine;

[CreateAssetMenu(fileName = "PlanetScribtableObject", menuName = "Scriptable Objects/PlanetScribtableObject")]
public class PlanetScribtableObject : ScriptableObject
{
    public string planetName;
    public float rotationSpeed;
    public float moveSpeed;

    public Vector3 planetOffset;
    public Vector3 planetRotationAxis;

    public string sceneToLoad;
}
