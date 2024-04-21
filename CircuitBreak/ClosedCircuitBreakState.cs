namespace CalculatorWithCircuitBreaker.CircuitBreak;

public class ClosedCircuitBreakState : CircuitBreakState
{
    public override void SetStateToClosed()
    {
        throw new NotImplementedException();
    }

    public override void SetStateToHalfOpen()
    {
        _circuitBreak.SetNewState(new HalfOpenCircuitBreakState());
    }

    public override void SetStateToOpen()
    {
        throw new NotImplementedException();
    }
}