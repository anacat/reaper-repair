using UnityEngine;

[CreateAssetMenu(menuName = "Data/RhythmData Game Data")]
public class RhythmData : ScriptableObject
{
    public enum SuccessTypes
    {
        Good,
        Great,
        Perfect
    }

    public enum Level
    {
        Dark,
        Grass,
        Flower,
        Tree,
        Bird
    }

    [Space(10)]
    public float currentInterval;
    public int timeSignaturePhase;
    public SuccessTypes successType;

    [Header("Level")]
    public Level level;

    public bool buttonPress;
}
