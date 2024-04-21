namespace CalculatorWithCircuitBreaker.CircuitBreak;

public class HalfOpenCircuitBreakState : CircuitBreakState
{
    public override void SetStateToClosed()
    {
        throw new NotImplementedException();
    }

    public override void SetStateToHalfOpen()
    {
        throw new NotImplementedException();
    }

    public override void SetStateToOpen()
    {
        _circuitBreak.SetNewState(new OpenCircuitBreakState());
    }
}