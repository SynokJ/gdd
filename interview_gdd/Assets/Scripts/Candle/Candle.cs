using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class Candle : MonoBehaviour, IWettable, IWindable
{
    private const float _DEACTIVATION_DELAY = 5.0f;

    [Header("Protection Components:")]
    [SerializeField] private TMPro.TextMeshProUGUI _protectiontext;

    [Header("Visual Components:")]
    [SerializeField] private Light2D _light;
    [SerializeField] private SpriteRenderer _lightRenderer;

    private CustomTimer _timer;

    private bool _isProtected;
    public delegate void ProceedByActiveStatus();

    private ActiveState _currentActiveState;
    private Dictionary<ActiveState, ProceedByActiveStatus> _procedActivation =
        new Dictionary<ActiveState, ProceedByActiveStatus>();

    private void Awake()
    {
        _procedActivation[ActiveState.active] = ActiveStatus;
        _procedActivation[ActiveState.inactive] = DeactivateStatus;
        Debug.Log(_procedActivation.Count);

        _timer = new CustomTimer(() =>
        {
            _currentActiveState = ActiveState.inactive;
            DeactivateStatus();
        });
    }

    public void OnWetted()
    {
        if(_isProtected) return;

        _currentActiveState = ActiveState.inactive;
        DeactivateStatus();
    }

    public void OnWinded()
    {
        if (_isProtected) return;
        _timer.ActivateTimer(_DEACTIVATION_DELAY);
    }

    public void OnWinding()
    {
        if (_isProtected) return;
        _timer.ProceedTimer();
    }

    public void OnStopWinding()
    {
        if (_isProtected) return;
        _timer.StopTimer();
    }

    public void OnStateSwitched()
    {
        ChangeActiveState();
        ChangeCandle();
    }

    private void ChangeActiveState()
    {
        if (_currentActiveState == ActiveState.active)
            _currentActiveState = ActiveState.inactive;
        else if (_currentActiveState == ActiveState.inactive)
            _currentActiveState = ActiveState.active;
    }

    private void ChangeCandle()
        => _procedActivation[_currentActiveState]();

    private void ActiveStatus()
        => SetActivationStatus(true);

    private void DeactivateStatus()
        => SetActivationStatus(false);

    public void SetProtectionStatus()
    {
        _isProtected = !_isProtected;
        _protectiontext.enabled = _isProtected;
    }

    private void SetActivationStatus(bool status)
    {
        _light.enabled = status;
        _lightRenderer.enabled = status;
    }
}

public enum ActiveState
{
    active = 0,
    inactive = 1
}
