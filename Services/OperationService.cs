using CalculatorWithCircuitBreaker.CircuitBreak;
using CalculatorWithCircuitBreaker.Commands;
using CalculatorWithCircuitBreaker.Exceptions;
using CalculatorWithCircuitBreaker.Models;
using CalculatorWithCircuitBreaker.Records;
using CalculatorWithCircuitBreaker.Repositories;

namespace CalculatorWithCircuitBreaker.Services;

public class OperationService
{
    private readonly RandomGenerator _randomGenerator = RandomGenerator.GetInstance();
    private readonly TimeoutHistoryRepository _timeoutHistoryRepository = new();

    public double CreateOperation(OperationRecord operationRecord, CircuitBreak.CircuitBreak circuitBreak,
        ICommand command)
    {
        var randomTime = _randomGenerator.GenerateRandomMilliseconds();
        Console.WriteLine($"tempo gerado: {randomTime}");
        if (circuitBreak.GetState() is ClosedCircuitBreakState || circuitBreak.GetState() is HalfOpenCircuitBreakState)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(randomTime);
                var result = command.Execute(operationRecord);
                circuitBreak.ResetFailedCount();
                circuitBreak.SetNewState(new ClosedCircuitBreakState());
                return result;
            });
            if (task.Wait(TimeSpan.FromSeconds(20))) return task.Result;

            circuitBreak.IncrementFailedCount();
            var newTimeout =
                new TimeoutModel(randomTime, operationRecord.NumA, operationRecord.NumB, command.GetCommandType());
            _timeoutHistoryRepository.CreateTimeout(newTimeout);
            throw new CustomTimeoutException("Timeout, please try again!");
        }

        if (circuitBreak.GetState() is OpenCircuitBreakState)
        {
            var difference = DateTime.Now - circuitBreak.GetLastFailed();
            var secondsDifference = difference.TotalSeconds;
            Console.WriteLine($"SEGUNDOS QUE JA PASSOU: {secondsDifference}");
            if (secondsDifference >= 30) circuitBreak.SetNewState(new HalfOpenCircuitBreakState());
            throw new UnavailableServer("Unavailable server, please try again later!");
        }

        return 0.0;
    }
}