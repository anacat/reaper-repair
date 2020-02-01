using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public MusicNoteHolder noteThing;
    public GameObject proceduralAudioPrefab;

    private List<GameObject> _noteList = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.C).frequency, KeyCode.Q);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.D).frequency, KeyCode.W);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.E).frequency, KeyCode.E);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.F).frequency, KeyCode.R);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.G).frequency, KeyCode.T);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.A).frequency, KeyCode.Y);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.B).frequency, KeyCode.U);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            CreateNoteSound(523.25f, KeyCode.I);
        }

        FindObjectOfType<NoiseBgController>().state = FindObjectsOfType<ProceduralAudio>().Length > 0 ? 0 : 1;
    }

    private void CreateNoteSound(float frequency, KeyCode key)
    {
        GameObject note = Instantiate(proceduralAudioPrefab, transform);

        note.GetComponent<ProceduralAudio>().SetNote(frequency, key);
    }
}
