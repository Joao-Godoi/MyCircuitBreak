using CalculatorWithCircuitBreaker.Data;
using CalculatorWithCircuitBreaker.Models;
using MySql.Data.MySqlClient;

namespace CalculatorWithCircuitBreaker.Repositories;

public class TimeoutHistoryRepository : DatabaseConnection
{
    public void CreateTimeout(TimeoutModel timeoutModel)
    {
        var dataBaseConnection = CreateDataBaseConnection();
        var sql =
            "INSERT INTO timeout_history (response_time, num_a, num_b, operation_type) VALUES (@responseTime, @numA, @numB, @operationType);";
        using (var cmd = new MySqlCommand(sql, dataBaseConnection))
        {
            dataBaseConnection.Open();
            cmd.Parameters.AddWithValue("@responseTime", timeoutModel.Time);
            cmd.Parameters.AddWithValue("@numA", timeoutModel.NumA);
            cmd.Parameters.AddWithValue("@numB", timeoutModel.NumB);
            cmd.Parameters.AddWithValue("@operationType", timeoutModel.OperationType);
            cmd.ExecuteNonQuery();
        }
    }
}