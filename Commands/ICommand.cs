using CalculatorWithCircuitBreaker.Records;

namespace CalculatorWithCircuitBreaker.Commands;

public interface ICommand
{
    double? Execute(OperationRecord operationRecord, CircuitBreak.CircuitBreak circuitBreak);
}