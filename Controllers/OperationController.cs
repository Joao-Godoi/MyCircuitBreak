using CalculatorWithCircuitBreaker.CircuitBreak;
using CalculatorWithCircuitBreaker.Commands;
using CalculatorWithCircuitBreaker.Records;

namespace CalculatorWithCircuitBreaker.Controllers;

public static class OperationController
{
    public static void AddOperationController(this WebApplication app)
    {
        CircuitBreak.CircuitBreak circuitBreak = new(new ClosedCircuitBreakState(), 1);

        app.MapPost("addition", (OperationRecord operationRecord) =>
        {
            ICommand additionCommand = new AdditionCommand();
            return additionCommand.Execute(operationRecord, circuitBreak);
        });

        app.MapPost("subtraction", (OperationRecord operationRecord) =>
        {
            ICommand subtractionCommand = new SubtractionCommand();
            return subtractionCommand.Execute(operationRecord, circuitBreak);
        });

        app.MapPost("division", (OperationRecord operationRecord) =>
        {
            ICommand divisionCommand = new DivisionCommand();
            return divisionCommand.Execute(operationRecord, circuitBreak);
        });

        app.MapPost("multiplication", (OperationRecord operationRecord) =>
        {
            ICommand multiplicationCommand = new MultiplicationCommand();
            return multiplicationCommand.Execute(operationRecord, circuitBreak);
        });
    }
}