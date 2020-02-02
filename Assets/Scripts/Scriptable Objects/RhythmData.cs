using System.Collections;
using System.Collections.Generic;
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

    public float currentInterval;
    public int timeSignaturePhase;
    public SuccessTypes successType;
}
