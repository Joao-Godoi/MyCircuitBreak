namespace CalculatorWithCircuitBreaker.Exceptions;

public class UnavailableServer : Exception
{
    public UnavailableServer(string message) : base(message)
    {
    }
}