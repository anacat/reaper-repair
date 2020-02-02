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

    private bool _isFinish;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rhythmGenerator = FindObjectOfType<RhythmGenerator>();
    }

    private void OnEnable()
    {
        _rhythmGenerator.onSuccess += OnSuccess;
        _rhythmGenerator.onFail += OnFail;

        _spriteRenderer.enabled = true;
    }

    private void Start()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y);
        _spriteRenderer.flipX = Random.Range(0, 2) == 1;
    }

    private void OnSuccess()
    {
        if (!_isFinish)
        {
            if (Sinput.GetButton(InputManager.GetInputName(myButton)))
            {
                if (!_isFinish && state < spriteList.Count - 1)
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
        else
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }

    private void OnFail()
    {
        if (!_isFinish)
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

    private void OnDisable()
    {
        _rhythmGenerator.onSuccess -= OnSuccess;
        _rhythmGenerator.onFail -= OnFail;

        _spriteRenderer.enabled = false;
    }

    public void Finish(bool isFinish)
    {
        _isFinish = isFinish;
    }
}
