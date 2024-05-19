using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public Vector3 targetLocation;
    public Vector3 portalLocation;
    public LevelType levelType;
    public string levelText;
    public int launchAngle;
    public int launchSpeed;
    public string solution;
}

public enum LevelType
{
    Abschusswinkel,
    Abschussgeschwindigkeit,
    TargetVerschieben,
    Abschusshoehe
}