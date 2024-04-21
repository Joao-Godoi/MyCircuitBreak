namespace CalculatorWithCircuitBreaker.CircuitBreak;

public abstract class CircuitBreakState
{
    protected CircuitBreak _circuitBreak;

    public void SetCircuitBreak(CircuitBreak circuitBreak)
    {
        _circuitBreak = circuitBreak;
    }

    public abstract void SetStateToClosed();
    public abstract void SetStateToHalfOpen();
    public abstract void SetStateToOpen();
}