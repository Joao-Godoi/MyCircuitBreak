namespace CalculatorWithCircuitBreaker.CircuitBreak;

public class OpenCircuitBreakState : CircuitBreakState
{
    public override void SetStateToClosed()
    {
        _circuitBreak.SetNewState(new ClosedCircuitBreakState());
    }

    public override void SetStateToHalfOpen()
    {
        throw new NotImplementedException();
    }

    public override void SetStateToOpen()
    {
        throw new NotImplementedException();
    }
}