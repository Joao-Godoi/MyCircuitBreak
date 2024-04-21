using CalculatorWithCircuitBreaker.CircuitBreak;
using CalculatorWithCircuitBreaker.Models;
using CalculatorWithCircuitBreaker.Records;
using CalculatorWithCircuitBreaker.Repositories;

namespace CalculatorWithCircuitBreaker.Commands;

public class AdditionCommand : ICommand
{
    public double? Execute(OperationRecord operationRecord, CircuitBreak.CircuitBreak circuitBreak)
    {
        if (circuitBreak.GetState() is ClosedCircuitBreakState || circuitBreak.GetState() is HalfOpenCircuitBreakState)
        {
            var task = Task.Run(() =>
            {
                var rnd = new Random();
                Thread.Sleep(5000);
                OperationRepository operationRepository = new();
                var result = operationRecord.NumA + operationRecord.NumB;
                var newOperation = new Operation("addition", operationRecord.NumA, operationRecord.NumB, result);
                operationRepository.CreateOperation(newOperation);
                circuitBreak.ResetFailedCount();
                circuitBreak.SetNewState(new ClosedCircuitBreakState());
                return newOperation.Result;
            });
            if (task.Wait(TimeSpan.FromSeconds(2))) return task.Result;

            circuitBreak.IncrementFailedCount();
            if (circuitBreak.GetFailedCount() < circuitBreak.GetFailedMax()) return 0.0;
            circuitBreak.SetNewState(new OpenCircuitBreakState());
            circuitBreak.SetLastFailed(DateTime.Now);
            throw new TimeoutException();
        }

        if (circuitBreak.GetState() is OpenCircuitBreakState)
        {
            var difference = DateTime.Now - circuitBreak.GetLastFailed();
            var secondsDifference = difference.TotalSeconds;
            if (secondsDifference >= 30) circuitBreak.SetNewState(new HalfOpenCircuitBreakState());
        }

        return 0.0;
    }
}