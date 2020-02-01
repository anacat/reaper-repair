using UnityEngine;

public class InputManager
{
    public enum InputButton
    {
        A,
        B,
        X,
        Y,
        DPadLeft,
        DPadRight,
        DPadUp,
        DPadDown
    }

    public static bool IsValidKey()
    {
        return Input.GetMouseButtonDown(0) || Sinput.GetButtonDown(GetInputName(InputButton.A)) ||
               Sinput.GetButtonDown(GetInputName(InputButton.B)) || Sinput.GetButtonDown(GetInputName(InputButton.X)) ||
               Sinput.GetButtonDown(GetInputName(InputButton.Y)) || Sinput.GetButtonDown(GetInputName(InputButton.DPadLeft)) ||
               Sinput.GetButtonDown(GetInputName(InputButton.DPadRight)) || Sinput.GetButtonDown(GetInputName(InputButton.DPadDown)) ||
               Sinput.GetButtonDown(GetInputName(InputButton.DPadUp));
    }

    public static string GetInputName(InputButton btn)
    {
        switch (btn)
        {
            case InputButton.A:
                return "A";
            case InputButton.B:
                return "B";
            case InputButton.X:
                return "X";
            case InputButton.Y:
                return "Y";
            case InputButton.DPadDown:
                return "DPadDown";
            case InputButton.DPadLeft:
                return "DPadLeft";
            case InputButton.DPadRight:
                return "DPadRight";
            case InputButton.DPadUp:
                return "DPadUp";
        }

        return string.Empty;
    }
}

