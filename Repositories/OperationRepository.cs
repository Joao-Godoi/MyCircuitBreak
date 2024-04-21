using CalculatorWithCircuitBreaker.Data;
using CalculatorWithCircuitBreaker.Models;
using MySql.Data.MySqlClient;

namespace CalculatorWithCircuitBreaker.Repositories;

public class OperationRepository : DatabaseConnection
{
    public Operation CreateOperation(Operation operation)
    {
        var dataBaseConnection = CreateDataBaseConnection();
        var sql =
            "INSERT INTO operation (operator_type, num_a, num_b, result) VALUES (@operatorType, @numA, @numB, @result); SELECT LAST_INSERT_ID();";
        using (var cmd = new MySqlCommand(sql, dataBaseConnection))
        {
            dataBaseConnection.Open();
            cmd.Parameters.AddWithValue("@operatorType", operation.OperatorType);
            cmd.Parameters.AddWithValue("@numA", operation.NumA);
            cmd.Parameters.AddWithValue("@numB", operation.NumB);
            cmd.Parameters.AddWithValue("@result", operation.Result);
            var operationId = Convert.ToInt32(cmd.ExecuteScalar());
            operation.Id = operationId;
            return operation;
        }
    }

    public Operation? GetOperationById(int id)
    {
        Operation? operation = null;
        var dataBaseConnection = CreateDataBaseConnection();
        var sql = "SELECT * FROM operation WHERE ID = @Id";
        using MySqlCommand cmd = new(sql, dataBaseConnection);
        dataBaseConnection.Open();
        using var rdr = cmd.ExecuteReader();
        if (rdr.Read())
            operation = new Operation(
                rdr.GetString("operator_type"),
                rdr.GetDouble("numA"),
                rdr.GetDouble("numB"),
                rdr.GetDouble("result")
            );
        return operation;
    }
}