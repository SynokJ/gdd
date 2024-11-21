public class CustomTimer
{

    public delegate void OnTimerComplete();
    private OnTimerComplete _timerAction;

    private float _currentTimerVal;
    private bool _isRunning = false;

    public CustomTimer(OnTimerComplete tempAction)
    {
        _timerAction = tempAction;
    }

    ~CustomTimer()
    {
        _timerAction = null;
    }

    public void ProceedTimer()
    {
        if (!_isRunning) return;

        if (_currentTimerVal < 0)
        {
            _timerAction?.Invoke();
            _isRunning = false;
        }
        else
            _currentTimerVal -= UnityEngine.Time.deltaTime;
    }

    public void StopTimer()
        => _isRunning = false;

    public void ActivateTimer(float timerVal)
    {
        if (_isRunning) return;

        _isRunning = true;
        _currentTimerVal = timerVal;
    }
}
