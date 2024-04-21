namespace CalculatorWithCircuitBreaker.Models;

public class Operation
{
    public Operation(string operatorType, double numA, double numb)
    {
        OperatorType = operatorType;
        NumA = numA;
        NumB = numb;
    }

    public Operation(string operatorType, double numA, double numb, double result)
    {
        OperatorType = operatorType;
        NumA = numA;
        NumB = numb;
        Result = result;
    }

    public int Id { get; set; }

    public string OperatorType { get; set; }

    public double NumA { get; set; }

    public double NumB { get; set; }

    public double Result { get; set; }
}