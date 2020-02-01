using UnityEngine;

public class RhythmGenerator : MonoBehaviour
{
    private int _timeSignaturePhase;
    private float _initialInputTime;
    private float _currentIntervalTime;
    private float _lastInputTime;
    private const int FRACTION_INTERVAL = 5;

    public GameObject TextureFeedback;

    public GameObject Phase_1;
    public GameObject Phase_2;
    public GameObject Phase_3;
    public GameObject Lose;

    void Start()
    {

    }

    void Update()
    {
        DisableObjects();

        switch (_timeSignaturePhase)
        {
            case 0:
                if (InputManager.IsValidKey())
                {
                    Phase_1.SetActive(true);
                    _initialInputTime = Time.time;
                    _lastInputTime = _initialInputTime;
                    _timeSignaturePhase++;
                }
                break;
            case 1:
                if (InputManager.IsValidKey())
                {
                    Phase_2.SetActive(true);
                    _currentIntervalTime = GetCurrentInterval(_initialInputTime);
                    _lastInputTime = Time.time;
                    _timeSignaturePhase++;
                }
                break;
            case 2:
                RhythmEnforcer();
                if (InputManager.IsValidKey())
                {
                    float currentInput = Time.time;
                    if (IsOnAcceptableInterval(currentInput))
                    {
                        Phase_3.SetActive(true);
                        _timeSignaturePhase++;
                        _lastInputTime = Time.time;
                    }
                    else
                    {
                        Lose.SetActive(true);
                        _timeSignaturePhase = 0;
                    }
                }
                break;
            case 3:
                RhythmEnforcer();
                if (InputManager.IsValidKey())
                {
                    float currentInput = Time.time;
                    if (IsOnAcceptableInterval(currentInput))
                    {
                        TextureFeedback.SetActive(true);
                        _lastInputTime = Time.time;
                    }
                    else
                    {
                        Lose.SetActive(true);
                        _timeSignaturePhase = 0;
                        _lastInputTime = Time.time;
                    }
                }
                break;
        }
    }

    private float GetCurrentInterval(float initialInputTime)
    {
        return Time.time - initialInputTime;
    }

    private bool IsOnAcceptableInterval(float currentInput)
    {
        float deltaTime = currentInput - _lastInputTime;
        float[] acceptableTimeInterval = new float[2];
        float fractionFromInterval = _currentIntervalTime / FRACTION_INTERVAL;

        acceptableTimeInterval[0] = _currentIntervalTime - fractionFromInterval;
        acceptableTimeInterval[1] = _currentIntervalTime + fractionFromInterval;

        if (deltaTime > acceptableTimeInterval[0] && deltaTime < acceptableTimeInterval[1])
        {
            return true;
        }

        return false;
    }

    private void RhythmEnforcer()
    {
        float fractionFromInterval = _currentIntervalTime / FRACTION_INTERVAL;

        if (Time.time - _lastInputTime > _currentIntervalTime + fractionFromInterval)
        {
            _timeSignaturePhase = 0;
        }
    }

    private void DisableObjects()
    {
        TextureFeedback.SetActive(false);
        Phase_1.SetActive(false);
        Phase_2.SetActive(false);
        Phase_3.SetActive(false);
        Lose.SetActive(false);
    }

    public float CurrentInterval { get { return _currentIntervalTime; } }
}
