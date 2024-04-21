namespace CalculatorWithCircuitBreaker.Models;

public class TimeoutModel
{
    public TimeoutModel(int time, double numA, double numB, string operationType)
    {
        Time = time;
        NumA = numA;
        NumB = numB;
        OperationType = operationType;
    }

    public int Time { get; }

    public double NumA { get; set; }

    public double NumB { get; set; }

    public string OperationType { get; set; }
}