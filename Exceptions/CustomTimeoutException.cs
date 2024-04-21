namespace CalculatorWithCircuitBreaker.Exceptions;

public class CustomTimeoutException : Exception
{
    public CustomTimeoutException(string message) : base(message)
    {
    }
}