namespace CalculatorWithCircuitBreaker.Models;

public sealed class RandomGenerator
{
    private static RandomGenerator? _instance;

    private RandomGenerator()
    {
    }

    public static RandomGenerator GetInstance()
    {
        if (_instance == null) _instance = new RandomGenerator();

        return _instance;
    }

    public int GenerateRandomMilliseconds()
    {
        return new Random().Next(50) * 1000;
    }
}