using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public MusicNoteHolder noteThing;
    public GameObject proceduralAudioPrefab;

    private List<GameObject> _noteList = new List<GameObject>();

    private void Update()
    {
        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadLeft)))
        {
            CreateNoteSound(noteThing.frequencyList[0].frequency, InputManager.GetInputName(InputManager.InputButton.DPadLeft));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadUp)))
        {
            CreateNoteSound(noteThing.frequencyList[1].frequency, InputManager.GetInputName(InputManager.InputButton.DPadUp));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadRight)))
        {
            CreateNoteSound(noteThing.frequencyList[2].frequency, InputManager.GetInputName(InputManager.InputButton.DPadRight));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadDown)))
        {
            CreateNoteSound(noteThing.frequencyList[3].frequency, InputManager.GetInputName(InputManager.InputButton.DPadDown));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.X)))
        {
            CreateNoteSound(noteThing.frequencyList[4].frequency, InputManager.GetInputName(InputManager.InputButton.X));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.Y)))
        {
            CreateNoteSound(noteThing.frequencyList[5].frequency, InputManager.GetInputName(InputManager.InputButton.Y));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.B)))
        {
            CreateNoteSound(noteThing.frequencyList[6].frequency, InputManager.GetInputName(InputManager.InputButton.B));
        }
        else if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.A)))
        {
            CreateNoteSound(noteThing.frequencyList[7].frequency, InputManager.GetInputName(InputManager.InputButton.A));
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
