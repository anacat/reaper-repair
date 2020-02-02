using System.Collections.Generic;
using UnityEngine;

public class AnimatedNatureElement : MonoBehaviour
{
    public InputManager.InputButton myButton;
    public List<Sprite> spriteList;
    public int state;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //success
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state < spriteList.Count)
            {
                state++;
            }
            else
            {
                state--;
            }

            _spriteRenderer.sprite = spriteList[state - 1];
        }
    }
}
