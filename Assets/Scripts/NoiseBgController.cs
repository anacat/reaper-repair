using UnityEngine;
using UnityEngine.UI;

public class NoiseBgController : MonoBehaviour
{
    public float state = 1f;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<RawImage>().material;
    }

    private void Update()
    {
        _material.SetFloat("_State", state);
    }
}
