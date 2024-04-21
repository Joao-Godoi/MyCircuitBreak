namespace CalculatorWithCircuitBreaker.CircuitBreak;

public class CircuitBreak
{
    private readonly int _failedMax;
    private int _failedCount;
    private DateTime _lastFailed;
    private CircuitBreakState _state;

    public CircuitBreak(CircuitBreakState state, int failedMax)
    {
        SetNewState(state);
        _failedMax = failedMax;
    }

    public CircuitBreakState GetState()
    {
        return _state;
    }

    public DateTime GetLastFailed()
    {
        return _lastFailed;
    }

    public void SetLastFailed(DateTime lastFailed)
    {
        _lastFailed = lastFailed;
    }

    public int GetFailedCount()
    {
        return _failedCount;
    }

    public void IncrementFailedCount()
    {
        _failedCount++;
    }

    public void ResetFailedCount()
    {
        _failedCount = 0;
    }

    public int GetFailedMax()
    {
        return _failedMax;
    }

    public void SetNewState(CircuitBreakState state)
    {
        _state = state;
        _state.SetCircuitBreak(this);
    }

    public void SetStateToClosed()
    {
        _state.SetStateToClosed();
    }

    public void SetStateToHalfOpen()
    {
        _state.SetStateToHalfOpen();
    }

    public void SetStateToOpen()
    {
        _state.SetStateToOpen();
    }
}