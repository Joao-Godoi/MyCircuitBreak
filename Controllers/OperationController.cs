using CalculatorWithCircuitBreaker.CircuitBreak;
using CalculatorWithCircuitBreaker.Commands;
using CalculatorWithCircuitBreaker.Exceptions;
using CalculatorWithCircuitBreaker.Records;
using CalculatorWithCircuitBreaker.Services;

namespace CalculatorWithCircuitBreaker.Controllers;

public static class OperationController
{
    public static void AddOperationController(this WebApplication app)
    {
        CircuitBreak.CircuitBreak circuitBreak = new(new ClosedCircuitBreakState(), 5);
        var operationService = new OperationService();

        app.MapPost("addition", (OperationRecord operationRecord) =>
        {
            try
            {
                ICommand additionCommand = new AdditionCommand();
                var result = operationService.CreateOperation(operationRecord, circuitBreak, additionCommand);
                return Results.Ok(result);
            }
            catch (CustomTimeoutException ex)
            {
                if (circuitBreak.GetFailedCount() > circuitBreak.GetFailedMax())
                {
                    circuitBreak.SetNewState(new OpenCircuitBreakState());
                    circuitBreak.SetLastFailed(DateTime.Now);
                }

                return Results.Problem(ex.Message, null, 408);
            }
            catch (UnavailableServer ex)
            {
                return Results.Problem(ex.Message, null, 503);
            }
        });

        app.MapPost("subtraction", (OperationRecord operationRecord) =>
        {
            try
            {
                ICommand subtractionCommand = new SubtractionCommand();
                var result = operationService.CreateOperation(operationRecord, circuitBreak, subtractionCommand);
                return Results.Ok(result);
            }
            catch (CustomTimeoutException ex)
            {
                if (circuitBreak.GetFailedCount() > circuitBreak.GetFailedMax())
                {
                    circuitBreak.SetNewState(new OpenCircuitBreakState());
                    circuitBreak.SetLastFailed(DateTime.Now);
                }

                return Results.Problem(ex.Message, null, 408);
            }
            catch (UnavailableServer ex)
            {
                return Results.Problem(ex.Message, null, 503);
            }
        });

        app.MapPost("division", (OperationRecord operationRecord) =>
        {
            try
            {
                ICommand divisionCommand = new DivisionCommand();
                var result = operationService.CreateOperation(operationRecord, circuitBreak, divisionCommand);
                return Results.Ok(result);
            }
            catch (CustomTimeoutException ex)
            {
                if (circuitBreak.GetFailedCount() > circuitBreak.GetFailedMax())
                {
                    circuitBreak.SetNewState(new OpenCircuitBreakState());
                    circuitBreak.SetLastFailed(DateTime.Now);
                }

                return Results.Problem(ex.Message, null, 408);
            }
            catch (UnavailableServer ex)
            {
                return Results.Problem(ex.Message, null, 503);
            }
        });

        app.MapPost("multiplication", (OperationRecord operationRecord) =>
        {
            try
            {
                ICommand multiplicationCommand = new MultiplicationCommand();
                var result = operationService.CreateOperation(operationRecord, circuitBreak, multiplicationCommand);
                return Results.Ok(result);
            }
            catch (CustomTimeoutException ex)
            {
                if (circuitBreak.GetFailedCount() > circuitBreak.GetFailedMax())
                {
                    circuitBreak.SetNewState(new OpenCircuitBreakState());
                    circuitBreak.SetLastFailed(DateTime.Now);
                }

                return Results.Problem(ex.Message, null, 408);
            }
            catch (UnavailableServer ex)
            {
                return Results.Problem(ex.Message, null, 503);
            }
        });
    }
}