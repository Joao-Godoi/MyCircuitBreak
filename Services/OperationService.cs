using CalculatorWithCircuitBreaker.Models;
using CalculatorWithCircuitBreaker.Records;
using CalculatorWithCircuitBreaker.Repositories;

namespace CalculatorWithCircuitBreaker.Services;

public class OperationService
{
    private readonly OperationRepository _operationRepository = new();

    public double? CreateOperation(OperationRecord operationRecord, string operatorType)
    {
        var result = operatorType switch
        {
            "addition" => operationRecord.NumA + operationRecord.NumB,
            "subtraction" => operationRecord.NumA - operationRecord.NumB,
            "division" => operationRecord.NumA / operationRecord.NumB,
            "multiplication" => operationRecord.NumA * operationRecord.NumB,
            _ => 0.0
        };

        var newOperation = new Operation(operatorType, operationRecord.NumA, operationRecord.NumB, result);
        _operationRepository.CreateOperation(newOperation);
        return newOperation.Result;
    }
}