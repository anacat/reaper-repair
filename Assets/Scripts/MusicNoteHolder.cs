using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Music Note Holder")]
public class MusicNoteHolder : ScriptableObject
{
    public List<NoteFrequency> frequencyList;

    public enum Note
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }

    [Serializable]
    public class NoteFrequency
    {
        public Note note;
        public float frequency;
    }
}
