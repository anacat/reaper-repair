using UnityEngine;

public class RhythmGenerator : MonoBehaviour
{
    public RhythmData rhythmData;
    private int _timeSignaturePhase;
    private float _initialInputTime;
    private float _currentIntervalTime;
    private float _lastInputTime;
    private const int FRACTION_INTERVAL_GOOD = 5;
    private const int FRACTION_INTERVAL_GREAT = 10;
    private const int FRACTION_INTERVAL_PERFECT = 15;
    private const float DEFAULT_INTERVAL_TIME = 0.5f;
    private const int MAX_FAIL_TIMES = 8;
    private const int DARK_WIN_TIMES = 4;

    private int _decayCounter = 0;
    private int _winCounter = 0;

    public delegate void OnSuccessEvent();
    public event OnSuccessEvent onSuccess;

    public delegate void OnFailEvent();
    public event OnFailEvent onFail;

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

        rhythmData.buttonPress = InputManager.IsButtonDown();

        switch (_timeSignaturePhase)
        {
            case 0:
                _currentIntervalTime = DEFAULT_INTERVAL_TIME;

                if (InputManager.IsValidKey())
                {
                    Phase_1.SetActive(true);
                    _initialInputTime = Time.time;
                    _lastInputTime = _initialInputTime;
                    _timeSignaturePhase++;
                }
                else
                {
                    _decayCounter++;

                        if(_decayCounter > MAX_FAIL_TIMES)
                    {
                        _decayCounter = 0;
                        RhythmEnforcer();
                    }
                }
                break;
            case 1:
                _currentIntervalTime = DEFAULT_INTERVAL_TIME;

                if (InputManager.IsValidKey())
                {
                    Phase_2.SetActive(true);
                    _currentIntervalTime = GetCurrentInterval(_initialInputTime);
                    rhythmData.currentInterval = _currentIntervalTime;
                    _lastInputTime = Time.time;
                    _timeSignaturePhase++;
                }
                else
                {
                    _decayCounter++;

                    if (_decayCounter > MAX_FAIL_TIMES)
                    {
                        _decayCounter = 0;
                        RhythmEnforcer();
                    }
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
                        _winCounter++;
                        TextureFeedback.SetActive(true);
                        _lastInputTime = Time.time;

                        if (onSuccess != null)
                        {
                            onSuccess();
                        }

                        if(rhythmData.level != RhythmData.Level.Dark && _winCounter > rhythmData.elements[(int)rhythmData.level - 1].spriteList.Count)
                        {
                            BeatLevel();
                        }
                        else if (rhythmData.level == RhythmData.Level.Dark && _winCounter > DARK_WIN_TIMES)
                        {
                            BeatLevel();
                        }
                    }
                    else
                    {
                        Lose.SetActive(true);
                        _timeSignaturePhase = 0;
                        _lastInputTime = Time.time;

                        if (onFail != null)
                        {
                            onFail();
                        }
                    }
                }
                break;
        }

        rhythmData.timeSignaturePhase = _timeSignaturePhase;
    }

    private void BeatLevel()
    {
        _winCounter = 0;
        rhythmData.level++;
    }

    private float GetCurrentInterval(float initialInputTime)
    {
        return Time.time - initialInputTime;
    }

    private float[] GetAcceptableInterval(int fractionInterval)
    {
        float[] acceptableTimeInterval = new float[2];
        float fractionFromInterval = _currentIntervalTime / fractionInterval;

        acceptableTimeInterval[0] = _currentIntervalTime - fractionFromInterval;
        acceptableTimeInterval[1] = _currentIntervalTime + fractionFromInterval;

        return acceptableTimeInterval;
    }

    private bool IsOnAcceptableInterval(float currentInput)
    {
        float deltaTime = currentInput - _lastInputTime;
        float[] acceptableTimeIntervalGood = GetAcceptableInterval(FRACTION_INTERVAL_GOOD);
        float[] acceptableTimeIntervalGreat = GetAcceptableInterval(FRACTION_INTERVAL_GREAT);
        float[] acceptableTimeIntervalPerfect = GetAcceptableInterval(FRACTION_INTERVAL_PERFECT);

        if (deltaTime > acceptableTimeIntervalPerfect[0] && deltaTime < acceptableTimeIntervalPerfect[1])
        {
            rhythmData.successType = RhythmData.SuccessTypes.Perfect;
            return true;
        }

        if (deltaTime > acceptableTimeIntervalGreat[0] && deltaTime < acceptableTimeIntervalGreat[1])
        {
            rhythmData.successType = RhythmData.SuccessTypes.Great;
            return true;
        }

        if (deltaTime > acceptableTimeIntervalGood[0] && deltaTime < acceptableTimeIntervalGood[1])
        {
            rhythmData.successType = RhythmData.SuccessTypes.Good;
            return true;
        }

        return false;
    }

    private void RhythmEnforcer()
    {
        float fractionFromInterval = _currentIntervalTime / FRACTION_INTERVAL_GOOD;

        if (Time.time - _lastInputTime > _currentIntervalTime + fractionFromInterval)
        {
            _timeSignaturePhase = 0;
            if(onFail != null)
            {
                onFail();
            }
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
}
