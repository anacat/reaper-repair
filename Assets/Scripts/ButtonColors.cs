using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Button Colors")]
public class ButtonColors : ScriptableObject
{
    public List<BtnColor> buttonColorsList;

    [Serializable]
    public class BtnColor
    {
        public InputManager.InputButton button;
        public Color color;
    }
}
