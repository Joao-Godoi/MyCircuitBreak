namespace CalculatorWithCircuitBreaker.Models;

public class Timeout
{
    public Timeout(int time, int idOperation)
    {
        Time = time;
        IdOperation = idOperation;
    }

    public int Time { get; }
    public int IdOperation { get; }
}