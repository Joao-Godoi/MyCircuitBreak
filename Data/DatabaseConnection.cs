using MySql.Data.MySqlClient;

namespace CalculatorWithCircuitBreaker.Data;

public class DatabaseConnection
{
    public MySqlConnection CreateDataBaseConnection()
    {
        MySqlConnection dataBaseConnection =
            new(
                "Persist Security Info=False;server=sql.freedb.tech;database=freedb_calculator_db;uid=freedb_godoi;pwd=t4CWhD!7BcAjqf?");
        return dataBaseConnection;
    }
}