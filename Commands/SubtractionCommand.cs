using CalculatorWithCircuitBreaker.Models;
using CalculatorWithCircuitBreaker.Records;
using CalculatorWithCircuitBreaker.Repositories;

namespace CalculatorWithCircuitBreaker.Commands;

public class SubtractionCommand : ICommand
{
    public double? Execute(OperationRecord operationRecord, CircuitBreak.CircuitBreak circuitBreak)
    {
        OperationRepository operationRepository = new();
        var result = operationRecord.NumA - operationRecord.NumB;
        var newOperation = new Operation("addition", operationRecord.NumA, operationRecord.NumB, result);
        operationRepository.CreateOperation(newOperation);
        return newOperation.Result;
    }
}