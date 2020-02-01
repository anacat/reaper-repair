using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public MusicNoteHolder noteThing;
    public GameObject proceduralAudioPrefab;

    private List<GameObject> _noteList = new List<GameObject>();

    private void Update()
    {
        if (Sinput.GetButtonDown("DPadLeft"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.C).frequency, "DPadLeft");
        }
        else if (Sinput.GetButtonDown("DPadUp"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.D).frequency, "DPadUp");
        }
        else if (Sinput.GetButtonDown("DPadRight"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.E).frequency, "DPadRight");
        }
        else if (Sinput.GetButtonDown("DPadDown"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.F).frequency, "DPadDown");
        }
        else if (Sinput.GetButtonDown("X"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.G).frequency, "X");
        }
        else if (Sinput.GetButtonDown("Y"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.A).frequency, "Y");
        }
        else if (Sinput.GetButtonDown("B"))
        {
            CreateNoteSound(noteThing.frequencyList.Find(n => n.note == MusicNoteHolder.Note.B).frequency, "B");
        }
        else if (Sinput.GetButtonDown("A"))
        {
            CreateNoteSound(523.25f, "A");
        }

        //no grips 4 u =(
        //FindObjectOfType<NoiseBgController>().state = FindObjectsOfType<ProceduralAudio>().Length > 0 ? 0 : 1;
    }

    private void CreateNoteSound(float frequency, string button)
    {
        GameObject note = Instantiate(proceduralAudioPrefab, transform);

        note.GetComponent<ProceduralAudio>().SetNote(frequency, button);
    }
}
