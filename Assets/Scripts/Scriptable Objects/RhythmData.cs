using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/RhythmData Game Data")]
public class RhythmData : ScriptableObject
{
    public List<AnimatedNatureElement> elements;

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

    public float currentInterval;
    public int timeSignaturePhase;
    public SuccessTypes successType;

    [Header("Level")]
    public Level level;

    public bool buttonPress;
}
