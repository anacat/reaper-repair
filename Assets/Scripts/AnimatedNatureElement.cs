using System.Collections.Generic;
using UnityEngine;

public class AnimatedNatureElement : MonoBehaviour
{
    public InputManager.InputButton myButton;
    public List<Sprite> spriteList;
    public int state;

    private SpriteRenderer _spriteRenderer;
    private RhythmGenerator _rhythmGenerator;
    private const int MAX_FAIL_TIMES = 4;

    private int _failCounter = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rhythmGenerator = FindObjectOfType<RhythmGenerator>();
    }

    private void OnEnable()
    {
        _rhythmGenerator.onSuccess += OnSuccess;
        _rhythmGenerator.onFail += OnFail;
    }

    private void OnDisable()
    {
        _rhythmGenerator.onSuccess -= OnSuccess;
        _rhythmGenerator.onFail -= OnFail;
    }

    private void Update()
    {

    }

    private void OnSuccess()
    {
        if (Sinput.GetButton(InputManager.GetInputName(myButton)))
        {
            if (state < spriteList.Count - 1)
            {
                state++;
                
                _spriteRenderer.sprite = spriteList[state];
            }
        }
        else
        {
            OnFail();
        }
    }

    private void OnFail()
    {
        _failCounter++;
        if (_failCounter > MAX_FAIL_TIMES)
        {
            if (state > 0)
            {
                state--;
                _failCounter = 0;

                _spriteRenderer.sprite = spriteList[state];
            }
        }
    }
}
