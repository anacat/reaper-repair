using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePadButtonUI : MonoBehaviour
{
    public ButtonColors btnColors;

    [Header("Buttons")]
    public Image dpadLeft;
    public Image dpadUp;
    public Image dpadRight;
    public Image dpadDown;
    public Image x;
    public Image y;
    public Image b;
    public Image a;

    private Coroutine _dpadleftCoroutine;
    private Coroutine _dpadrightCoroutine;
    private Coroutine _dpadupCoroutine;
    private Coroutine _dpaddownCoroutine;
    private Coroutine _aCoroutine;
    private Coroutine _bCoroutine;
    private Coroutine _xCoroutine;
    private Coroutine _yCoroutine;

    private void Update()
    {
        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadLeft)))
        {
            CoroutineThing(InputManager.InputButton.DPadLeft, ref _dpadleftCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadRight)))
        {
            CoroutineThing(InputManager.InputButton.DPadRight, ref _dpadrightCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadDown)))
        {
            CoroutineThing(InputManager.InputButton.DPadDown, ref _dpaddownCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.DPadUp)))
        {
            CoroutineThing(InputManager.InputButton.DPadUp, ref _dpadupCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.A)))
        {
            CoroutineThing(InputManager.InputButton.A, ref _aCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.B)))
        {
            CoroutineThing(InputManager.InputButton.B, ref _bCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.X)))
        {
            CoroutineThing(InputManager.InputButton.X, ref _xCoroutine);
        }

        if (Sinput.GetButtonDown(InputManager.GetInputName(InputManager.InputButton.Y)))
        {
            CoroutineThing(InputManager.InputButton.Y, ref _yCoroutine);
        }
    }

    private void CoroutineThing(InputManager.InputButton button, ref Coroutine coroutineVar)
    {
        if (coroutineVar != null)
        {
            StopCoroutine(coroutineVar);
        }

        coroutineVar = StartCoroutine(ButtonHighlight(button));
    }

    private IEnumerator ButtonHighlight(InputManager.InputButton btn)
    {
        Image btnImage = GetBtnImage(btn);

        btnImage.color = btnColors.buttonColorsList.Find(bt => bt.button == btn).color;

        yield return new WaitWhile(() => Sinput.GetButton(InputManager.GetInputName(btn)));

        while (Vector4.Distance(btnImage.color, Color.white) > 0.05f)
        {
            btnImage.color = Color.Lerp(btnImage.color, Color.white, Time.deltaTime * 2f);

            yield return null;
        }
    }

    private Image GetBtnImage(InputManager.InputButton btn)
    {
        switch (btn)
        {
            case InputManager.InputButton.A:
                return a;
            case InputManager.InputButton.B:
                return b;
            case InputManager.InputButton.X:
                return x;
            case InputManager.InputButton.Y:
                return y;
            case InputManager.InputButton.DPadDown:
                return dpadDown;
            case InputManager.InputButton.DPadLeft:
                return dpadLeft;
            case InputManager.InputButton.DPadRight:
                return dpadRight;
            case InputManager.InputButton.DPadUp:
                return dpadUp;
        }

        return null;
    }
}
