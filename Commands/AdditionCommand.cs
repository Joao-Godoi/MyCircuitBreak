using CalculatorWithCircuitBreaker.Records;

namespace CalculatorWithCircuitBreaker.Commands;

public class AdditionCommand : ICommand
{
    public double Execute(OperationRecord operationRecord)
    {
        return operationRecord.NumA + operationRecord.NumB;
    }

    public string GetCommandType()
    {
        return "sum";
    }
}